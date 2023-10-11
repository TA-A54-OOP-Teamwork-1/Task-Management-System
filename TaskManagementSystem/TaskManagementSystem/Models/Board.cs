using TaskManagementSystem.Helpers;
using TaskManagementSystem.Models.Contracts;

namespace TaskManagementSystem.Models
{
    public class Board : IBoard
    {
        private const int NameMinLength = 5;
        private const int NameMaxLength = 10;

        private readonly string NameIsNullError = "Name cannot be null!";
        private readonly string InvalidNameLengthError = $"Name must be between {NameMinLength} and {NameMaxLength}!";

        private string name;
        private List<ITaskItem> tasks;
        private List<string> activityHistory;

        public Board(string name)
        {
            this.tasks = new List<ITaskItem>();
            this.activityHistory = new List<string>();

            this.Name = name;
        }

        public string Name
        {
            get { return this.name; }
            init
            {
                ValidationHelper.StringIsNull(value, NameIsNullError);
                ValidationHelper.ValidateIntRange(value.Length, NameMinLength, 
                    NameMaxLength, InvalidNameLengthError);

                this.name = value;
            }
        }

        public IReadOnlyCollection<ITaskItem> Tasks { get; }

        public IReadOnlyCollection<string> ActivityHistory { get; }

        public void AddTask(ITaskItem task)
        {
            this.tasks.Add(task);
        }

        public void LogActivityHistory(string log)
        {
            this.activityHistory.Add($"[{DateTime.Now.ToString("dd/MM/yyyy")}] | log");
        }
    }
}
