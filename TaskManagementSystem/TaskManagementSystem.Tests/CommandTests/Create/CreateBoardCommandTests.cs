using TaskManagementSystem.Core.Contracts;
using TaskManagementSystem.Core;
using TaskManagementSystem.Commands;
using TaskManagementSystem.Exceptions;

namespace TaskManagementSystem.Tests.CommandTests.Create
{
    [TestClass]
    public class CreateBoardCommandTests
    {
        private IRepository repository;

        [TestInitialize]
        public void Initialize()
        {
            repository = new Repository();
        }

        [TestMethod]
        public void Execute_Should_CreateBoard()
        {
            // Arrange
            var teamName = "Test Team";
            repository.CreateTeam(teamName);
            var arguments = new List<string>()
            {
                "Test Board",
                teamName
            };

            // Act, Assert
            var command = new CreateBoardCommand(arguments, repository);
            command.Execute();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidUserInputException))]
        public void Execute_ShouldThrow_IfParametersCountIncorrect()
        {
            // Arrange
            var arguments = new List<string>()
            {
                "Test Board",
                "Test Team",
                "Some Extra Parameter"
            };

            // Act, Assert
            var command = new CreateBoardCommand(arguments, repository);
            command.Execute();
        }

        [TestMethod]
        [ExpectedException(typeof(EntityNotFoundException))]
        public void Execute_ShouldThrow_IfTeamDoesNotExist()
        {
            // Arrange                       
            var arguments = new List<string>()
            {
                "Test Board",
                "Test Team"
            };

            // Act, Assert
            var command = new CreateBoardCommand(arguments, repository);
            command.Execute();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidUserInputException))]
        public void Execute_ShouldThrow_IfBoardExists()
        {
            // Arrange
            var teamName = "Test Team";
            var team = repository.CreateTeam(teamName);
            var boardName = "Test Board";
            var board = repository.CreateBoard(boardName);
            team.AddBoard(board);

            var arguments = new List<string>()
            {
                boardName,
                teamName
            };
            
            // Act, Assert
            var command = new CreateBoardCommand(arguments, repository);
            command.Execute();
        }
    }
}
