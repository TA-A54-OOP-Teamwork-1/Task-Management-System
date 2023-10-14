using TaskManagementSystem.Helpers;
using TaskManagementSystem.Models.Contracts;

namespace TaskManagementSystem.Models
{
    public class Person : IPerson
    {
        private const int NameMinLength = 5;
        private const int NameMaxLength = 15;

        private string name;
        private List<IAssignable> tasks;
        private List<string> activityHistory;

        public Person(string name)
        {
            this.tasks = new List<IAssignable>();
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

        public IReadOnlyCollection<string> ActivityHistory
        {
            get { return this.activityHistory; }
        }

        public void AddTask(IAssignable task)
        {
            this.tasks.Add(task);
        }
       
        public void RemoveTask(IAssignable task)
        {
            this.tasks.Remove(task);
        }

        public void LogActivityHistory(string log)
        {
            this.activityHistory.Add($"[{DateTime.Now.ToString("dd/MM/yyyy")}] | {log}");
        }

    }
}
