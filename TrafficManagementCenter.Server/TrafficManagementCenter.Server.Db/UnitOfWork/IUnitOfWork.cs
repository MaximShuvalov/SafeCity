using System;
using TrafficManagementCenter.Server.Db.Repositories;

namespace TrafficManagementCenter.Server.Db.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        public void Commit();
        public IRepository<T> GetRepositories<T>();
    }
}