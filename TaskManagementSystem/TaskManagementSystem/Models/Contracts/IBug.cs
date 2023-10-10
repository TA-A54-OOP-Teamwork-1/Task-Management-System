using TaskManagementSystem.Models.Enums;
using TaskManagementSystem.Models.Enums.Statuses;

namespace TaskManagementSystem.Models.Contracts
{
    public interface IBug : ITaskItem
    {
        IReadOnlyCollection<string> ReproduceSteps { get; }

        Priority Priority { get; }

        Severity Severity { get; }

        BugStatus BugStatus { get; }

        IPerson Assignee { get; }
    }
}
