using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model;
using SafeCity.Server.Db.Context;

namespace SafeCity.Server.Db.Repositories
{
    public class TypeAppealRepository : IRepository<AppealType>
    {
        private readonly AppDbContext _context;

        public TypeAppealRepository(AppDbContext context)
        {
            _context = context;
        }
        public AppealType Get(long id) => _context.TypeAppeal.FirstOrDefault(p => p.Key.Equals(id));

        public async Task<IEnumerable<AppealType>> GetEntities() => await Task.Run(()=> _context.TypeAppeal);

        public async Task Add(AppealType entity) => await Task.Run(() =>
        {
            if (entity is null)
                throw new ArgumentException("AppealType is null");
            _context.TypeAppeal.Add(entity);
        });

        public void Delete(AppealType entity)
        {
            if (entity is null)
                throw new ArgumentException("AppealType is null");
            _context.TypeAppeal.Remove(entity);
        }
    }
}