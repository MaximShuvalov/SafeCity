using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model;
using TrafficManagementCenter.Server.Db.Context;
using TrafficManagementCenter.Server.Db.Factory;
using TrafficManagementCenter.Server.Db.Repositories;
using TrafficManagementCenter.Server.Db.UnitOfWork;

namespace TrafficManagementCenter.Server.Db.Extensions
{
    public static class AppealRepositoryExtensions
    {
        public static async Task<long> GetIdByEmailAndTextAsync(this AppealRepository repos, string email, string text)
        {
            var entities = await repos.GetEntities();
            return entities.FirstOrDefault(p
                => p.Email.Equals(email) && p.Text.Equals(text)).Key;
        }

        public static async Task<IEnumerable<Appeal>> GetEntitiesByEmail(this AppealRepository repository, string email)
        {
            if (string.IsNullOrEmpty(email))
                throw new ArgumentException($"Error receiving appeals email = {email}");
            var appeals = await repository.GetEntities();
            return appeals.Where(p => p.Email.Equals(email));
        }
    }
}