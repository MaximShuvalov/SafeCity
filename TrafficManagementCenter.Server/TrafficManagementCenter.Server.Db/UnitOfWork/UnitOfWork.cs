using System;
using Microsoft.Extensions.DependencyInjection;
using Model;
using TrafficManagementCenter.Server.Db.Context;
using TrafficManagementCenter.Server.Db.Repositories;

namespace TrafficManagementCenter.Server.Db.UnitOfWork
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(IServiceProvider provider)
        {
            _context = provider.GetService<AppDbContext>();
        }
        
        public IRepository<T> GetRepositories<T>()
        {
            if (typeof(T) == typeof(Appeal))
                return new AppealRepository(_context) as IRepository<T>;
            else if (typeof(T) == typeof(TypeAppeal))
                return new TypeAppealRepository(_context) as IRepository<T>;
            else if (typeof(T) == typeof(SubtypeAppeal))
                return new SubtypeAppealRepository(_context) as IRepository<T>;
            else if (typeof(T) == typeof(AppealClass))
                return new ClassAppealsRepository(_context) as IRepository<T>;
            throw new Exception();
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        private bool _disposed = false;
        public void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                this._disposed = true;
            }
        }
 
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        
    }
}