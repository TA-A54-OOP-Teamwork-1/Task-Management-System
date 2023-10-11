using TaskManagementSystem.Models.Contracts;
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
    }
}
