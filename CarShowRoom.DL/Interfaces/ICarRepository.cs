using CarShowRoom.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
