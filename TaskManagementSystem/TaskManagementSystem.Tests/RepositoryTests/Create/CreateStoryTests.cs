using TaskManagementSystem.Core.Contracts;
using TaskManagementSystem.Core;
using TaskManagementSystem.Models.Contracts;
using TaskManagementSystem.Models.Enums;

namespace TaskManagementSystem.Tests.RepositoryTests.Create
{
    [TestClass]
    public class CreateStoryTests
    {
        /**
         *  Null title, null description and ranges testing is done in the "CreateBoardTests.cs"
         */
        
        private const string ValidTitle = "TestStoryTitle";
        private const string ValidDescription = "ValidDescription";

        private IRepository repository;

        [TestInitialize]
        public void Initialize()
        {
            repository = new Repository();
        }

        private IStory CreateStoryThroughRepository(string title = ValidTitle, string description = ValidDescription)
        {
            Priority priority = Priority.Medium;
            Size size = Size.Small;
            return repository.CreateStory(title, description, priority, size);
        }


        [TestMethod]
        public void Execute_Should_CreateNewStory()
        {
            // Arrange, Act
            IStory story = CreateStoryThroughRepository();

            // Assert
            Assert.AreEqual(story.Title, ValidTitle);
            Assert.AreEqual(story.Description, ValidDescription);
        }
    }
}
