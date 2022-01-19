using CarShowRoom.BL.Interfaces;
using CarShowRoom.DL.Interfaces;
using CarShowRoom.Models.DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShowRoom.BL.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientrepository;

        public ClientService(IClientRepository clientrepository)
        {
            _clientrepository = clientrepository;
        }
        public Client Create(Client client)
        {
            var index = _clientrepository.GetAll().OrderByDescending(x => x.Id).FirstOrDefault()?.Id;

            client.Id = (int)(index != null ? index + 1 : 1);

            return _clientrepository.Create(client);
        }

        public Client Delete(int id)
        {
            return _clientrepository.Delete(id);
        }

        public IEnumerable<Client> GetAll()
        {
            return _clientrepository.GetAll();
        }

        public Client GetById(int id)
        {
            return _clientrepository.GetById(id);
        }

        public Client Update(Client client)
        {
            return _clientrepository.Update(client);
        }
    }
}
