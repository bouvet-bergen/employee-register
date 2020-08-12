using System;
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
        public const double MinWindSpeedForPowerProduction = 3.0;
        public const double MaxWindSpeedForPowerProduction = 25.0;
        public const double EfficiencyIncreaseThreshold = 12.0;
        public const double PowerProducedPerWindSpeed = 0.4;
        public const decimal MaintenanceCostFlat = 283.0m;
        public const decimal MaintenanceCostPerWindSpeed = 76.0m;

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

        public async Task ChangeWindmillIsActivated(string groupId, string groupKey, string windMillId, bool isActivated)
        {

            await _windmillRepository.ChangeIsActivated(groupId, groupKey, windMillId, isActivated);
        }

        public Task<decimal> CalculateProfit(double windSpeed, decimal powerPrice)
        {
            if (windSpeed < MinWindSpeedForPowerProduction || windSpeed > MaxWindSpeedForPowerProduction)
                return Task.FromResult(0.0m);

            var powerProduced = PowerProducedPerWindSpeed * Math.Min(windSpeed, EfficiencyIncreaseThreshold);
            var income = (decimal)powerProduced * powerPrice;
            var expenses = MaintenanceCostPerWindSpeed * (decimal)windSpeed + MaintenanceCostFlat;
            return Task.FromResult(income - expenses);
        }
    }
}
