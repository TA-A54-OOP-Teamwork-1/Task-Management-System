using TaskManagementSystem.Core.Contracts;
using TaskManagementSystem.Core;
using TaskManagementSystem.Exceptions;
using TaskManagementSystem.Models.Contracts;

namespace TaskManagementSystem.Tests.RepositoryTests.Create
{
    [TestClass]
    public class CreateBoardTests
    {
        private readonly string? NullString = null;
        private const string ValidBoardName = "TestBoard";
        private const string ShortBoardName = "Name";
        private const string LongBoardName = "InvalidLongTestBoardName";

        private IRepository repository;

        [TestInitialize]
        public void Initialize()
        {
            repository = new Repository();
        }

        [TestMethod]
        public void Execute_Should_CreateNewValidBoard()
        {
            // Arrange
            string expectedBoardName = ValidBoardName;

            // Act
            IBoard board = repository.CreateBoard(expectedBoardName);

            // Act & Assert
            Assert.AreEqual(expectedBoardName, board.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Execute_ShouldThrow_IfNameIsNull()
        {
            // Arrange
            string? expectedBoardName = NullString;

            // Act
            IBoard board = repository.CreateBoard(expectedBoardName);

            // Assert
            Assert.AreEqual(expectedBoardName, board.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidUserInputException))]
        public void Execute_ShouldThrow_IfNameToShort()
        {
            // Arrange
            string expectedBoardName = ShortBoardName;

            // Act
            IBoard board = repository.CreateBoard(expectedBoardName);

            // Assert
            Assert.AreEqual(expectedBoardName, board.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidUserInputException))]
        public void Execute_ShouldThrow_IfNameToLong()
        {
            // Arrange
            string expectedBoardName = LongBoardName;

            // Act
            IBoard board = repository.CreateBoard(expectedBoardName);

            // Assert
            Assert.AreEqual(expectedBoardName, board.Name);
        }
    }
}
