using TaskManagementSystem.Helpers;
using TaskManagementSystem.Models.Contracts;

namespace TaskManagementSystem.Models
{
    public class Person : IPerson
    {
        private const int NameMinLength = 5;
        private const int NameMaxLength = 15;

        private string name;
        private readonly List<IAssignable> tasks;
        private readonly List<string> activityHistory;

        public Person(string name)
        {
            this.tasks = new List<IAssignable>();
            this.activityHistory = new List<string>();

            this.Name = name;

            this.LogActivity($"Person with name {this.Name} was created.");
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

        public string LastActivity { get; private set; }

        public void AssignTask(IAssignable task)
        {
            this.tasks.Add(task);
            this.LogActivity($"{task.GetType().Name} with ID {task.ID} was assigned to {this.Name}.");
        }
       
        public void UnassignTask(IAssignable task)
        {
            this.tasks.Remove(task);
            this.LogActivity($"{task.GetType().Name} with ID {task.ID} was unassigned.");
        }

        private void LogActivity(string log)
        {
            // ToDo: make private
            this.activityHistory.Add($"[{DateTime.Now:dd/MM/yyyy}] | {log}");
        }

    }
}
