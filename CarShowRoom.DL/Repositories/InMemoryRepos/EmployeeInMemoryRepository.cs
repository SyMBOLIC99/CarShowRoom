using CarShowRoom.DL.InMemoryDb;
using CarShowRoom.DL.Interfaces;
using CarShowRoom.Models.DTO;
using System.Collections.Generic;
using System.Linq;

namespace CarShowRoom.DL.Repositories.InMemoryRepos
{
    public class EmployeeInMemoryRepository : IEmployeeRepository
    {
    public EmployeeInMemoryRepository()
    {

    }

    public Employee Create(Employee employee)
    {
        EmployeeInMemoryCollection.EmployeeDB.Add(employee);

        return employee;
    }
    public Employee Delete(int id)
    {
        var employee = EmployeeInMemoryCollection.EmployeeDB.FirstOrDefault(employee => employee.Id == id);
        EmployeeInMemoryCollection.EmployeeDB.Remove(employee);
        return employee;
    }

    public Employee GetById(int id)
    {
        return EmployeeInMemoryCollection.EmployeeDB.FirstOrDefault(x => x.Id == id);
    }

    public IEnumerable<Employee> GetAll()
    {
        return EmployeeInMemoryCollection.EmployeeDB;
    }
    public Employee Update(Employee employee)
    {
        {

            var result = EmployeeInMemoryCollection.EmployeeDB.FirstOrDefault(x => x.Id == employee.Id);

            result.Name = employee.Name;
            result.Salary = employee.Salary;

            return result;

        }
    }
}
}
