using TaskManagementSystem.Models.Enums;
using TaskManagementSystem.Models.Enums.Statuses;

namespace TaskManagementSystem.Models.Contracts
{
    public interface IBug : IAssignable
    {
        IReadOnlyCollection<string> ReproduceSteps { get; }

        Priority Priority { get; }

        Severity Severity { get; }

        BugStatus Status { get; }

        void ChangePriority(Priority priority);

        void ChangeSeverity(Severity severity);

        void ChangeStatus(BugStatus status);
    }
}
