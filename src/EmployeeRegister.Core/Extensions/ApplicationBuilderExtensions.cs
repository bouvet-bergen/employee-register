using EmployeeRegister.Core.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeRegister.Core.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static void UseEmployeeRegisterModule(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<EmployeeRegisterDatabaseContext>();
                context.Database.Migrate();
            }
        }
    }
}
