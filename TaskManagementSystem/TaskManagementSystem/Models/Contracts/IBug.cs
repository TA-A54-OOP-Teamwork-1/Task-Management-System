using TaskManagementSystem.Models.Enums;
using TaskManagementSystem.Models.Enums.Statuses;

namespace TaskManagementSystem.Models.Contracts
{
    public interface IBug
    {
        IReadOnlyCollection<string> ReproduceSteps { get; }

        Priority Priority { get; }

        Severity Severity { get; }

        BugStatus Status { get; }

        IPerson Assignee { get; }

        public void UpdatePriority(Priority priority);

        public void UpdateSeverity(Severity severity);

        public void UpdateStatus(BugStatus status);

        public void ChangeAssignee(IPerson assignee);
    }
}
