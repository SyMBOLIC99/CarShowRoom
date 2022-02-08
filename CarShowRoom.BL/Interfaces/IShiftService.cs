using CarShowRoom.Models.DTO;
using System.Collections.Generic;

namespace CarShowRoom.BL.Interfaces
{
    public  interface IShiftService
    {
        Shift Create(Shift shift);
        Shift Update(Shift shift);
        Shift Delete(int id);
        Shift GetById(int id);
        IEnumerable<Shift> GetAll();
    }
}
