using EmployeeRegister.Core.Models;
using EmployeeRegister.Core.Repositories.Contracts;

namespace EmployeeRegister.Core.Repositories
{
    public class EmployeeDatabaseRepository : GenericRepository<EmployeeRegisterDatabaseContext, Employee>, IEmployeeRepository
    {
        public EmployeeDatabaseRepository(EmployeeRegisterDatabaseContext dbContext) : base(dbContext)
        {
        }
    }
}
