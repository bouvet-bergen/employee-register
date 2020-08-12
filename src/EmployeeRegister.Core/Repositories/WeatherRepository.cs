using System.Threading.Tasks;
using EmployeeRegister.Core.Models;
using EmployeeRegister.Core.Repositories.Contracts;

namespace EmployeeRegister.Core.Repositories
{
    public class WeatherRepository : IWeatherRepository
    {
        private readonly WebClient _webClient;

        public WeatherRepository()
        {
            _webClient = new WebClient();
        }

        public async Task<double> GetCurrentWind()
        {
            return await _webClient.GetStructAsync<double>("Weather");
        }
    }
}
