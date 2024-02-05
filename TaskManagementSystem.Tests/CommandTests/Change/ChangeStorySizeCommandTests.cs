using TaskManagementSystem.Commands;
using TaskManagementSystem.Core;
using TaskManagementSystem.Exceptions;
using TaskManagementSystem.Models.Enums;

namespace TaskManagementSystem.Tests.CommandTests.Change
{
    [TestClass]
    public class ChangeStorySizeCommandTests
    {
        [TestMethod]
        public void ChangeStorySizeCommand_Should_Throw_When_InvalidArgumentsCountPassed()
        {
            //Arrange

            var repository = new Repository();

            var arguments = new List<string>()
            {
                "1",
                "Small",
                "SomeExtraArgument"
            };

            //Act

            var command = new ChangeStorySizeCommand(arguments, repository);

            //Assert

            Assert.ThrowsException<InvalidUserInputException>(command.Execute);
        }

        [TestMethod]
        public void ChangeStorySizeCommand_Should_Throw_When_InvalidIDValueTypePassed()
        {
            //Arrange

            var repository = new Repository();

            var arguments = new List<string>()
            {
                "a",
                "Small",
            };

            //Act

            var command = new ChangeStorySizeCommand(arguments, repository);

            //Assert

            Assert.ThrowsException<InvalidUserInputException>(command.Execute);
        }

        [TestMethod]
        public void ChangeStorySizeCommand_Should_Throw_When_InvalidSizeValuePassed()
        {
            //Arrange

            var repository = new Repository();

            var arguments = new List<string>()
            {
                "1",
                "InvalidSize",
            };

            //Act

            var command = new ChangeStorySizeCommand(arguments, repository);

            //Assert

            Assert.ThrowsException<InvalidUserInputException>(command.Execute);
        }

        [TestMethod]
        public void ChangeStorySizeCommand_Should_Throw_When_NonExistentIDValuePassed()
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
                "Large",
            };

            //Act

            var command = new ChangeStorySizeCommand(arguments, repository);

            //Assert

            Assert.ThrowsException<EntityNotFoundException>(command.Execute);
        }


        [TestMethod]
        public void ChangeStorySizeCommand_Should_Throw_When_SameSizeValuePassed()
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
                "Small",
            };

            //Act

            var command = new ChangeStorySizeCommand(arguments, repository);

            //Assert

            Assert.ThrowsException<NotAllowedException>(command.Execute);
        }
    }
}

