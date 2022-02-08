using CarShowRoom.Models.DTO;
using System.Collections.Generic;

namespace CarShowRoom.DL.Interfaces
{
    public  interface IShiftRepository
    {
        Shift Create(Shift shift);
        Shift Update(Shift shift);
        Shift Delete(int id);
        Shift GetById(int id);
        IEnumerable<Shift> GetAll();
    }
}
