using System.Collections.Generic;
using System.Threading.Tasks;
using EmployeeRegister.Core.Models;

namespace EmployeeRegister.Core.Services.Contracts
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetAll();
        Task<Employee> Get(int id);
        Task<Employee> Create(Employee employee);
        Task<Employee> UpdateEmployee(Employee employee);
        Task DeleteEmployee(int id);
    }
}
