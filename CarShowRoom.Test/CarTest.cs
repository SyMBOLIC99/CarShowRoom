using AutoMapper;
using CarShowRoom.BL.Interfaces;
using CarShowRoom.BL.Services;
using CarShowRoom.Controllers;
using CarShowRoom.DL.Interfaces;
using CarShowRoom.Extensions;
using CarShowRoom.Models.DTO;
using CarShowRoom.Models.Enums;
using CarShowRoom.Models.Requests;
using CarShowRoom.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Serilog;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Xunit;

namespace CarShowRoom.Test
{
    public class CarTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<ICarRepository> _carRepository;
        private readonly ICarService _carService;
        private readonly CarController _carController;

        private IList<Car> Cars = new List<Car>()
        {
            new Car()
            {
                Id = 1,
                Brand = "Toyota",
                Model = "Camry",
                Year = 2010,
                FuelType = CarFuelType.Diesel,
                Type = Models.Enums.CarType.Sedan,
                Price = 15000
            },
            new Car(){
                Id = 2,
                Brand = "VW",
                Model = "Polo",
                Year = 2014,
                FuelType = CarFuelType.Gasoline,
                Type = Models.Enums.CarType.Hatchback,
                Price = 20000
        } };

        public CarTest()
        {
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapping());
            });
            _mapper = mockMapper.CreateMapper();

            _carRepository = new Mock<ICarRepository>();

            var logger = new Mock<ILogger>();

            _carService = new CarService(_carRepository.Object);
            _carController = new CarController(_carService, _mapper);

        }
        [Fact]
        public void Car_GetAll_Count_Check()
        {
            //setup
            var expectedCount = 2;

            var mockedService = new Mock<ICarService>();

            mockedService.Setup(x => x.GetAll()).Returns(Cars);

            //inject
            var controller = new CarController(mockedService.Object, _mapper);

            //Act
            var result = controller.GetAll();

            //Assert
            var okObjectResult = result as OkObjectResult;
            Assert.NotNull(okObjectResult);
            Assert.Equal(okObjectResult.StatusCode, (int)HttpStatusCode.OK);

            var cars = okObjectResult.Value as IEnumerable<Car>;
            Assert.NotNull(cars);
            Assert.Equal(expectedCount, cars.Count());
        }
        [Fact]
        public void Car_GetById_NameCheck()
        {
            //setup
            var carId = 2;
            var expectedBrand = "VW";

            _carRepository.Setup(x => x.GetById(carId))
                .Returns(Cars.FirstOrDefault(e => e.Id == carId));

            //Act
            var result = _carController.GetById(carId);

            //Assert
            var okObjectResult = result as OkObjectResult;
            Assert.NotNull(okObjectResult);
            Assert.Equal(okObjectResult.StatusCode, (int)HttpStatusCode.OK);

            var response = okObjectResult.Value as CarResponse;
            var car = _mapper.Map<Car>(response);

            Assert.NotNull(car);
            Assert.Equal(expectedBrand, car.Brand);
        }

        [Fact]
        public void Car_GetById_NotFound()
        {
            //setup
            var carId = 3;

            _carRepository.Setup(x => x.GetById(carId))
                .Returns(Cars.FirstOrDefault(t => t.Id == carId));

            //Act
            var result = _carController.GetById(carId);

            //Assert
            var notFoundObjectResult = result as NotFoundObjectResult;
            Assert.NotNull(notFoundObjectResult);
            Assert.Equal(notFoundObjectResult.StatusCode, (int)HttpStatusCode.NotFound);

            var response = (int)notFoundObjectResult.Value;
            Assert.Equal(carId, response);
        }

        [Fact]
        public void Car_Update_CarBrand()
        {
            var carId = 1;
            var expectedBrand = "Updated Car Brand";

            var car = Cars.FirstOrDefault(x => x.Id == carId);
            car.Brand = expectedBrand;

            _carRepository.Setup(x => x.GetById(carId))
                .Returns(Cars.FirstOrDefault(t => t.Id == carId));
            _carRepository.Setup(x => x.Update(car))
                .Returns(car);

            //Act
            var carUpdateRequest = _mapper.Map<CarUpdateRequest>(car);
            var result = _carController.Update(carUpdateRequest);

            //Assert
            var okObjectResult = result as OkObjectResult;
            Assert.NotNull(okObjectResult);
            Assert.Equal(okObjectResult.StatusCode, (int)HttpStatusCode.OK);

            var val = okObjectResult.Value as Car;
            Assert.NotNull(val);
            Assert.Equal(expectedBrand, val.Brand);

        }

        [Fact]
        public void Car_Delete_ExistingCar()
        {
            //Setup
            var carId = 1;

            var car = Cars.FirstOrDefault(x => x.Id == carId);

            _carRepository.Setup(x => x.Delete(carId)).Callback(() => Cars.Remove(car)).Returns(car);

            //Act
            var result = _carController.Delete(carId);

            //Assert
            var okObjectResult = result as OkObjectResult;
            Assert.NotNull(okObjectResult);
            Assert.Equal(okObjectResult.StatusCode, (int)HttpStatusCode.OK);

            var val = okObjectResult.Value as Car;
            Assert.NotNull(val);
            Assert.Equal(1, Cars.Count);
            Assert.Null(Cars.FirstOrDefault(x => x.Id == carId));
        }

        [Fact]
        public void Car_Delete_NotExisting_Car()
        {
            //Setup
            var carId = 3;

            var car = Cars.FirstOrDefault(x => x.Id == carId);

            _carRepository.Setup(x => x.Delete(carId)).Callback(() => Cars.Remove(car)).Returns(car);

            //Act
            var result = _carController.Delete(carId);

            //Assert
            var notFoundObjectResult = result as NotFoundObjectResult;
            Assert.NotNull(notFoundObjectResult);
            Assert.Equal(notFoundObjectResult.StatusCode, (int)HttpStatusCode.NotFound);

            var response = (int)notFoundObjectResult.Value;
            Assert.Equal(carId, response);
        }

        [Fact]
        public void Car_CreateCar()
        {
            //setup
            var car = new Car()
            {
                Id = 3,
                Brand = "Dodge",
                Model = "Challenger",
                Year = 2014,
                FuelType = CarFuelType.Gasoline,
                Type = Models.Enums.CarType.Muscle,
                Price = 40000
            };

            _carRepository.Setup(x => x.GetAll()).Returns(Cars);

            _carRepository.Setup(x => x.Create(It.IsAny<Car>())).Callback(() =>
            {
                Cars.Add(car);
            }).Returns(car);

            //Act
            var result = _carController.CreateCar(_mapper.Map<CarRequest>(car));

            //Assert
            var okObjectResult = result as OkObjectResult;

            Assert.Equal(okObjectResult.StatusCode, (int)HttpStatusCode.OK);
            Assert.NotNull(Cars.FirstOrDefault(x => x.Id == car.Id));
            Assert.Equal(3, Cars.Count);
        }
    }
}
