using TaskManagementSystem.Commands;
using TaskManagementSystem.Core;
using TaskManagementSystem.Core.Contracts;
using TaskManagementSystem.Exceptions;

namespace TaskManagementSystem.Tests.RepositoryTests.Create
{
    [TestClass]
    public class CreateTeamTests
    {
        private readonly string? NullString = null;
        private const string ValidTeamName = "TestTeam";
        private const string ShortTeamName = "Name";
        private const string LongTeamName = "InvalidLongTestTeamName";

        private IRepository repository;

        [TestInitialize]
        public void Initialize()
        {
            repository = new Repository();
        }

        [TestMethod]
        public void Execute_Should_CreateNewValidTeam()
        {
            // Arrange
            var expectedTeamName = ValidTeamName;

            // Act
            var team = repository.CreateTeam(expectedTeamName);

            // Act & Assert
            Assert.AreEqual(expectedTeamName, team.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Execute_ShouldThrow_IfNameIsNull()
        {
            // Arrange
            var expectedTeamName = NullString;

            // Act
            var team = repository.CreateTeam(expectedTeamName);

            // Assert
            Assert.AreEqual(expectedTeamName, team.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidUserInputException))]
        public void Execute_ShouldThrow_IfNameToShort()
        {
            // Arrange
            var expectedTeamName = ShortTeamName;

            // Act
            var team = repository.CreateTeam(expectedTeamName);

            // Assert
            Assert.AreEqual(expectedTeamName, team.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidUserInputException))]
        public void Execute_ShouldThrow_IfNameToLong()
        {
            // Arrange
            var expectedTeamName = LongTeamName;

            // Act
            var team = repository.CreateTeam(expectedTeamName);

            // Assert
            Assert.AreEqual(expectedTeamName, team.Name);
        }
    }
}