using CarShowRoom.DL.InMemoryDb;
using CarShowRoom.DL.Interfaces;
using CarShowRoom.Models.DTO;
using System.Collections.Generic;
using System.Linq;

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

                result.Id = shift.Id;
                result.DaysOfWeek = shift.DaysOfWeek;
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
