using CarShowRoom.Models.DTO;
using CarShowRoom.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
