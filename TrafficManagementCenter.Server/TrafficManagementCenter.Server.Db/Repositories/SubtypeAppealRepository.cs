using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Model;
using TrafficManagementCenter.Server.Db.Context;

namespace TrafficManagementCenter.Server.Db.Repositories
{
    public class SubtypeAppealRepository : IRepository<SubtypeAppeal>
    {
        private readonly AppDbContext _context;

        public SubtypeAppealRepository(AppDbContext context)
        {
            _context = context;
        }

        public SubtypeAppeal Get(long id) => _context.SubtypeAppeals.Include(p => p.Type)
            .FirstOrDefault(o => o.Key.Equals(id));

        public async Task<IEnumerable<SubtypeAppeal>> GetEntities() => await Task.Run(() =>
        {
            return _context.SubtypeAppeals.Include(p => p.Type);
        });

        public async Task Add(SubtypeAppeal entity) => await Task.Run(() =>
        {
            if (entity is null)
                throw new ArgumentException("SubtypeAppeal is null");
            _context.SubtypeAppeals.Add(entity);
        });

        public void Delete(SubtypeAppeal entity)
        {
            if (entity is null)
                throw new ArgumentException("SubtypeAppeal is null");
            _context.SubtypeAppeals.Remove(entity);
        }
    }
}