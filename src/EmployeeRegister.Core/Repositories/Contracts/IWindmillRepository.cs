using System.Collections.Generic;
using System.Threading.Tasks;
using EmployeeRegister.Core.Models;

namespace EmployeeRegister.Core.Repositories.Contracts
{
    public interface IWindmillRepository
    {
        Task<IEnumerable<Windmill>> GetAll(string groupId, string groupKey);
        Task ChangeIsActivated(string groupId, string groupKey, string windMillId, bool isActivated);
    }
}
