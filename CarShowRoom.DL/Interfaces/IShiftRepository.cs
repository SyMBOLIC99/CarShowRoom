using CarShowRoom.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
