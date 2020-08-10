using EmployeeRegister.Core.Models;
using EmployeeRegister.Core.Repositories;
using EmployeeRegister.Core.Repositories.Contracts;
using EmployeeRegister.Core.Services;
using EmployeeRegister.Core.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeRegister.Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddEmployeeRegisterModule(this IServiceCollection serviceCollection, string connectionString)
        {
            // Entity framework
            serviceCollection.AddDbContext<EmployeeRegisterDatabaseContext>(options =>
                options.UseSqlServer(connectionString, sqlOptions =>
                    sqlOptions.MigrationsAssembly("EmployeeRegister.Core")));

            // Dependency Injection
            serviceCollection.AddScoped<IEmployeeRepository, EmployeeDatabaseRepository>();
            serviceCollection.AddScoped<IEmployeeService, EmployeeService>();
            
            return serviceCollection;
        }
    }
}
