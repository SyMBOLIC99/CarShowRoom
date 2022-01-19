using CarShowRoom.Models.DTO;
using System.Collections.Generic;
using CarShowRoom.Models.Enums;

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
                Model = "5 series",
                Year = 2008,
                FuelType = CarFuelType.Diesel,
                Type = Models.Enums.CarType.Sedan,
                Price = 15000
            },
            new Car(){
                Id = 2,
                Brand = "Mercedes - Benz",
                Model = "E class",
                Year = 2010,
                FuelType = Models.Enums.CarFuelType.Gasoline,
                Type = Models.Enums.CarType.Coupe,
                Price = 22000
            },
            new Car()
            {
                Id = 3,
                Brand = "Toyota",
                Model = "Prius",
                Year = 2018,
                FuelType = Models.Enums.CarFuelType.Hybrid,
                Type = Models.Enums.CarType.Hatchback,
                Price = 30000
        }

    };
}
}
