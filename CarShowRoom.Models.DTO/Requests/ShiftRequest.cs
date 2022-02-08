using CarShowRoom.Models.DTO;
using CarShowRoom.Models.Enums;
using System.Collections.Generic;

namespace CarShowRoom.Models.Requests
{
    public class ShiftRequest
    {
        public string Name { get; set; }
        public DaysOfWeek DaysOfWeek { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
