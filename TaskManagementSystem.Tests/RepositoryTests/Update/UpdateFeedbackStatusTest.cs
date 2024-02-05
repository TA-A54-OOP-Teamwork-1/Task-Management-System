using TaskManagementSystem.Core;
using TaskManagementSystem.Models;
using TaskManagementSystem.Models.Enums.Statuses;

namespace TaskManagementSystem.Tests.RepositoryTests.Update
{
    [TestClass]
    public class UpdateFeedbackStatus
    {
        [TestMethod]
        public void UpdateFeedbackStatus_Should_Update_StatusOfAFeedback()
        {
            // Arrange

            var repository = new Repository();

            var feedback = new Feedback(
                1,
                "SomeVeryLongTitle",
                "SomeDescription",
                4
            );

            // Act

            var newStatus = FeedbackStatus.Scheduled;

            repository.UpdateFeedbackStatus(feedback, newStatus);

            //Assert

            Assert.AreEqual(newStatus, feedback.Status);
        }
    }
}
