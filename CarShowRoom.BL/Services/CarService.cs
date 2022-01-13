using CarShowRoom.BL.Interfaces;
using CarShowRoom.DL.Interfaces;
using CarShowRoom.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShowRoom.BL.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carrepository;

        public CarService(ICarRepository carrepository)
        {
            _carrepository = carrepository;
        }
        public Car Create(Car car)
        {
            var index = _carrepository.GetAll().OrderByDescending(x => x.Id).FirstOrDefault()?.Id;

            car.Id = (int)(index != null ? index + 1 : 1);

            return _carrepository.Create(car);
        }

        public Car Delete(int id)
        {
            return _carrepository.Delete(id);
        }

        public IEnumerable<Car> GetAll()
        {
            return _carrepository.GetAll();
        }

        public Car GetById(int id)
        {
            return _carrepository.GetById(id);
        }

        public Car Update(Car car)
        {
            return _carrepository.Update(car);
        }
    }
}
