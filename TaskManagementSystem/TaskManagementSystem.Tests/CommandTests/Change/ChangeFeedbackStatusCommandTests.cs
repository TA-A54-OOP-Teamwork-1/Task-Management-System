using TaskManagementSystem.Commands;
using TaskManagementSystem.Core;
using TaskManagementSystem.Exceptions;

namespace TaskManagementSystem.Tests.CommandTests.Change
{
    [TestClass]
    public class ChangeFeedbackStatusCommandTests
    {
        [TestMethod]
        public void ChangeFeedbackStatusCommand_Should_Throw_When_InvalidArgumentsCountPassed()
        {
            //Arrange

            var repository = new Repository();

            var arguments = new List<string>()
            {
                "1",
                "4",
                "SomeExtraArgument"
            };

            //Act

            var command = new ChangeFeedbackStatusCommand(arguments, repository);

            //Assert

            Assert.ThrowsException<InvalidUserInputException>(command.Execute);
        }

        [TestMethod]
        public void ChangeFeedbackStatusCommand_Should_Throw_When_InvalidIDValueTypePassed()
        {
            //Arrange

            var repository = new Repository();

            var arguments = new List<string>()
            {
                "a",
                "4",
            };

            //Act

            var command = new ChangeFeedbackStatusCommand(arguments, repository);

            //Assert

            Assert.ThrowsException<InvalidUserInputException>(command.Execute);
        }

        [TestMethod]
        public void ChangeFeedbackStatusCommand_Should_Throw_When_InvalidStatusValuePassed()
        {
            //Arrange

            var repository = new Repository();

            var arguments = new List<string>()
            {
                "1",
                "InvalidStatus",
            };

            //Act

            var command = new ChangeFeedbackStatusCommand(arguments, repository);

            //Assert

            Assert.ThrowsException<InvalidUserInputException>(command.Execute);
        }

        [TestMethod]
        public void ChangeFeedbackStatusCommand_Should_Throw_When_NonExistentIDValuePassed()
        {
            //Arrange

            var repository = new Repository();

            repository.CreateFeedback(
                "SomeValidStoryTitle",
                "SomeDescription",
                4);

            var arguments = new List<string>()
            {
                "2",
                "Scheduled",
            };

            //Act

            var command = new ChangeFeedbackStatusCommand(arguments, repository);

            //Assert

            Assert.ThrowsException<EntityNotFoundException>(command.Execute);
        }


        [TestMethod]
        public void ChangeFeedbackStatusCommand_Should_Throw_When_SameStatusValuePassed()
        {
            //Arrange

            var repository = new Repository();

            repository.CreateFeedback(
                "SomeValidBugTitle",
                "SomeDescription",
                4);

            var arguments = new List<string>()
            {
                "1",
                "New",
            };

            //Act

            var command = new ChangeFeedbackStatusCommand(arguments, repository);

            //Assert

            Assert.ThrowsException<NotAllowedException>(command.Execute);
        }
    }
}

