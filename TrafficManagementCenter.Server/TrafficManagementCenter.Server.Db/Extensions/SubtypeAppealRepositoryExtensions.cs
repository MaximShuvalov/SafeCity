using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model;
using TrafficManagementCenter.Server.Db.Context;
using TrafficManagementCenter.Server.Db.Repositories;

namespace TrafficManagementCenter.Server.Db.Extensions
{
    public static class SubtypeAppealRepositoryExtensions
    {
        public static async Task<IEnumerable<SubtypeAppeal>> GetSubtypeByTypeAppealAsync(this SubtypeAppealRepository repos,
            string nameTypeAppeal)
        {
            var keyType = (await new TypeAppealRepository(new AppDbContext()).GetEntities())
                .FirstOrDefault(p => p.Name.Equals(nameTypeAppeal)).Key;
            return (await repos.GetEntities()).Where(l => l.TypesId.Equals(keyType));
        }  
    }
}