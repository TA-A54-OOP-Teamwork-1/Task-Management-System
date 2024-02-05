using TaskManagementSystem.Core;
using TaskManagementSystem.Models.Enums;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.Tests.RepositoryTests.Update
{
    [TestClass]
    public class UpdateBugSeverityTest
    {
        [TestMethod]
        public void UpdateBugSeverity_Should_Update_SeverityOfABug()
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

            var newSeverity = Severity.Major;

            // Act

            repository.UpdateBugSeverity(bug, newSeverity);

            // Assert

            Assert.AreEqual(newSeverity, bug.Severity);
        }
    }
}
