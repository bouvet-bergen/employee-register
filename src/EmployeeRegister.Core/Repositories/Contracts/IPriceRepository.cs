using System.Threading.Tasks;

namespace EmployeeRegister.Core.Repositories.Contracts
{
    public interface IPriceRepository
    {
        Task<decimal> GetCurrentPowerPrice();
    }
}
