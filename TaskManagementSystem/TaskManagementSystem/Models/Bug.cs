using TaskManagementSystem.Models.Contracts;
using TaskManagementSystem.Models.Enums;
using TaskManagementSystem.Models.Enums.Statuses;

namespace TaskManagementSystem.Models
{
    internal class Bug : TaskItem, IBug
    { 
        public Bug(
            int id, 
            string title, 
            string desciption,
            IReadOnlyCollection<string> reproduceSteps,
            Priority priority, 
            Severity severity, 
            IPerson assignee) 
            : base(id, title, desciption)
        {
            this.Status = BugStatus.Active;

            this.ReproduceSteps = reproduceSteps;
            this.Priority = priority;
            this.Severity = severity;
            this.Assignee = assignee;
        }

        public IReadOnlyCollection<string> ReproduceSteps { get; }

        public Priority Priority { get; private set; }

        public Severity Severity { get; private set; }

        public BugStatus Status { get; private set; }

        public IPerson Assignee { get; }

        public void UpdatePriority(Priority priority) => this.Priority = priority;

        public void UpdateSeverity(Severity severity) => this.Severity = severity;

        public void UpdateStatus(BugStatus status) => this.Status = status;
    }
}
