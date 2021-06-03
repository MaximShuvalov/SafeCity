using System;
using Model;
using TrafficManagementCenter.Server.Db.Context;
using TrafficManagementCenter.Server.Db.Repositories;

namespace TrafficManagementCenter.Server.Db.Factory
{
    // Фабрика репозиториев. Позволяет инкапсулировать создание экземпляров репозиториев.
    // Таким образом, конкретная реализация интерфейса репозитория создаётся в одном месте
    // и может быть легко подменена на другую.
    public static class RepositoryFactory<T>
    {
        public static IRepository<T> Create(AppDbContext context)
        {
            if (typeof(T) == typeof(Appeal))
                return new AppealRepository(context) as IRepository<T>;
            else if (typeof(T) == typeof(TypeAppeal))
                return new TypeAppealRepository(context) as IRepository<T>;
            else if (typeof(T) == typeof(SubtypeAppeal))
                return new SubtypeAppealRepository(context) as IRepository<T>;
            else if (typeof(T) == typeof(AppealClass))
                return new ClassAppealsRepository(context) as IRepository<T>;
            throw new Exception();
        }
    }
    //todo mshuvalov: подумать на статиком, возможно, стоит вынести в di
}