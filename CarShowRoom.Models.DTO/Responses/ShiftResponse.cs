using CarShowRoom.Models.DTO;
using CarShowRoom.Models.Enums;
using System.Collections.Generic;

namespace CarShowRoom.Models.Responses
{
    public  class ShiftResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DaysOfWeek DaysOfWeek { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
