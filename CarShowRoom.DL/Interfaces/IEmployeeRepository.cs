using CarShowRoom.Models.DTO;
using System.Collections.Generic;

namespace CarShowRoom.DL.Interfaces
{
    public  interface IEmployeeRepository
    {
        Employee Create(Employee employee);
        Employee Update(Employee employee);
        Employee Delete(int id);
        Employee GetById(int id);
        IEnumerable<Employee> GetAll();
    }
}
