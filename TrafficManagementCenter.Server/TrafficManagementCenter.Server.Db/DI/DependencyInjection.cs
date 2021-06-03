using Microsoft.Extensions.DependencyInjection;
using Model;
using TrafficManagementCenter.Server.Db.Repositories;
using TrafficManagementCenter.Server.Db.UnitOfWork;

namespace TrafficManagementCenter.Server.Db.DI
{
    public static class DependencyInjection
    {
        public static void AddDb(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
        }
    }
}