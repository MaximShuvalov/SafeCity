using System.Linq;
using Model;
using NUnit.Framework;
using TrafficManagementCenter.Server.Db.Context;
using TrafficManagementCenter.Server.Db.Extensions;
using TrafficManagementCenter.Server.Db.Factory;
using TrafficManagementCenter.Server.Db.Repositories;

namespace TrafficManagementCenter.Server.Db.Tests
{
    public class DbTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [Explicit("Интеграционный")]
        public void AddSubtypeAppealTest()
        {
            var subtype = new SubtypeAppeal()
            {
                Name = "TestSubtype",
                Note = "Subtype create only test"
            };
            var repos = new SubtypeAppealRepository(new AppDbContext());
            repos.Add(subtype);
            repos.Delete(subtype);

            Assert.Pass();
        }

        [Test]
        [Explicit("Интеграционный")]
        public void AddTypeAppealTest()
        {
            var type = new TypeAppeal()
            {
                Name = "TestType",
                Note = "Type create only test"
            };
            var repos = new TypeAppealRepository(new AppDbContext());
            repos.Add(type);
            repos.Delete(type);

            Assert.Pass();
        }

        [Test]
        [Explicit("Интеграционный")]
        public async void GetAllAppealTest()
        {
            var appeal = new Appeal()
            {
                Email = "test@test.com"
            };

            var appeal1 = new Appeal()
            {
                Email = "test1@test.com"
            };

            var repos = new AppealRepository(new AppDbContext());

            repos.Add(appeal);
            repos.Add(appeal1);

            var appeals = await repos.GetEntities();

            Assert.IsTrue(appeals.ToList().Count() > 0);

            repos.Delete(appeal);
            repos.Delete(appeal1);
        }

        [Test]
        [Explicit("Интеграционный")]
        public void AddAppealTest()
        {
            var appeal = new Appeal()
            {
                Email = "test@test.com"
            };
            
            var appeal2 = new Appeal()
            {
                Email = "test2@test.com"
            };

            var repos1 = RepositoryFactory<Appeal>.Create(new AppDbContext());

            ((AppealRepository)repos1).Add(appeal, "Замечание", "TestSubtype");
            ((AppealRepository)repos1).Add(appeal2, "Замечание", "TestSubtype");
            repos1.Delete(appeal);
            repos1.Delete(appeal2);


            Assert.Pass();
        }

        [Test]
        [Explicit("Интеграционный")]
        public async void GetAppealByIdTest()
        {
            var appeal = new Appeal()
            {
                Email = "test@test.com",
                Text = "Этот текст для теста"
            };

            var repos1 = new AppealRepository(new AppDbContext());

            repos1.Add(appeal);
            var keyAppeal = await repos1.GetIdByEmailAndTextAsync(appeal.Email, appeal.Text);
            var appealFromDb = repos1.Get(keyAppeal);
            Assert.AreEqual(appeal.Email, appealFromDb.Email);
            repos1.Delete(appeal);
        }
        
        [Test]
        [Explicit("Интеграционный")]
        public async void GetAllAppealByEmailTest()
        {
            var appeal = new Appeal()
            {
                Email = "test@test.com",
                Text = "Text1"
            };

            var appeal1 = new Appeal()
            {
                Email = "test@test.com",
                Text = "Text2"
            };

            var repos = new AppealRepository(new AppDbContext());

            repos.Add(appeal);
            repos.Add(appeal1);

            var appeals = await repos.GetEntitiesByEmail("test@test.com");

            Assert.IsTrue(appeals.ToList().Count() > 1);

            repos.Delete(appeal);
            repos.Delete(appeal1);
        }
        
        [Test]
        [Explicit("Интеграционный")]
        public async void GetAllClassAppealsTest()
        {
            var classAppeal = new AppealClass()
            {
                Name = "Замечание"
            };

            var repos = RepositoryFactory<AppealClass>.Create(new AppDbContext());
            
            repos.Add(classAppeal);
            
            Assert.True((await repos.GetEntities()).Any());
            
            repos.Delete(classAppeal);
        }
        
        [Test]
        [Explicit("Интеграционный")]
        public void GetAppealTest()
        {
            var appeal2 = new Appeal()
            {
                Key = 1217,
                Email = "test2@test.com"
            };

            var repos1 = RepositoryFactory<Appeal>.Create(new AppDbContext());

            ((AppealRepository)repos1).Add(appeal2, "Замечание", "TestSubtype");

            var receivedAppeal = repos1.Get(appeal2.Key);
            
            Assert.True(receivedAppeal.Key.Equals(appeal2.Key));
            Assert.True(receivedAppeal.Email.Equals(appeal2.Email));
            Assert.True(receivedAppeal.Subtype.Name.Equals(appeal2.Subtype.Name));
            Assert.True(receivedAppeal.AppealClass.Name.Equals(appeal2.AppealClass.Name));

            repos1.Delete(appeal2);
        }
    }
}