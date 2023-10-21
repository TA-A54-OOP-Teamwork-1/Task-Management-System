using TaskManagementSystem.Commands;
using TaskManagementSystem.Core;
using TaskManagementSystem.Exceptions;

namespace TaskManagementSystem.Tests.CommandTests.Change
{
    [TestClass]
    public class ChangeFeedbackRatingCommandTests
    {
        [TestMethod]
        public void ChangeFeedbackRatingCommand_Should_Throw_When_InvalidArgumentsCountPassed()
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

            var command = new ChangeFeedbackRatingCommand(arguments, repository);

            //Assert

            Assert.ThrowsException<InvalidUserInputException>(command.Execute);
        }

        [TestMethod]
        public void ChangeFeedbackRatingCommand_Should_Throw_When_InvalidIDValueTypePassed()
        {
            //Arrange

            var repository = new Repository();

            var arguments = new List<string>()
            {
                "a",
                "4",
            };

            //Act

            var command = new ChangeFeedbackRatingCommand(arguments, repository);

            //Assert

            Assert.ThrowsException<InvalidUserInputException>(command.Execute);
        }

        [TestMethod]
        public void ChangeFeedbackRatingCommand_Should_Throw_When_InvalidRatingValuePassed()
        {
            //Arrange

            var repository = new Repository();

            var arguments = new List<string>()
            {
                "1",
                "6",
            };

            //Act

            var command = new ChangeFeedbackRatingCommand(arguments, repository);

            //Assert

            Assert.ThrowsException<InvalidUserInputException>(command.Execute);
        }

        [TestMethod]
        public void ChangeFeedbackRatingCommand_Should_Throw_When_NonExistentIDValuePassed()
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
                "3",
            };

            //Act

            var command = new ChangeFeedbackRatingCommand(arguments, repository);

            //Assert

            Assert.ThrowsException<EntityNotFoundException>(command.Execute);
        }


        [TestMethod]
        public void ChangeFeedbackRatingCommand_Should_Throw_When_SameRatingValuePassed()
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
                "4",
            };

            //Act

            var command = new ChangeFeedbackRatingCommand(arguments, repository);

            //Assert

            Assert.ThrowsException<NotAllowedException>(command.Execute);
        }
    }
}

