using TaskManagementSystem.Helpers;
using TaskManagementSystem.Models.Contracts;
using TaskManagementSystem.Models.Enums;

namespace TaskManagementSystem.Models
{
    public abstract class TaskItem : ITaskItem
    {
        private const int TitleMinLength = 10;
        private const int TitleMaxLength = 50;
        private const int DescriptionMinLength = 10;
        private const int DescriptionMaxLength = 500;

        private const string NullValueErrorMessage = "{0} cannot be null!";
        private const string InvalidLengthErrorMessage = "{0} must be between {1} and {2} symbols long!";

        private string title;
        private string description;
        private readonly List<IComment> comments;
        private readonly List<string> activityHistory;

        protected TaskItem(int id, string title, string desciption, TaskType taskType)
        {
            this.comments = new List<IComment>();
            this.activityHistory = new List<string>();

            this.ID = id;
            this.TaskType = taskType;
            this.Title = title;
            this.Description = desciption;
        }

        public int ID { get; }

        public TaskType TaskType { get; }

        public string Title
        {
            get { return this.title; }
            init
            {
                ValidationHelper.ValidateString(value, TitleMinLength, TitleMaxLength, nameof(this.Title));
                this.title = value;
            }
        }

        public string Description
        {
            get { return this.description; }
            init
            {
                ValidationHelper.ValidateString(value, DescriptionMinLength, DescriptionMaxLength, nameof(this.Description));
                this.description = value;
            }
        }

        public IReadOnlyCollection<IComment> Comments
        {
            get { return this.comments; }
        }

        public IReadOnlyCollection<string> History
        {
            get { return this.activityHistory; }
        }

        public void AddComment(IComment comment)
        {
            this.comments.Add(comment);
        }

        public void LogActivityHistory(string log)
        {
            this.activityHistory.Add($"[{DateTime.Now.ToString("dd/MM/yyyy")}] | {log}");
        }
    }
}
