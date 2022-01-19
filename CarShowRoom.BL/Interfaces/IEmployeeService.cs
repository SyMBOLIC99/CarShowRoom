using CarShowRoom.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShowRoom.BL.Interfaces
{
    public  interface IEmployeeService
    {
        Employee Create(Employee employee);
        Employee Update(Employee employee);
        Employee Delete(int id);
        Employee GetById(int id);
        IEnumerable<Employee> GetAll();
    }
}
