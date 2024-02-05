using TaskManagementSystem.Core.Contracts;
using TaskManagementSystem.Core;
using TaskManagementSystem.Commands;
using TaskManagementSystem.Exceptions;

namespace TaskManagementSystem.Tests.CommandTests.Create
{
    [TestClass]
    public class CreateTeamCommandTests
    {
        private IRepository repository;

        [TestInitialize]
        public void Initialize()
        {
            repository = new Repository();
        }

        [TestMethod]
        public void Execute_Should_CreateTeam()
        {
            // Arrange
            var arguments = new List<string>()
            {
                "Team Name"
            };

            // Act, Assert
            var command = new CreateTeamCommand(arguments, repository);
            command.Execute();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidUserInputException))]
        public void Execute_ShouldThrow_IfParametersCountIncorrect()
        {
            //Arrange
            var arguments = new List<string>()
            {
                "Team Name",
                "Some Extra Parameter"
            };

            // Act, Assert
            var command = new CreateTeamCommand(arguments, repository);
            command.Execute();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidUserInputException))]
        public void Execute_ShouldThrow_IfTeamExists()
        {
            // Arrange
            var testTeamName = "Team Name";
            var team = repository.CreateTeam(testTeamName);

            var arguments = new List<string>()
            {
                testTeamName,
            };

            // Act, Assert
            var command = new CreateTeamCommand(arguments, repository);
            command.Execute();
        }
    }
}
