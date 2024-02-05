

using TaskManagementSystem.Core;
using TaskManagementSystem.Models.Enums;
using TaskManagementSystem.Models;
using TaskManagementSystem.Models.Enums.Statuses;

namespace TaskManagementSystem.Tests.RepositoryTests.Update
{
    [TestClass]
    public class UpdateStoryStatus
    {
        [TestMethod]
        public void UpdateStoryStatus_Should_Update_StatusOfAStory()
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

            // Act

            var newStatus = StoryStatus.Done;

            repository.UpdateStoryStatus(story, newStatus);

            //Assert

            Assert.AreEqual(newStatus, story.Status);
        }
    }
}
