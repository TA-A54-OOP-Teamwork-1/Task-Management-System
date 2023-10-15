using TaskManagementSystem.Models.Contracts;
using TaskManagementSystem.Models.Enums;
using TaskManagementSystem.Models.Enums.Statuses;

namespace TaskManagementSystem.Models
{
    public class Feedback : TaskItem, IFeedback
    {
        public Feedback(int id, string title, string desciption, int rating)
            : base(id, title, desciption, TaskType.Feedback)
        {
            this.Status = FeedbackStatus.New;
            this.Rating = rating;
        }

        public int Rating { get; private set; }

        public FeedbackStatus Status { get; private set; }

        public void ChangeStatus(FeedbackStatus status)
        {
            var previousStatus = this.Status;
            this.Status = status;

            base.LogActivity($"Status of [Feedback - ID: {this.ID}] changed from {previousStatus} to {status}.");
        }

        public void ChangeRating(int rating)
        {
            var previousRating = this.Rating;
            this.Rating = rating;

            base.LogActivity($"Rating of [Feedback - ID: {this.ID}] changed from {previousRating} to {rating}.");
        }
    }
}
