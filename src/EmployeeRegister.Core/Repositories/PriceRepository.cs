using System.Threading.Tasks;
using EmployeeRegister.Core.Models;
using EmployeeRegister.Core.Repositories.Contracts;

namespace EmployeeRegister.Core.Repositories
{
    public class PriceRepository : IPriceRepository
    {
        private readonly WebClient _webClient;

        public PriceRepository()
        {
            _webClient = new WebClient();
        }

        public async Task<decimal> GetCurrentPowerPrice()
        {
            return await _webClient.GetStructAsync<decimal>("PowerPrice");
        }
    }
}
