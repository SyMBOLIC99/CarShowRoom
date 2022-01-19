

using CarShowRoom.Models.DTO.Models;
using System.Collections.Generic;

namespace CarShowRoom.DL.InMemoryDb
{
    public class ClientInMemoryCollection
    {
        public static List<Client> ClientDB = new List<Client>()
        {
            new Client()
            {
                Id = 1,
                Name = "Ivan",
                Balance = 20000
            },
            new Client()
            {
                Id = 2,
                Name = "Stoyan",
                Balance = 30000
            },
            new Client()
            {
                Id = 3,
                Name = "Momchil",
                Balance = 50000
            }
        };

    }
}
