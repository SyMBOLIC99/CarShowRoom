using CarShowRoom.DL.InMemoryDb;
using CarShowRoom.DL.Interfaces;
using CarShowRoom.Models.DTO.Models;
using System.Collections.Generic;
using System.Linq;

namespace CarShowRoom.DL.Repositories.InMemoryRepos
{
    public class BuyerInMemoryRepository : IBuyerRepository
    {
        public BuyerInMemoryRepository()
        {

        }

        public Buyer Create(Buyer buyer)
        {
            BuyerInMemoryCollection.BuyerDB.Add(buyer);

            return buyer;
        }
        public Buyer Delete(int id)
        {
            var buyer = BuyerInMemoryCollection.BuyerDB.FirstOrDefault(buyer => buyer.Id == id);
            BuyerInMemoryCollection.BuyerDB.Remove(buyer);
            return buyer;
        }

        public Buyer GetById(int id)
        {
            return BuyerInMemoryCollection.BuyerDB.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Buyer> GetAll()
        {
            return BuyerInMemoryCollection.BuyerDB;
        }
        public Buyer Update(Buyer buyer)
        {
            {

                var result = BuyerInMemoryCollection.BuyerDB.FirstOrDefault(x => x.Id == buyer.Id);

                result.Name = buyer.Name;

                return result;

            }
        }
    }
}
