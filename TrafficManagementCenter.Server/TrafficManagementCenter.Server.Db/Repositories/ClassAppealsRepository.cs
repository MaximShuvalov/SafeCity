using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model;
using TrafficManagementCenter.Server.Db.Context;

namespace TrafficManagementCenter.Server.Db.Repositories
{
    public class ClassAppealsRepository : IRepository<AppealClass>
    {
        private readonly AppDbContext _context;

        public ClassAppealsRepository(AppDbContext context)
        {
            _context = context;
        }

        public AppealClass Get(long id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<AppealClass>> GetEntities() => await Task.Run(() => _context.ClassAppeal);

        public async Task Add(AppealClass entity) => await Task.Run(() =>
        {
            if (entity is null)
                throw new ArgumentException("AppealClass is null");
            if (_context.ClassAppeal.Contains(entity))
                return;
            _context.ClassAppeal.Add(entity);
        });

        public void Delete(AppealClass entity)
        {
            if (entity is null)
                throw new ArgumentException("AppealClass is null");
            _context.ClassAppeal.Remove(entity);
        }
    }
}