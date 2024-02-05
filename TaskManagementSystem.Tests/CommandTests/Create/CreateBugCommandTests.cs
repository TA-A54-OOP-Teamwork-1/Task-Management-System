using TaskManagementSystem.Core.Contracts;
using TaskManagementSystem.Core;
using TaskManagementSystem.Commands;
using TaskManagementSystem.Models.Contracts;
using TaskManagementSystem.Models.Enums;
using TaskManagementSystem.Exceptions;

namespace TaskManagementSystem.Tests.CommandTests.Create
{
    [TestClass]
    public class CreateBugCommandTests
    {
        private const string ValidTitle = "TestBugTitle";
        private const string ValidDescription = "ValidDescription";
        
        private IRepository repository;

        [TestInitialize]
        public void Initialize()
        {
            repository = new Repository();
        }

        [TestMethod]
        public void Execute_Should_CreateBug()
        {
            // Arrange
            var boardName = "Board Name";
            repository.CreateBoard(boardName);

            var title = ValidTitle;
            var description = ValidDescription;
            var priority = "Medium";
            var severity = "Minor";
            var steps = "TestStep1;TestStep2;TestStep3";

            var arguments = new List<string>()
            {
                title,
                description,
                priority,
                severity,
                steps,
                boardName
            };

            // Act, Assert
            var command = new CreateBugCommand(arguments, repository);
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
            var severity = "Minor";
            var steps = "TestStep1;TestStep2;TestStep3";

            var arguments = new List<string>()
            {
                title,
                description,
                priority,
                severity,
                steps,
                boardName
            };

            // Act, Assert
            var command = new CreateBugCommand(arguments, repository);
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
            var severity = "IncorrectSeverity";
            var steps = "TestStep1;TestStep2;TestStep3";

            var arguments = new List<string>()
            {
                title,
                description,
                priority,
                severity,
                steps,
                boardName
            };

            // Act, Assert
            var command = new CreateBugCommand(arguments, repository);
            command.Execute();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidUserInputException))]
        public void Execute_ShouldThrow_IfBoardNotFound()
        {
            // Arrange
            var boardName = "Board Name";
            var title = ValidTitle;
            var description = ValidDescription;
            var priority = "Low";
            var severity = "IncorrectSeverity";
            var steps = "TestStep1;TestStep2;TestStep3";

            var arguments = new List<string>()
            {
                title,
                description,
                priority,
                severity,
                steps,
                boardName
            };

            // Act, Assert
            var command = new CreateBugCommand(arguments, repository);
            command.Execute();
        }
    }
}
