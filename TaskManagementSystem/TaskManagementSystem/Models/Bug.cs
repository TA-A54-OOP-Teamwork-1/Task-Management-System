using TaskManagementSystem.Models.Contracts;
using TaskManagementSystem.Models.Enums;
using TaskManagementSystem.Models.Enums.Statuses;

namespace TaskManagementSystem.Models
{
    internal class Bug : TaskItem, IBug
    {
        private readonly IReadOnlyCollection<string> stepsToReproduce;

        public Bug(
            int id, 
            string title, 
            string desciption,
            Priority priority, 
            Severity severity,
            IReadOnlyCollection<string> stepsToReproduce
        )
            : base(id, title, desciption, TaskType.Bug)
        {
            this.Status = BugStatus.Active;
            this.Assignee = null;

            this.stepsToReproduce = stepsToReproduce;
            this.Priority = priority;
            this.Severity = severity;
        }        

        public Priority Priority { get; private set; }

        public Severity Severity { get; private set; }

        public IReadOnlyCollection<string> ReproduceSteps
        {
            get { return this.stepsToReproduce; }
        }

        public BugStatus Status { get; private set; } 

        public IPerson Assignee { get; private set; }        

        public void ChangePriority(Priority priority)
        {
            var previousPriority = this.Priority;
            this.Priority = priority;

            base.LogActivity($"Priority of [Bug - ID: {this.ID}] changed from {previousPriority} to {priority}.");
        }

        public void ChangeSeverity(Severity severity)
        {
            var previousSeverity = this.Severity;
            this.Severity = severity;

            base.LogActivity($"Severity of [Bug - ID: {this.ID}] changed from {previousSeverity} to {severity}.");
        }

        public void ChangeStatus(BugStatus status)
        {
            var previousStatus = this.Status;
            this.Status = status;

            base.LogActivity($"Status of [Bug - ID: {this.ID}] changed from {previousStatus} to {status}.");
        }

        public void SetAssignee(IPerson person)
        {
            this.Assignee = person;
            base.LogActivity($"Person with name {person.Name} has been set as assignee to Bug with ID {this.ID}.");
        }

        public void RemoveAssignee()
        {
            this.Assignee = null;
            base.LogActivity($"Assignee removed.");
        }
    }
}
