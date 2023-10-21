using System.Text;
using TaskManagementSystem.Helpers;
using TaskManagementSystem.Models.Contracts;

namespace TaskManagementSystem.Models
{
    public class Board : IBoard
    {
        private const int NameMinLength = 5;
        private const int NameMaxLength = 10;

        private string name;
        private readonly List<IAssignable> tasks;
        private readonly List<IFeedback> feedbacks;
        private readonly List<IEvent> activityHistory;

        public Board(string name)
        {
            this.tasks = new List<IAssignable>();
            this.feedbacks = new List<IFeedback>();
            this.activityHistory = new List<IEvent>();

            this.Name = name;

            this.LogActivity($"Board with name {this.Name} was created.");
        }

        public string Name
        {
            get { return this.name; }
            init
            {
                ValidationHelper.ValidateString(value, NameMinLength, NameMaxLength, nameof(this.Name));
                this.name = value;
            }
        }

        public IReadOnlyCollection<IAssignable> Tasks
        {
            get { return this.tasks; }
        }

        public IReadOnlyCollection<IFeedback> Feedbacks
        {
            get { return this.feedbacks; }
        }

        public IReadOnlyCollection<IEvent> ActivityHistory
        {
            get { return this.activityHistory; }
        }

        public string LastActivity { get; private set; }

        public void AddTask(IAssignable task)
        {
            this.tasks.Add(task);
            this.LogActivity($"{task.GetType().Name} with ID {task.ID} was added to the board.");
        }

        public void AddFeedback(IFeedback feedback)
        {
            this.feedbacks.Add(feedback);
            this.LogActivity($"Feedback with ID {feedback.ID} was added to the board.");
        }

        private void LogActivity(string log)
        {
            this.LastActivity = log;
            this.activityHistory.Add(new Event(log));
        }

        public override string ToString()
        {
            var output = new StringBuilder();

            output.AppendLine($" # Name: {this.Name}");

            return output.ToString();
        }
    }
}
