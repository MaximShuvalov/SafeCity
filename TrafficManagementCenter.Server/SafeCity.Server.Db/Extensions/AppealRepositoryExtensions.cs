using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model;
using SafeCity.Server.Db.Repositories;
using SafeCity.Server.Db.Context;
using SafeCity.Server.Db.Factory;
using SafeCity.Server.Db.UnitOfWork;

namespace SafeCity.Server.Db.Extensions
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