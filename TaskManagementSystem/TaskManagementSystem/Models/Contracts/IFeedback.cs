using TaskManagementSystem.Models.Enums.Statuses;

namespace TaskManagementSystem.Models.Contracts
{
    public interface IFeedback : ITaskItem
    {
        int Rating { get; }

        FeedbackStatus Status { get; }
    }
}
