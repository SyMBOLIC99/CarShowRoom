using AutoMapper;
using CarShowRoom.BL.Interfaces;
using CarShowRoom.BL.Services;
using CarShowRoom.Controllers;
using CarShowRoom.DL.Interfaces;
using CarShowRoom.Extensions;
using CarShowRoom.Models.DTO;
using CarShowRoom.Models.DTO.Models;
using CarShowRoom.Models.Enums;
using CarShowRoom.Models.Requests;
using CarShowRoom.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CarShowRoom.Test
{
    public class ClientTest
    {

        private readonly IMapper _mapper;
        private readonly Mock<IClientRepository> _clientRepository;
        private readonly IClientService _clientService;
        private readonly ClientController _clientController;

        private IList<Client> Clients = new List<Client>()
        {
            new Client()
            {
                Id = 1,
                Name = "Ivan",
                Balance = 20000,
                RecommendedCar = new List<Car>()
                {
                    new Car(){
                    Id = 1,
                Brand = "BMW",
                Model = "5 series",
                Year = 2008,
                FuelType = CarFuelType.Diesel,
                Type = CarType.Sedan,
                Price = 15000
                    }

                }
            },

            new Client()
            {
                Id = 2,
                Name = "Stoyan",
                Balance = 25000,
                RecommendedCar = new List<Car>()
                {
                    new Car(){
                    Id = 2,
                Brand = "Mercedes - Benz",
                Model = "E class",
                Year = 2010,
                FuelType = CarFuelType.Gasoline,
                Type = CarType.Coupe,
                Price = 22000
                    } } } };

        public ClientTest()
        {
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapping());
            });
            _mapper = mockMapper.CreateMapper();

            _clientRepository = new Mock<IClientRepository>();

            var logger = new Mock<ILogger>();

            _clientService = new ClientService(_clientRepository.Object);
            _clientController = new ClientController(_clientService, _mapper);

        }
        [Fact]
        public void Client_GetAll_Count_Check()
        {
            //setup
            var expectedCount = 2;

            var mockedService = new Mock<IClientService>();

            mockedService.Setup(x => x.GetAll()).Returns(Clients);

            //inject
            var controller = new ClientController(mockedService.Object, _mapper);

            //Act
            var result = controller.GetAll();

            //Assert
            var okObjectResult = result as OkObjectResult;
            Assert.NotNull(okObjectResult);
            Assert.Equal(okObjectResult.StatusCode, (int)HttpStatusCode.OK);

            var clients = okObjectResult.Value as IEnumerable<Client>;
            Assert.NotNull(clients);
            Assert.Equal(expectedCount, clients.Count());
        }

        [Fact]
        public void Client_GetById_NameCheck()
        {
            //setup
            var clientId = 2;
            var expectedName = "Stoyan";

            _clientRepository.Setup(x => x.GetById(clientId))
                .Returns(Clients.FirstOrDefault(e => e.Id == clientId));

            //Act
            var result = _clientController.GetById(clientId);

            //Assert
            var okObjectResult = result as OkObjectResult;
            Assert.NotNull(okObjectResult);
            Assert.Equal(okObjectResult.StatusCode, (int)HttpStatusCode.OK);

            var response = okObjectResult.Value as ClientResponse;
            var client = _mapper.Map<Client>(response);

            Assert.NotNull(client);
            Assert.Equal(expectedName, client.Name);
        }

        [Fact]
        public void Client_GetById_NotFound()
        {
            //setup
            var clientId = 3;

            _clientRepository.Setup(x => x.GetById(clientId))
                .Returns(Clients.FirstOrDefault(t => t.Id == clientId));

            //Act
            var result = _clientController.GetById(clientId);

            //Assert
            var notFoundObjectResult = result as NotFoundObjectResult;
            Assert.NotNull(notFoundObjectResult);
            Assert.Equal(notFoundObjectResult.StatusCode, (int)HttpStatusCode.NotFound);

            var response = (int)notFoundObjectResult.Value;
            Assert.Equal(clientId, response);
        }

        [Fact]
        public void Client_Update_ClientName()
        {
            var clientId = 1;
            var expectedName = "Updated Client Name";

            var client = Clients.FirstOrDefault(x => x.Id == clientId);
            client.Name = expectedName;

            _clientRepository.Setup(x => x.GetById(clientId))
                .Returns(Clients.FirstOrDefault(t => t.Id == clientId));
            _clientRepository.Setup(x => x.Update(client))
                .Returns(client);

            //Act
            var clientUpdateRequest = _mapper.Map<ClientUpdateRequest>(client);
            var result = _clientController.Update(clientUpdateRequest);

            //Assert
            var okObjectResult = result as OkObjectResult;
            Assert.NotNull(okObjectResult);
            Assert.Equal(okObjectResult.StatusCode, (int)HttpStatusCode.OK);

            var val = okObjectResult.Value as Client;
            Assert.NotNull(val);
            Assert.Equal(expectedName, val.Name);

        }

        [Fact]
        public void Client_Delete_ExistingClient()
        {
            //Setup
            var clientId = 1;

            var client = Clients.FirstOrDefault(x => x.Id == clientId);

            _clientRepository.Setup(x => x.Delete(clientId)).Callback(() => Clients.Remove(client)).Returns(client);

            //Act
            var result = _clientController.Delete(clientId);

            //Assert
            var okObjectResult = result as OkObjectResult;
            Assert.NotNull(okObjectResult);
            Assert.Equal(okObjectResult.StatusCode, (int)HttpStatusCode.OK);

            var val = okObjectResult.Value as Client;
            Assert.NotNull(val);
            Assert.Equal(1, Clients.Count);
            Assert.Null(Clients.FirstOrDefault(x => x.Id == clientId));
        }

        [Fact]
        public void Client_Delete_NotExisting_Client()
        {
            //Setup
            var clientId = 3;

            var client = Clients.FirstOrDefault(x => x.Id == clientId);

            _clientRepository.Setup(x => x.Delete(clientId)).Callback(() => Clients.Remove(client)).Returns(client);

            //Act
            var result = _clientController.Delete(clientId);

            //Assert
            var notFoundObjectResult = result as NotFoundObjectResult;
            Assert.NotNull(notFoundObjectResult);
            Assert.Equal(notFoundObjectResult.StatusCode, (int)HttpStatusCode.NotFound);

            var response = (int)notFoundObjectResult.Value;
            Assert.Equal(clientId, response);
        }

        [Fact]
        public void Client_CreateClient()
        {
            //setup
            var client = new Client()
            {
                Id = 3,
                Name = "Momchil",
                Balance = 50000,
                RecommendedCar = new List<Car>()
                {
                    new Car(){
                     Id = 3,
                Brand = "Toyota",
                Model = "Prius",
                Year = 2018,
                FuelType = CarFuelType.Hybrid,
                Type = CarType.Hatchback,
                Price = 30000
                    }
                }
            };

            _clientRepository.Setup(x => x.GetAll()).Returns(Clients);

            _clientRepository.Setup(x => x.Create(It.IsAny<Client>())).Callback(() =>
            {
                Clients.Add(client);
            }).Returns(client);

            //Act
            var result = _clientController.CreateClient(_mapper.Map<ClientRequest>(client));

            //Assert
            var okObjectResult = result as OkObjectResult;

            Assert.Equal(okObjectResult.StatusCode, (int)HttpStatusCode.OK);
            Assert.NotNull(Clients.FirstOrDefault(x => x.Id == client.Id));
            Assert.Equal(3, Clients.Count);

        }


    }
}
    

