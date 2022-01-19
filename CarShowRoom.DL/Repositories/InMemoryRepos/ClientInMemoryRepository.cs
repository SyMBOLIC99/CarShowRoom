using CarShowRoom.DL.InMemoryDb;
using CarShowRoom.DL.Interfaces;
using CarShowRoom.Models.DTO.Models;
using System.Collections.Generic;
using System.Linq;

namespace CarShowRoom.DL.Repositories.InMemoryRepos
{
    public class ClientInMemoryRepository : IClientRepository
    {
        public ClientInMemoryRepository()
        {

        }

        public Client Create(Client client)
        {
            ClientInMemoryCollection.ClientDB.Add(client);

            return client;
        }
        public Client Delete(int id)
        {
            var client = ClientInMemoryCollection.ClientDB.FirstOrDefault(client => client.Id == id);
            ClientInMemoryCollection.ClientDB.Remove(client);
            return client;
        }

        public Client GetById(int id)
        {
            return ClientInMemoryCollection.ClientDB.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Client> GetAll()
        {
            return ClientInMemoryCollection.ClientDB;
        }
        public Client Update(Client client)
        {
            {

                var result = ClientInMemoryCollection.ClientDB.FirstOrDefault(x => x.Id == client.Id);

                result.Name = client.Name;
                result.Balance = client.Balance;

                return result;

            }
        }
    }
}
