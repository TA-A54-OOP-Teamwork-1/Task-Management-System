using TaskManagementSystem.Commands;
using TaskManagementSystem.Core.Contracts;
using TaskManagementSystem.Core;
using TaskManagementSystem.Exceptions;

namespace TaskManagementSystem.Tests.CommandTests.Create
{
    [TestClass]
    public class CreateStoryCommandTests
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
        public void Execute_Should_CreateStory()
        {
            // Arrange
            var boardName = "Board Name";
            repository.CreateBoard(boardName);

            var title = ValidTitle;
            var description = ValidDescription;
            var priority = "Medium";
            var size = "Small";
            
            var arguments = new List<string>()
            {
                title,
                description,
                priority,
                size,
                boardName
            };

            // Act, Assert
            var command = new CreateStoryCommand(arguments, repository);
            command.Execute();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidUserInputException))]
        public void Execute_ShouldThrow_IfParametersCountIncorrect()
        {
            // Arrange
            var boardName = "Board Name";

            var title = ValidTitle;
            var description = ValidDescription;
            var priority = "Low";
            var size = "Small";

            var arguments = new List<string>()
            {
                title,
                description,
                priority,
                size,
                boardName,
                "Some Extra Parameter"
            };

            // Act, Assert
            var command = new CreateStoryCommand(arguments, repository);
            command.Execute();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidUserInputException))]
        public void Execute_ShouldThrow_IfIncorrectPriority()
        {
            // Arrange
            var boardName = "Board Name";
            repository.CreateBoard(boardName);

            var title = ValidTitle;
            var description = ValidDescription;
            var priority = "IncorrectPriority";
            var size = "Small";
            
            var arguments = new List<string>()
            {
                title,
                description,
                priority,
                size,
                boardName
            };

            // Act, Assert
            var command = new CreateStoryCommand(arguments, repository);
            command.Execute();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidUserInputException))]
        public void Execute_ShouldThrow_IfIncorrectSeverity()
        {
            // Arrange
            var boardName = "Board Name";
            repository.CreateBoard(boardName);

            var title = ValidTitle;
            var description = ValidDescription;
            var priority = "Low";
            var size = "IncorrectSize";
            
            var arguments = new List<string>()
            {
                title,
                description,
                priority,
                size,
                boardName
            };

            // Act, Assert
            var command = new CreateStoryCommand(arguments, repository);
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
            var priority = "Low";
            var size = "Small";

            var arguments = new List<string>()
            {
                title,
                description,
                priority,
                size,
                boardName
            };

            // Act, Assert
            var command = new CreateStoryCommand(arguments, repository);
            command.Execute();
        }
    }
}
