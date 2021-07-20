using Microsoft.Extensions.DependencyInjection;
using Model;
using SafeCity.Server.Db.UnitOfWork;
using SafeCity.Server.Db.Repositories;
using SafeCity.Server.Db.Services;

namespace SafeCity.Server.Db.DI
{
    public static class DependencyInjection
    {
        public static void AddDb(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
            services.AddTransient<ITypeAppealService, TypeAppealService>();
        }
    }
}