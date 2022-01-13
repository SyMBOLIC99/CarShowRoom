

using CarShowRoom.Models.DTO.Models;
using System.Collections.Generic;

namespace CarShowRoom.DL.InMemoryDb
{
    public class BuyerInMemoryCollection
    {
        public static List<Buyer> BuyerDB = new List<Buyer>()
        {
            new Buyer()
            {
                Id = 1,
                Name = "Ivan",
                Balance = 20000
            },
            new Buyer()
            {
                Id = 2,
                Name = "Stoyan",
                Balance = 30000
            },
            new Buyer()
            {
                Id = 3,
                Name = "Momchil",
                Balance = 50000
            }
        };

    }
}
