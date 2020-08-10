using EmployeeRegister.Core.Models;

namespace EmployeeRegister.Core.Repositories.Contracts
{
    public interface IEmployeeRepository : IGenericRepository<EmployeeRegisterDatabaseContext, Employee>
    {
    }
}
