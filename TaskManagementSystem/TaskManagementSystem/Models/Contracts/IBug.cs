using TaskManagementSystem.Models.Enums;
using TaskManagementSystem.Models.Enums.Statuses;

namespace TaskManagementSystem.Models.Contracts
{
    public interface IBug : ITaskItem, IAssignable
    {
        IReadOnlyCollection<string> ReproduceSteps { get; }

        Priority Priority { get; }

        Severity Severity { get; }

        BugStatus Status { get; }

        IMember Assignee { get; }

        void UpdatePriority(Priority priority);

        void UpdateSeverity(Severity severity);

        void UpdateStatus(BugStatus status);

        void ChangeAssignee(IMember assignee);
    }
}
