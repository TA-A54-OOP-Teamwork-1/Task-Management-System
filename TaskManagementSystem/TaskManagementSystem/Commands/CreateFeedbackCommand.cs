using System.Text;

using TaskManagementSystem.Core.Contracts;
using TaskManagementSystem.Helpers;

namespace TaskManagementSystem.Commands
{
    public class CreateFeedbackCommand : BaseCommand
    {
        private const int ExpectedParametersCount = 4;
        private const int MinRating = 1;
        private const int MaxRating = 5;

        public CreateFeedbackCommand(IList<string> parameters, IRepository repository) 
            : base(parameters, repository)
        {
        }

        public override string Execute()
        {
            base.ValidateParametersCount(ExpectedParametersCount);

            var title = base.Parameters[0];
            var description = base.Parameters[1];
            var rating = base.ParseInt(base.Parameters[2]);
            var boardName = base.Parameters[3];

            ValidationHelper.ValidateIntRange(rating, MinRating, MaxRating, "Rating");

            var board = base.Repository.GetBoardByName(boardName);
            var feedback = base.Repository.CreateFeedback(title, description, rating);

            board.AddFeedback(feedback);

            var output = new StringBuilder();
            output.AppendLine(feedback.LastActivity);
            output.Append(board.LastActivity);

            return output.ToString();
        }
    }
}
