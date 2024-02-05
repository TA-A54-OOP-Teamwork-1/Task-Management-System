using TaskManagementSystem.Models.Enums;
using TaskManagementSystem.Models;
using TaskManagementSystem.Core.Contracts;
using TaskManagementSystem.Core;
using TaskManagementSystem.Models.Contracts;
using TaskManagementSystem.Exceptions;

namespace TaskManagementSystem.Tests.RepositoryTests.Create
{
    [TestClass]
    public class CreateBugTests
    {
        private readonly string? NullString = null;
        private const string ValidTitle = "TestBugTitle";
        private readonly string ShortTitle = new String('a', 9);
        private readonly string LongTitle = new String('a', 51);

        private const string ValidDescription = "ValidDescription";
        private readonly string ShortDescription = new String('a', 9);
        private readonly string LongDescription = new String('a', 501);

        private IRepository repository;

        [TestInitialize]
        public void Initialize()
        {
            repository = new Repository();
        }

        private IBug CreateBugThroughRepository(string title = ValidTitle, string description = ValidDescription)
        {
            Priority priority = Priority.Medium;
            Severity severity = Severity.Minor;
            IReadOnlyCollection<string> steps = new List<string>() { "TestStep1", "TestStep2", "TestStep3" };
            return repository.CreateBug(title, description, priority, severity, steps);
        }

        [TestMethod]
        public void Execute_Should_CreateValidBug()
        {
            // Arrange
            string expectedBugTitle = "TestBugTitle";
            IBug bug = CreateBugThroughRepository();

            // Act, Assert
            Assert.AreEqual(bug.Title, expectedBugTitle);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Execute_ShouldThrow_IfTittleIsNull()
        {
            // Arrange, Act, Assert
            CreateBugThroughRepository(NullString, ValidDescription);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidUserInputException))]
        public void Execute_ShouldThrow_IfTittleIsTooShort()
        {
            // Arrange, Act, Assert
            CreateBugThroughRepository(ShortTitle, ValidDescription);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidUserInputException))]
        public void Execute_ShouldThrow_IfTittleIsTooLong()
        {
            // Arrange, Act, Assert
            CreateBugThroughRepository(LongTitle, ValidDescription);
        }

        /**
         *  Description
         */

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Execute_ShouldThrow_IfDescriptionIsNull()
        {
            // Arrange, Act, Assert
            CreateBugThroughRepository(ValidTitle, NullString);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidUserInputException))]
        public void Execute_ShouldThrow_IfDescriptionIsTooShort()
        {
            // Arrange, Act, Assert
            CreateBugThroughRepository(ValidTitle, ShortDescription);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidUserInputException))]
        public void Execute_ShouldThrow_IfDescriptionIsTooLong()
        {
            // Arrange, Act, Assert
            CreateBugThroughRepository(ValidTitle, LongDescription);
        }
    }
}
