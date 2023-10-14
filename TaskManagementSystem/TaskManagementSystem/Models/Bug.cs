using TaskManagementSystem.Models.Contracts;
using TaskManagementSystem.Models.Enums;
using TaskManagementSystem.Models.Enums.Statuses;

namespace TaskManagementSystem.Models
{
    internal class Bug : TaskItem, IBug
    {
        private IReadOnlyCollection<string> reproduceSteps;

        public Bug(
            int id, 
            string title, 
            string desciption,
            Priority priority, 
            Severity severity,
            IReadOnlyCollection<string> reproduceSteps
        )
            : base(id, title, desciption, TaskType.Bug)
        {
            this.Status = BugStatus.Active;
            this.Assignee = null;

            this.reproduceSteps = reproduceSteps;
            this.Priority = priority;
            this.Severity = severity;
        }        

        public Priority Priority { get; private set; }

        public Severity Severity { get; private set; }

        public IReadOnlyCollection<string> ReproduceSteps
        {
            get { return this.reproduceSteps; }
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
            this.Status = status;
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
