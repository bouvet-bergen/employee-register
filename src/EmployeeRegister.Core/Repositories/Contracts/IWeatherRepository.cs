using System.Threading.Tasks;

namespace EmployeeRegister.Core.Repositories.Contracts
{
    public interface IWeatherRepository
    {
        Task<double> GetCurrentWind();
    }
}
