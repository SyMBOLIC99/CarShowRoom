using CarShowRoom.Models.DTO;
using System.Collections.Generic;

namespace CarShowRoom.DL.InMemoryDb
{
    public class CarInMemoryCollection
    {

        public static List<Car> CarDB = new List<Car>()
        {
            new Car()
            {
                Id = 1,
                Brand = "BMW",
                Model = "Fifth series",
                Year = 2008,
                FuelType = Models.DTO.Enums.CarFuelType.Diesel,
                Type = Models.DTO.Enums.CarType.Sedan,
                Price = 15000
            },
            new Car(){
                Id = 2,
                Brand = "Mercedes - Benz",
                Model = "E class",
                Year = 2010,
                FuelType = Models.DTO.Enums.CarFuelType.Gasoline,
                Type = Models.DTO.Enums.CarType.Coupe,
                Price = 22000
            },
            new Car()
            {
                Id = 3,
                Brand = "Toyota",
                Model = "Prius",
                Year = 2018,
                FuelType = Models.DTO.Enums.CarFuelType.Hybrid,
                Type = Models.DTO.Enums.CarType.Hatchback,
                Price = 30000
        }

    };
}
}
