using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Model;
using SafeCity.Server.Db.Context;

namespace SafeCity.Server.Db.Repositories
{
    public class SubtypeAppealRepository : IRepository<AppealSubtype>
    {
        private readonly AppDbContext _context;

        public SubtypeAppealRepository(AppDbContext context)
        {
            _context = context;
        }

        public AppealSubtype Get(long id) => _context.SubtypeAppeals.Include(p => p.AppealType)
            .FirstOrDefault(o => o.Key.Equals(id));

        public async Task<IEnumerable<AppealSubtype>> GetEntities() => await Task.Run(() =>
        {
            return _context.SubtypeAppeals.Include(p => p.AppealType);
        });

        public async Task Add(AppealSubtype entity) => await Task.Run(() =>
        {
            if (entity is null)
                throw new ArgumentException("AppealSubtype is null");
            _context.SubtypeAppeals.Add(entity);
        });

        public void Delete(AppealSubtype entity)
        {
            if (entity is null)
                throw new ArgumentException("AppealSubtype is null");
            _context.SubtypeAppeals.Remove(entity);
        }
    }
}