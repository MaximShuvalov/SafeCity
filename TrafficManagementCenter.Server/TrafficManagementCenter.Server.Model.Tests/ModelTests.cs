using Model;
using NUnit.Framework;

namespace TrafficManagementCenter.Server.Model.Tests
{
    public class ModelTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CreateTypeAppealTest()
        {
            var typeAppeal = new TypeAppeal();
            typeAppeal.Key = 001;
            typeAppeal.Name = "Gibdd";
            typeAppeal.Note = "Проблемы, которые адресованы ГИБДД";
            Assert.Pass();
        }

        [Test]
        public void CreateSubtypeAppealTest()
        {
            var subtypeAppeal = new SubtypeAppeal();
            subtypeAppeal.Key = 0001;
            subtypeAppeal.Name = "Дорожные знаки";
            subtypeAppeal.Name = "Вопросы о нецелесообразности установленных знаков";
            subtypeAppeal.Type = new TypeAppeal();
            Assert.Pass();
        }
        
        [Test]
        public void CreateAppealTest()
        {
            var appeal = new Appeal();
            appeal.Key = 0001;
            appeal.Subtype = new SubtypeAppeal();
            appeal.Email = "test@test.ru";
            appeal.Text = "Прошу решить проблему";
            appeal.Attachment = "path/to/attachment";
            Assert.Pass();
        }
    }
}