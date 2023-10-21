using TaskManagementSystem.Core;
using TaskManagementSystem.Models.Enums;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.Tests.RepositoryTests.Update
{
    [TestClass]
    public class UpdateStoryPriorityTest
    {
        [TestMethod]
        public void UpdateStoryPriority_Should_Update_PriorityOfAStory()
        {
            // Arrange

            var repository = new Repository();

            var story = new Story(
                1,
                "SomeVeryLongTitle",
                "SomeDescription",
                Priority.Low,
                Size.Medium
            );

            var newPriority = Priority.High;

            // Act

            repository.UpdateStoryPriority(story, newPriority);

            // Assert

            Assert.AreEqual(newPriority, story.Priority);
        }
    }
}
