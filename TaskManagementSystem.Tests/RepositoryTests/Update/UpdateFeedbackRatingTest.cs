using TaskManagementSystem.Core;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.Tests.RepositoryTests.Update
{
    [TestClass]
    public class UpdateFeedbackRating
    {
        [TestMethod]
        public void UpdateFeedbackRating_Should_Update_RatingOfAFeedback()
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

            var newRating = 2;

            repository.UpdateFeedbackRating(feedback, newRating);

            //Assert

            Assert.AreEqual(newRating, feedback.Rating);
        }
    }
}
