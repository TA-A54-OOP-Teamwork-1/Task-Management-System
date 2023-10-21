using TaskManagementSystem.Commands;
using TaskManagementSystem.Core;
using TaskManagementSystem.Exceptions;
using TaskManagementSystem.Models.Enums;

namespace TaskManagementSystem.Tests.CommandTests.Change
{
    [TestClass]
    public class ChangeStoryPriorityCommandTests
    {
        [TestMethod]
        public void ChangeStoryPriorityCommand_Should_Throw_When_InvalidArgumentsCountPassed()
        {
            //Arrange

            var repository = new Repository();

            var arguments = new List<string>()
            {
                "1",
                "Medium",
                "SomeExtraArgument"
            };

            //Act

            var command = new ChangeStoryPriorityCommand(arguments, repository);

            //Assert

            Assert.ThrowsException<InvalidUserInputException>(command.Execute);
        }

        [TestMethod]
        public void ChangeStoryPriorityCommand_Should_Throw_When_InvalidIDValueTypePassed()
        {
            //Arrange

            var repository = new Repository();

            var arguments = new List<string>()
            {
                "a",
                "Medium",
            };

            //Act

            var command = new ChangeStoryPriorityCommand(arguments, repository);

            //Assert

            Assert.ThrowsException<InvalidUserInputException>(command.Execute);
        }

        [TestMethod]
        public void ChangeStoryPriorityCommand_Should_Throw_When_InvalidPriorityValuePassed()
        {
            //Arrange

            var repository = new Repository();

            var arguments = new List<string>()
            {
                "1",
                "InvalidPriority",
            };

            //Act

            var command = new ChangeStoryPriorityCommand(arguments, repository);

            //Assert

            Assert.ThrowsException<InvalidUserInputException>(command.Execute);
        }

        [TestMethod]
        public void ChangeStoryPriorityCommand_Should_Throw_When_NonExistentIDValuePassed()
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
                "Low",
            };

            //Act

            var command = new ChangeStoryPriorityCommand(arguments, repository);

            //Assert

            Assert.ThrowsException<EntityNotFoundException>(command.Execute);
        }


        [TestMethod]
        public void ChangeStoryPriorityCommand_Should_Throw_When_SamePriorityValuePassed()
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
                "Low",
            };

            //Act

            var command = new ChangeStoryPriorityCommand(arguments, repository);

            //Assert

            Assert.ThrowsException<NotAllowedException>(command.Execute);
        }
    }
}

