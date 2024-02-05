using TaskManagementSystem.Core.Contracts;
using TaskManagementSystem.Core;
using TaskManagementSystem.Models.Contracts;
using TaskManagementSystem.Models.Enums;

namespace TaskManagementSystem.Tests.RepositoryTests.Create
{
    [TestClass]
    public class CreateFeedbackTests
    {
        /**
         *  Null title, null description and ranges testing is done in the "CreateBoardTests.cs"
         */

        private const string ValidTitle = "TestFeedbackTitle";
        private const string ValidDescription = "ValidDescription";

        private IRepository repository;

        [TestInitialize]
        public void Initialize()
        {
            repository = new Repository();
        }

        private IFeedback CreateFeedbackThroughRepository(string title = ValidTitle, string description = ValidDescription)
        {
            int rating = 5;
            return repository.CreateFeedback(title, description, rating);
        }


        [TestMethod]
        public void Execute_Should_CreateNewFeedback()
        {
            // Arrange, Act
            IFeedback feedback = CreateFeedbackThroughRepository();

            // Assert
            Assert.AreEqual(feedback.Title, ValidTitle);
            Assert.AreEqual(feedback.Description, ValidDescription);
        }
    }
}
