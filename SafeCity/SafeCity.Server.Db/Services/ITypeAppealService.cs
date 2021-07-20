using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Model;

namespace SafeCity.Server.Db.Services
{
    public interface ITypeAppealService
    {
        Task<AppealType> GetAsync(long id);

        Task<IEnumerable<AppealType>> GetAllAsync();
    }
}