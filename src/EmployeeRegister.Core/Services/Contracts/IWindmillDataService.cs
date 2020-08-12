using System.Collections.Generic;
using System.Threading.Tasks;
using EmployeeRegister.Core.Models;

namespace EmployeeRegister.Core.Services.Contracts
{
    public interface IWindmillDataService
    {
        Task<double> GetCurrentWind();
        Task<decimal> GetCurrentPowerPrice();
        Task<List<Windmill>> GetAllWindmills(string groupId, string groupKey);
        Task ChangeWindmillIsActivated(string groupId, string groupKey, string windMillId, bool isActivated);
    }
}
