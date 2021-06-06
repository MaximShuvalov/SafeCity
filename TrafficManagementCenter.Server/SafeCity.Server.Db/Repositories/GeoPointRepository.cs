using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Model;
using SafeCity.Server.Db.Context;
using SafeCity.Server.Db.Factory;

namespace SafeCity.Server.Db.Repositories
{
    public class GeoPointRepository : IRepository<GeoPoint>
    {
        private readonly AppDbContext _context;

        public GeoPointRepository(AppDbContext context)
        {
            _context = context;
        }

        public GeoPoint Get(long id) => _context.GeoPoint.FirstOrDefault(p => p.Key.Equals(id));

        public async Task<IEnumerable<GeoPoint>> GetEntities() => await Task.Run(() => _context.GeoPoint);

        public async Task Add(GeoPoint entity) => await Task.Run(() =>
        {
            if (entity is null)
                throw new ArgumentException("Appeal is null");
            _context.GeoPoint.Add(entity);
        });

        public void Delete(GeoPoint entity)
        {
            if (entity is null)
                throw new ArgumentException("GeoPoint is null");
            _context.GeoPoint.Remove(entity);
        }
    }
}