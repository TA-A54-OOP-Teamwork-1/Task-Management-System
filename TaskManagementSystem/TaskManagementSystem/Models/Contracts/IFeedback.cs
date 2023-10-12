using TaskManagementSystem.Models.Enums.Statuses;

namespace TaskManagementSystem.Models.Contracts
{
    public interface IFeedback : ITaskItem
    {
        int Rating { get; }

        FeedbackStatus Status { get; }

        public void UpdateStatus(FeedbackStatus status);

        public void UpdateRating(int rating);
    }
}
