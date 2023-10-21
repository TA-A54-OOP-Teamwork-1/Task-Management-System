using TaskManagementSystem.Core;
using TaskManagementSystem.Models.Enums;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.Tests.RepositoryTests.Update
{
    [TestClass]
    public class UpdateStorySizeTest
    {
        [TestMethod]
        public void UpdateStorySize_Should_Update_SizeOfAStory()
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

            var newSize = Size.Large;

            // Act

            repository.UpdateStorySize(story, newSize);

            // Assert

            Assert.AreEqual(newSize, story.Size);
        }
    }
}
