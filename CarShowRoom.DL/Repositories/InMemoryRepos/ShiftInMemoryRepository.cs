using CarShowRoom.DL.InMemoryDb;
using CarShowRoom.DL.Interfaces;
using CarShowRoom.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShowRoom.DL.Repositories.InMemoryRepos
{
    public class ShiftInMemoryRepository : IShiftRepository
    {
        public ShiftInMemoryRepository()
        {

        }

        public Shift Create(Shift shift)
        {
            ShiftInMemoryCollection.ShiftDB.Add(shift);

            return shift;
        }
        public Shift GetById(int id)
        {
            return ShiftInMemoryCollection.ShiftDB.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Shift> GetAll()
        {
            return ShiftInMemoryCollection.ShiftDB;
        }
        public Shift Update(Shift shift)
        {
            {
                var result = ShiftInMemoryCollection.ShiftDB.FirstOrDefault(x => x.Id == shift.Id);

                result.Name = shift.Name;
                result.Employees = shift.Employees;

                return result;
            }
        }

        public Shift Delete(int id)
        {
            var shift = ShiftInMemoryCollection.ShiftDB.FirstOrDefault(shift => shift.Id == id);
            ShiftInMemoryCollection.ShiftDB.Remove(shift);
            return shift;
        }
    }
}
