using System;
using SafeCity.Server.Db.Repositories;

namespace SafeCity.Server.Db.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        public void Commit();
        public IRepository<T> GetRepositories<T>();
    }
}