﻿using CarShowRoom.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShowRoom.DL.InMemoryDb
{
    public class ShiftInMemoryCollection
    {
        public static List<Shift> ShiftDB = new List<Shift>()
        {


            new Shift()
        {
            Id = 1,
            Name = "Nikolai",
            Employees = new List<Employee>
            {
            new Employee()
        {
            Id = 1,
            Name = "Nikolai",
            Salary = 1000
        }
            }
            },
            new Shift()
            {
             Id = 2,
             Name = "Dragan",
             Employees = new List<Employee>{

            new Employee(){
            Id = 2,
            Name = "Dragan",
            Salary = 1200
          }
          }
            },
            new Shift()
            {
            Id = 3,
            Name = "Anton",
            Employees = new List<Employee>{
            new Employee(){
            Id = 3,
            Name = "Anton",
            Salary = 1600
        }

        }
        }
    };
}
}