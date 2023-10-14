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
        private readonly List<string> activityHistory;

        public Board(string name)
        {
            this.tasks = new List<IAssignable>();
            this.feedbacks = new List<IFeedback>();
            this.activityHistory = new List<string>();

            this.Name = name;
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

        public IReadOnlyCollection<string> ActivityHistory
        {
            get { return this.activityHistory; }
        }

        public void AddTask(IAssignable task)
        {
            this.tasks.Add(task);
        }

        public void AddFeedback(IFeedback feedback)
        {
            this.feedbacks.Add(feedback);
        }

        public void LogActivity(string log)
        {
            this.activityHistory.Add($"[{DateTime.Now:dd/MM/yyyy}] | {log}");
        }
    }
}
