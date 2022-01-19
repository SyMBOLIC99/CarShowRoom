using CarShowRoom.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShowRoom.DL.InMemoryDb
{
    public  class EmployeeInMemoryCollection
    {
        public static List<Employee> EmployeeDB = new List<Employee>()
        {
            new Employee()
        {
            Id = 1,
            Name = "Nikolai",
            Salary = 1000
        },
            new Employee(){
            Id = 2,
            Name = "Dragan",
            Salary = 1200
        },
            new Employee(){
            Id = 3,
            Name = "Anton",
            Salary = 1600
        }
            };
       
    }
}
