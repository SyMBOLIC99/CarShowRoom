using CarShowRoom.DL.InMemoryDb;
using CarShowRoom.DL.Interfaces;
using CarShowRoom.Models.DTO;
using System.Collections.Generic;
using System.Linq;

namespace CarShowRoom.DL.Repositories.InMemoryRepos
{
    public class CarInMemoryRepository : ICarRepository
    {
        public CarInMemoryRepository()
        {

        }

        public Car Create(Car car)
        {
            CarInMemoryCollection.CarDB.Add(car);

            return car;
        }
        public Car GetById(int id)
        {
            return CarInMemoryCollection.CarDB.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Car> GetAll()
        {
            return CarInMemoryCollection.CarDB;
        }
        public Car Update(Car car)
        {
            {
                var result = CarInMemoryCollection.CarDB.FirstOrDefault(x => x.Id == car.Id);

                result.Brand = car.Brand;
                result.Model = car.Model;
                result.Year = car.Year;
                result.Type = car.Type;
                result.FuelType = car.FuelType;
                result.Price = car.Price;

                return result;
            }
        }

        public Car Delete(int id)
        {
            var car = CarInMemoryCollection.CarDB.FirstOrDefault(car => car.Id == id);
            CarInMemoryCollection.CarDB.Remove(car);
            return car;
        }
    }
}
