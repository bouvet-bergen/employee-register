using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeRegister.Core.Models;
using EmployeeRegister.Core.Repositories.Contracts;
using EmployeeRegister.Core.Services.Contracts;

namespace EmployeeRegister.Core.Services
{
    public class WindmillDataService : IWindmillDataService
    {
        private readonly IWeatherRepository _weatherRepository;
        private readonly IPriceRepository _priceRepository;
        private readonly IWindmillRepository _windmillRepository;

        public WindmillDataService(IWeatherRepository weatherRepository, IPriceRepository priceRepository, IWindmillRepository windmillRepository)
        {
            _weatherRepository = weatherRepository;
            _priceRepository = priceRepository;
            _windmillRepository = windmillRepository;
        }

        public async Task<double> GetCurrentWind()
        {
            return await _weatherRepository.GetCurrentWind();
        }

        public async Task<decimal> GetCurrentPowerPrice()
        {
            return await _priceRepository.GetCurrentPowerPrice();
        }

        public async Task<List<Windmill>> GetAllWindmills(string groupId, string groupKey)
        {
            var windmills = await _windmillRepository.GetAll(groupId, groupKey);
            return windmills.ToList();
        }

        public async Task ChangeWindmillIsActivated(string groupId, string groupKey, string windMillId, bool isActivated) {
            
            await _windmillRepository.ChangeIsActivated(groupId, groupKey, windMillId, isActivated);
        }
    }
}
