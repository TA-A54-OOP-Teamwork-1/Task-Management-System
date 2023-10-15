using TaskManagementSystem.Core.Contracts;

namespace TaskManagementSystem.Commands
{
    public class CreateFeedbackCommand : BaseCommand
    {
        private const int ExpectedParametersCount = 4;

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

            var board = base.Repository.GetBoardByName(boardName);
            var feedback = base.Repository.CreateFeedback(title, description, rating);

            board.AddFeedback(feedback);

            var log = $"Feedback with ID {feedback.ID} was created.";

            board.LogActivity(log);
            feedback.LogActivity(log);

            return log;
        }
    }
}
