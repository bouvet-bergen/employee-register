using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeRegister.Core.Models;
using EmployeeRegister.Core.Repositories.Contracts;
using EmployeeRegister.Core.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace EmployeeRegister.Core.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<List<Employee>> GetAll()
        {
            return await _employeeRepository.GetAll().OrderBy(x => x.LastName).ThenBy(x => x.FirstName).ToListAsync();
        }

        public async Task<Employee> Get(int id)
        {
            if(id <= 0)
                throw new EmployeeRegisterBadRequestException("The id of the employee must be greater then 0");

            return await _employeeRepository.FindBy(x => x.Id == id).Include(x => x.Manager).Include(x => x.Employees).FirstOrDefaultAsync();
        }

        public async Task<Employee> Create(Employee employee)
        {
            if(employee == null)
                throw new EmployeeRegisterBadRequestException("Couldn't create an employee. The employee is not defined.");

            if (employee.Id > 0)
                throw new EmployeeRegisterBadRequestException($"Couldn't create an employee with id:{employee.Id}. The id of the employee must be 0.");

            if (employee.ManagerId != null && employee.ManagerId <= 0)
                employee.ManagerId = null;

            employee.Manager = null;
            employee.Employees = null;

            await _employeeRepository.CreateAsync(employee);
            await _employeeRepository.SaveAsync();
            return await Get(employee.Id);
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            if (employee == null)
                throw new EmployeeRegisterBadRequestException("Couldn't update an employee. The employee is not defined.");

            if (employee.Id <= 0)
                throw new EmployeeRegisterBadRequestException($"Couldn't update an employee with id:{employee.Id}. The id of the employee must greater than 0.");

            var oldEmployee = await _employeeRepository.GetAsync(employee.Id);
            
            if(oldEmployee == null)
                throw new EmployeeRegisterBadRequestException($"There is no existing employee with id:{employee.Id}.Couldn't update an employee with id:{employee.Id}.");

            oldEmployee.FirstName = employee.FirstName;
            oldEmployee.LastName = employee.LastName;
            oldEmployee.ManagerId = employee.ManagerId > 0 ? employee.ManagerId : null;
            oldEmployee.Birth = employee.Birth;
            oldEmployee.Department = employee.Department;

            await _employeeRepository.SaveAsync();
            return await Get(oldEmployee.Id);
        }

        public async Task DeleteEmployee(int id)
        {
            if (id <= 0)
                throw new EmployeeRegisterBadRequestException($"Couldn't delete an employee with id:{id}. The id of the employee must greater than 0.");

            var allEmployeeChildren = _employeeRepository.FindBy(x => x.ManagerId == id).ToList();
            foreach (var employee in allEmployeeChildren)
            {
                employee.ManagerId = null;
                await UpdateEmployee(employee);
            }

            await _employeeRepository.Delete(id);
            await _employeeRepository.SaveAsync();
        }
    }
}
