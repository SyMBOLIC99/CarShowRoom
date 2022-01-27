

using CarShowRoom.Models.DTO;
using CarShowRoom.Models.DTO.Models;
using CarShowRoom.Models.Enums;
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
                    }
                }
            },
            new Client()
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

            }
        };
    }
}
