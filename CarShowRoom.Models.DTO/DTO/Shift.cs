using CarShowRoom.Models.Enums;
using System.Collections.Generic;

namespace CarShowRoom.Models.DTO
{
    public  class Shift
    {
        public int Id { get; set; }
        public DaysOfWeek DaysOfWeek { get; set; }
        public string Name { get; set; }
        public List<Employee> Employees { get; set; }
       
    }
}
