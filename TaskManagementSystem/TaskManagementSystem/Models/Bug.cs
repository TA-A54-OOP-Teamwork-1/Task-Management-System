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
            this.Priority = priority;
        }

        public void ChangeSeverity(Severity severity)
        {
            this.Severity = severity;
        }

        public void ChangeStatus(BugStatus status)
        {
            var oldStatus = this.Status;
            this.Status = status;

            base.LogActivity($"St")
        }

        public void SetAssignee(IPerson person)
        {
            this.Assignee = person;
        }

        public void RemoveAssignee()
        {
            this.Assignee = null;
        }
    }
}
