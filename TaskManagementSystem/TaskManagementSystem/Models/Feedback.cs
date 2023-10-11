using TaskManagementSystem.Models.Contracts;
using TaskManagementSystem.Models.Enums;
using TaskManagementSystem.Models.Enums.Statuses;

namespace TaskManagementSystem.Models
{
    public class Feedback : TaskItem, IFeedback
    {
        public Feedback(int id, string title, string desciption, int rating)
            : base(id, title, desciption)
        {
            this.Status = FeedbackStatus.New;
            this.Rating = rating;
        }

        public int Rating { get; private set; }

        public FeedbackStatus Status { get; private set; }

        public void UpdateStatus(FeedbackStatus status) => this.Status = status;

        public void UpdateRating(int rating) => this.Rating = rating;
    }
}
