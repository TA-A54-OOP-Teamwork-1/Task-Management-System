using TaskManagementSystem.Core;
using TaskManagementSystem.Models;
using TaskManagementSystem.Models.Enums;

namespace TaskManagementSystem.Tests.RepositoryTests.Update
{
    [TestClass]
    public class UpdateBugPriorityTest
    {
        [TestMethod]
        public void UpdateBugPriority_Should_Update_PriorityOfABug()
        {
            // Arrange

            var repository = new Repository();

            var bug = new Bug(
                1,
                "SomeVeryLongTitle",
                "SomeDescription",
                Priority.Low,
                Severity.Critical,
                new[] { "stepOne", "stepTwo", "stepThree" }
            );

            var newPriority = Priority.Medium;

            // Act

            repository.UpdateBugPriority(bug, newPriority);

            // Assert

            Assert.AreEqual(newPriority, bug.Priority);
        }
    }
}
