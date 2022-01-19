using CarShowRoom.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
