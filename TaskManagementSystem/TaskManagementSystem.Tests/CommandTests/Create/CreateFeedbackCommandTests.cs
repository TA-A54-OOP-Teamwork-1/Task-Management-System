using TaskManagementSystem.Commands;
using TaskManagementSystem.Core;
using TaskManagementSystem.Core.Contracts;
using TaskManagementSystem.Exceptions;

namespace TaskManagementSystem.Tests.CommandTests.Create
{
    [TestClass]
    public class CreateFeedbackCommandTests
    {
        private const string ValidTitle = "TestTitleTitle";
        private const string ValidDescription = "ValidDescription";

        private IRepository repository;

        [TestInitialize]
        public void Initialize()
        {
            repository = new Repository();
        }

        [TestMethod]
        public void Execute_Should_CreateFeedback()
        {
            // Arrange
            var boardName = "Board Name";
            repository.CreateBoard(boardName);

            var title = ValidTitle;
            var description = ValidDescription;
            var rating = "5";
            var arguments = new List<string>()
            {
                title,
                description,
                rating,
                boardName
            };

            // Act, Assert
            var command = new CreateFeedbackCommand(arguments, repository);
            command.Execute();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidUserInputException))]
        public void Execute_ShouldThrow_IfRatingNotNumber()
        {
            // Arrange
            var boardName = "Board Name";
            repository.CreateBoard(boardName);

            var title = ValidTitle;
            var description = ValidDescription;
            var rating = "notNumber";
            var arguments = new List<string>()
            {
                title,
                description,
                rating,
                boardName
            };

            // Act, Assert
            var command = new CreateFeedbackCommand(arguments, repository);
            command.Execute();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidUserInputException))]
        public void Execute_ShouldThrow_IfRatingLowerThanMin()
        {
            // Arrange
            var boardName = "Board Name";
            repository.CreateBoard(boardName);

            var title = ValidTitle;
            var description = ValidDescription;
            var rating = "-1";
            var arguments = new List<string>()
            {
                title,
                description,
                rating,
                boardName
            };

            // Act, Assert
            var command = new CreateFeedbackCommand(arguments, repository);
            command.Execute();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidUserInputException))]
        public void Execute_ShouldThrow_IfRatingGreaterThanMax()
        {
            // Arrange
            var boardName = "Board Name";
            repository.CreateBoard(boardName);

            var title = ValidTitle;
            var description = ValidDescription;
            var rating = "6";
            var arguments = new List<string>()
            {
                title,
                description,
                rating,
                boardName
            };

            // Act, Assert
            var command = new CreateFeedbackCommand(arguments, repository);
            command.Execute();
        }

        [TestMethod]
        [ExpectedException(typeof(EntityNotFoundException))]
        public void Execute_ShouldThrow_IfBoardNotFound()
        {
            // Arrange
            var boardName = "Board Name";

            var title = ValidTitle;
            var description = ValidDescription;
            var rating = "5";
            var arguments = new List<string>()
            {
                title,
                description,
                rating,
                boardName
            };

            // Act, Assert
            var command = new CreateFeedbackCommand(arguments, repository);
            command.Execute();
        }
    }
}
