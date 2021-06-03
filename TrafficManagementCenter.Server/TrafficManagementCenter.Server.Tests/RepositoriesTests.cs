using NUnit.Framework;
using TrafficManagementCenter.Server.Db.Context;
using TrafficManagementCenter.Server.Db.Repositories;

namespace TrafficManagementCenter.Server.Tests
{
    public class RepositoriesTests
    {
        [Test]
        public void GetAppealByIdTest()
        {
            var appealRepository = new AppealRepository(new AppDbContext());
        }
    }
}