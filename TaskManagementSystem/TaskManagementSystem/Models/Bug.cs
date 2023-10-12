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
            IReadOnlyCollection<string> reproduceSteps,
            Priority priority, 
            Severity severity) 
            : base(id, title, desciption)
        {
            this.Status = BugStatus.Active;
            this.Assignee = null;

            this.reproduceSteps = reproduceSteps;
            this.Priority = priority;
            this.Severity = severity;
        }

        public IReadOnlyCollection<string> ReproduceSteps
        {
            get { return this.reproduceSteps; }
        }

        public Priority Priority { get; private set; }

        public Severity Severity { get; private set; }

        public BugStatus Status { get; private set; }

        public IMember Assignee { get; private set; }        

        public void UpdatePriority(Priority priority)
        {
            this.Priority = priority;
        }

        public void UpdateSeverity(Severity severity)
        {
            this.Severity = severity;
        }

        public void UpdateStatus(BugStatus status)
        {
            this.Status = status;
        }

        public void ChangeAssignee(IMember assignee)
        {
            this.Assignee = assignee;
        }

        public void SetAssignee(IMember member)
        {
            this.Assignee = member;
        }

        public void RemoveAssignee()
        {
            this.Assignee = null;
        }
    }
}
