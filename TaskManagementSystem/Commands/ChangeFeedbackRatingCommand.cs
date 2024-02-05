using TaskManagementSystem.Core.Contracts;
using TaskManagementSystem.Helpers;
using TaskManagementSystem.Models.Contracts;

namespace TaskManagementSystem.Commands
{
    public class ChangeFeedbackRatingCommand : BaseCommand
    {
        private const int ExpectedParametersCount = 2;
        private const int MinRating = 1;
        private const int MaxRating = 5;

        public ChangeFeedbackRatingCommand(IList<string> parameters, IRepository repository) 
            : base(parameters, repository)
        {
        }

        public override string Execute()
        {
            base.ValidateParametersCount(ExpectedParametersCount);

            var feedbackID = base.ParseInt(base.Parameters[0]);
            var rating = base.ParseInt(base.Parameters[1]);

            ValidationHelper.ValidateIntRange(rating, MinRating, MaxRating, "Rating");

            var feedback = base.Repository.GetTaskByID<IFeedback>(feedbackID);

            base.EnsureNotEqual(rating, feedback.Rating);

            var result = base.Repository.UpdateFeedbackRating(feedback, rating);

            return result;
        }
    }
}
