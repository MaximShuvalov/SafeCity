using System.Collections.Generic;
using System.Threading.Tasks;
using Model;

namespace SafeCity.Server.Db.Services
{
    public interface IAppealService
    {
        Task<IEnumerable<Appeal>> GetAllAsync();
        Task<Appeal> Add(Appeal appeal, string nameSubtypeAppeal);
    }
}