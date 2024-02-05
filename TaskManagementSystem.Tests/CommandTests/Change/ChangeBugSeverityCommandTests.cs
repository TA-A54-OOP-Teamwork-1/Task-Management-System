using TaskManagementSystem.Commands;
using TaskManagementSystem.Core;
using TaskManagementSystem.Exceptions;
using TaskManagementSystem.Models.Enums;

namespace TaskManagementSystem.Tests.CommandTests.Change
{
    [TestClass]
    public class ChangeBugSeverityCommandTests
    {
        [TestMethod]
        public void ChangeBugSeverityCommand_Should_Throw_When_InvalidArgumentsCountPassed()
        {
            //Arrange

            var repository = new Repository();

            var arguments = new List<string>()
            {
                "1",
                "Critical",
                "SomeExtraArgument"
            };

            //Act

            var command = new ChangeBugSeverityCommand(arguments, repository);

            //Assert

            Assert.ThrowsException<InvalidUserInputException>(command.Execute);
        }

        [TestMethod]
        public void ChangeBugSeverityCommand_Should_Throw_When_InvalidIDValueTypePassed()
        {
            //Arrange

            var repository = new Repository();

            var arguments = new List<string>()
            {
                "a",
                "Critical",
            };

            //Act

            var command = new ChangeBugSeverityCommand(arguments, repository);

            //Assert

            Assert.ThrowsException<InvalidUserInputException>(command.Execute);
        }

        [TestMethod]
        public void ChangeBugSeverityCommand_Should_Throw_When_InvalidSeverityValuePassed()
        {
            //Arrange

            var repository = new Repository();

            var arguments = new List<string>()
            {
                "1",
                "InvalidSeverity",
            };

            //Act

            var command = new ChangeBugSeverityCommand(arguments, repository);

            //Assert

            Assert.ThrowsException<InvalidUserInputException>(command.Execute);
        }

        [TestMethod]
        public void ChangeBugSeverityCommand_Should_Throw_When_NonExistentIDValuePassed()
        {
            //Arrange

            var repository = new Repository();

            repository.CreateBug(
                "SomeValidBugTitle",
                "SomeDescription",
                Priority.Low,
                Severity.Critical,
                new[] { "stepOne", "stepTwo", "stepThree" });

            var arguments = new List<string>()
            {
                "2",
                "Major",
            };

            //Act

            var command = new ChangeBugSeverityCommand(arguments, repository);

            //Assert

            Assert.ThrowsException<EntityNotFoundException>(command.Execute);
        }


        [TestMethod]
        public void ChangeBugSeverityCommand_Should_Throw_When_SameSeverityValuePassed()
        {
            //Arrange

            var repository = new Repository();

            repository.CreateBug(
                "SomeValidBugTitle",
                "SomeDescription",
                Priority.Low,
                Severity.Critical,
                new[] { "stepOne", "stepTwo", "stepThree" });

            var arguments = new List<string>()
            {
                "1",
                "Critical",
            };

            //Act

            var command = new ChangeBugSeverityCommand(arguments, repository);

            //Assert

            Assert.ThrowsException<NotAllowedException>(command.Execute);
        }
    }
}
