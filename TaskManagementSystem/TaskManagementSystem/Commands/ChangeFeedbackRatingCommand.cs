using TaskManagementSystem.Core.Contracts;
using TaskManagementSystem.Models.Contracts;

namespace TaskManagementSystem.Commands
{
    public class ChangeFeedbackRatingCommand : BaseCommand
    {
        private const int ExpectedParametersCount = 2;

        public ChangeFeedbackRatingCommand(IList<string> parameters, IRepository repository) 
            : base(parameters, repository)
        {
        }

        public override string Execute()
        {
            base.ValidateParametersCount(ExpectedParametersCount);

            var feedbackID = base.ParseInt(base.Parameters[0]);
            var rating = base.ParseInt(base.Parameters[1]);

            var feedback = base.Repository.GetTaskByID<IFeedback>(feedbackID);
            var result = base.Repository.UpdateFeedbackRating(feedback, rating);

            return result;
        }
    }
}
