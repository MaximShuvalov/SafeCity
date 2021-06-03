using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model;
using TrafficManagementCenter.Server.Db.Context;

namespace TrafficManagementCenter.Server.Db.Repositories
{
    public class TypeAppealRepository : IRepository<TypeAppeal>
    {
        private readonly AppDbContext _context;

        public TypeAppealRepository(AppDbContext context)
        {
            _context = context;
        }
        public TypeAppeal Get(long id) => _context.TypeAppeal.FirstOrDefault(p => p.Key.Equals(id));

        public async Task<IEnumerable<TypeAppeal>> GetEntities() => await Task.Run(()=> _context.TypeAppeal);

        public async Task Add(TypeAppeal entity) => await Task.Run(() =>
        {
            if (entity is null)
                throw new ArgumentException("TypeAppeal is null");
            _context.TypeAppeal.Add(entity);
        });

        public void Delete(TypeAppeal entity)
        {
            if (entity is null)
                throw new ArgumentException("TypeAppeal is null");
            _context.TypeAppeal.Remove(entity);
        }
    }
}