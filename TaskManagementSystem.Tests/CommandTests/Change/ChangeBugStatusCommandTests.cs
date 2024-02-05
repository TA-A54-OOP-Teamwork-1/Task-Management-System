using TaskManagementSystem.Commands;
using TaskManagementSystem.Core;
using TaskManagementSystem.Exceptions;
using TaskManagementSystem.Models.Enums;

namespace TaskManagementSystem.Tests.CommandTests.Change
{
    [TestClass]
    public class ChangeBugStatusCommandTests
    {
        [TestMethod]
        public void ChangeBugStatusCommand_Should_Throw_When_InvalidArgumentsCountPassed()
        {
            //Arrange

            var repository = new Repository();

            var arguments = new List<string>()
            {
                "1",
                "Fixed",
                "SomeExtraArgument"
            };

            //Act

            var command = new ChangeBugStatusCommand(arguments, repository);

            //Assert

            Assert.ThrowsException<InvalidUserInputException>(command.Execute);
        }

        [TestMethod]
        public void ChangeBugStatusCommand_Should_Throw_When_InvalidIDValueTypePassed()
        {
            //Arrange

            var repository = new Repository();

            var arguments = new List<string>()
            {
                "a",
                "Fixed",
            };

            //Act

            var command = new ChangeBugStatusCommand(arguments, repository);

            //Assert

            Assert.ThrowsException<InvalidUserInputException>(command.Execute);
        }

        [TestMethod]
        public void ChangeBugStatusCommand_Should_Throw_When_InvalidStatusValuePassed()
        {
            //Arrange

            var repository = new Repository();

            var arguments = new List<string>()
            {
                "1",
                "InvalidStatus",
            };

            //Act

            var command = new ChangeBugStatusCommand(arguments, repository);

            //Assert

            Assert.ThrowsException<InvalidUserInputException>(command.Execute);
        }

        [TestMethod]
        public void ChangeBugStatusCommand_Should_Throw_When_NonExistentIDValuePassed()
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
                "Fixed",
            };

            //Act

            var command = new ChangeBugStatusCommand(arguments, repository);

            //Assert

            Assert.ThrowsException<EntityNotFoundException>(command.Execute);
        }


        [TestMethod]
        public void ChangeBugStatusCommand_Should_Throw_When_SameStatusValuePassed()
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
                "Active",
            };

            //Act

            var command = new ChangeBugStatusCommand(arguments, repository);

            //Assert

            Assert.ThrowsException<NotAllowedException>(command.Execute);
        }
    }
}
