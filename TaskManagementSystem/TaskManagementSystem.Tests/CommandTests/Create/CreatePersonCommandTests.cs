using TaskManagementSystem.Core.Contracts;
using TaskManagementSystem.Core;
using TaskManagementSystem.Commands;
using TaskManagementSystem.Exceptions;

namespace TaskManagementSystem.Tests.CommandTests.Create
{
    [TestClass]
    public class CreatePersonCommandTests
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
                "Person Name"
            };

            // Act, Assert
            var command = new CreatePersonCommand(arguments, repository);
            command.Execute();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidUserInputException))]
        public void Execute_ShouldThrow_IfParametersCountIncorrect()
        {
            //Arrange
            var arguments = new List<string>()
            {
                "Person Name",
                "Some Extra Parameter"
            };

            // Act, Assert
            var command = new CreatePersonCommand(arguments, repository);
            command.Execute();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidUserInputException))]
        public void Execute_ShouldThrow_IfTeamExists()
        {
            // Arrange
            var testPersonName = "Person Name";
            var person = repository.CreatePerson(testPersonName);

            var arguments = new List<string>()
            {
                testPersonName,
            };

            // Act, Assert
            var command = new CreatePersonCommand(arguments, repository);
            command.Execute();
        }
    }
}
