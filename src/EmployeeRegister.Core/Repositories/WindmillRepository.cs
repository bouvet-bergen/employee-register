using System.Collections.Generic;
using System.Threading.Tasks;
using EmployeeRegister.Core.Models;
using EmployeeRegister.Core.Repositories.Contracts;

namespace EmployeeRegister.Core.Repositories
{
    public class WindmillRepository : IWindmillRepository
    {
        private readonly WebClient _webClient;

        public WindmillRepository()
        {
            _webClient = new WebClient();
        }

        public async Task<IEnumerable<Windmill>> GetAll(string groupId, string groupKey)
        {
            var headers = new Dictionary<string, string> { { "GroupId", groupId }, { "GroupKey", groupKey } };
            return await _webClient.GetAsync<List<Windmill>>("Windmills", headers);
        }

        public async Task ChangeIsActivated(string groupId, string groupKey, string windMillId, bool isActivated)
        {
            var headers = new Dictionary<string, string> { { "GroupId", groupId }, { "GroupKey", groupKey } };
            var queryParams = new Dictionary<string, string> { { "activated", isActivated.ToString().ToLower() } };
            await _webClient.PutAsync($"Windmills/{windMillId}", headers, queryParams);
        }
    }
}
