using CarShowRoom.Models.DTO;
using System.Collections.Generic;

namespace CarShowRoom.DL.Interfaces
{
    public interface ICarRepository
    {
        Car Create(Car car);
        Car Update(Car car);
        Car Delete(int id);
        Car GetById(int id);
        IEnumerable<Car> GetAll();

    }
}
