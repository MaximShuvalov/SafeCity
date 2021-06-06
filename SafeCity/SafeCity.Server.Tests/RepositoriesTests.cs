using NUnit.Framework;
using SafeCity.Server.Db.Context;
using SafeCity.Server.Db.Repositories;

namespace SafeCity.Server.Tests
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