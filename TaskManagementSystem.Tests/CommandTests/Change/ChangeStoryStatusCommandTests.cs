using TaskManagementSystem.Commands;
using TaskManagementSystem.Core;
using TaskManagementSystem.Exceptions;
using TaskManagementSystem.Models.Enums;

namespace TaskManagementSystem.Tests.CommandTests.Change
{
    [TestClass]
    public class ChangeStoryStatusCommandTests
    {
        [TestMethod]
        public void ChangeStoryStatusCommand_Should_Throw_When_InvalidArgumentsCountPassed()
        {
            //Arrange

            var repository = new Repository();

            var arguments = new List<string>()
            {
                "1",
                "InProgress",
                "SomeExtraArgument"
            };

            //Act

            var command = new ChangeStoryStatusCommand(arguments, repository);

            //Assert

            Assert.ThrowsException<InvalidUserInputException>(command.Execute);
        }

        [TestMethod]
        public void ChangeStoryStatusCommand_Should_Throw_When_InvalidIDValueTypePassed()
        {
            //Arrange

            var repository = new Repository();

            var arguments = new List<string>()
            {
                "a",
                "InProgress",
            };

            //Act

            var command = new ChangeStoryStatusCommand(arguments, repository);

            //Assert

            Assert.ThrowsException<InvalidUserInputException>(command.Execute);
        }

        [TestMethod]
        public void ChangeStoryStatusCommand_Should_Throw_When_InvalidStatusValuePassed()
        {
            //Arrange

            var repository = new Repository();

            var arguments = new List<string>()
            {
                "1",
                "InvalidStatus",
            };

            //Act

            var command = new ChangeStoryStatusCommand(arguments, repository);

            //Assert

            Assert.ThrowsException<InvalidUserInputException>(command.Execute);
        }

        [TestMethod]
        public void ChangeStoryStatusCommand_Should_Throw_When_NonExistentIDValuePassed()
        {
            //Arrange

            var repository = new Repository();

            repository.CreateStory(
                "SomeValidStoryTitle",
                "SomeDescription",
                Priority.Low,
                Size.Small);

            var arguments = new List<string>()
            {
                "2",
                "InProgress",
            };

            //Act

            var command = new ChangeStoryStatusCommand(arguments, repository);

            //Assert

            Assert.ThrowsException<EntityNotFoundException>(command.Execute);
        }


        [TestMethod]
        public void ChangeStoryStatusCommand_Should_Throw_When_SameStatusValuePassed()
        {
            //Arrange

            var repository = new Repository();

            repository.CreateStory(
                "SomeValidBugTitle",
                "SomeDescription",
                Priority.Low,
                Size.Small);

            var arguments = new List<string>()
            {
                "1",
                "NotDone",
            };

            //Act

            var command = new ChangeStoryStatusCommand(arguments, repository);

            //Assert

            Assert.ThrowsException<NotAllowedException>(command.Execute);
        }
    }
}

