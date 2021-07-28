using System.Collections.Generic;
using System.Threading.Tasks;
using Model;

namespace SafeCity.Server.Db.Services
{
    public interface ISubtypeAppealService
    {
        public Task<IEnumerable<AppealSubtype>> GetAllAsync();
        public Task<IEnumerable<AppealSubtype>> GetSubtypeByTypeAppealAsync(string nameTypeAppeal);
    }
}