using TaskManagementSystem.Core.Contracts;
using TaskManagementSystem.Core;
using TaskManagementSystem.Exceptions;
using TaskManagementSystem.Models;
using TaskManagementSystem.Models.Contracts;

namespace TaskManagementSystem.Tests.RepositoryTests.Create
{
    [TestClass]
    public class CreatePersonTests
    {
        private readonly string? NullString = null;
        private const string ValidPersonName = "TestPerson";
        private const string ShortPersonName = "Name";
        private const string LongPersonName = "InvalidLongTestPersonName";

        private IRepository repository;

        [TestInitialize]
        public void Initialize()
        {
            repository = new Repository();
        }

        [TestMethod]
        public void Execute_Should_CreateNewValidPerson()
        {
            // Arrange
            string expectedPersonName = ValidPersonName;

            // Act
            IPerson person = repository.CreatePerson(expectedPersonName);

            // Act & Assert
            Assert.AreEqual(expectedPersonName, person.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Execute_ShouldThrow_IfNameIsNull()
        {
            // Arrange
            string? expectedPersonName = NullString;

            // Act
            IPerson person = repository.CreatePerson(expectedPersonName);

            // Assert
            Assert.AreEqual(expectedPersonName, person.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidUserInputException))]
        public void Execute_ShouldThrow_IfNameToShort()
        {
            // Arrange
            string expectedPersonName = ShortPersonName;

            // Act
            IPerson person = repository.CreatePerson(expectedPersonName);

            // Assert
            Assert.AreEqual(expectedPersonName, person.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidUserInputException))]
        public void Execute_ShouldThrow_IfNameToLong()
        {
            // Arrange
            string expectedPersonName = LongPersonName;

            // Act
            IPerson person = repository.CreatePerson(expectedPersonName);

            // Assert
            Assert.AreEqual(expectedPersonName, person.Name);
        }
    }
}
