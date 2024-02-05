using TaskManagementSystem.Core;
using TaskManagementSystem.Models.Enums;
using TaskManagementSystem.Models;
using TaskManagementSystem.Models.Enums.Statuses;

namespace TaskManagementSystem.Tests.RepositoryTests.Update
{
    [TestClass]
    public class UpdateBugStatusTest
    {
        [TestMethod]
        public void UpdateBugStatus_Should_Update_StatusOfABug()
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

            var newStatus = BugStatus.Fixed;

            // Act

            repository.UpdateBugStatus(bug, newStatus);

            // Assert

            Assert.AreEqual(newStatus, bug.Status);
        }
    }
}
