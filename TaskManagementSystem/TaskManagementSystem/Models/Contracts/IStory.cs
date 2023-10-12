using TaskManagementSystem.Models.Enums;
using TaskManagementSystem.Models.Enums.Statuses;

namespace TaskManagementSystem.Models.Contracts
{
    public interface IStory : ITaskItem
    {
        Priority Priority { get; }

        Size Size { get; }

        StoryStatus Status { get; }

        IPerson Assignee { get; }

       void UpdatePriority(Priority priority);

       void UpdateSize(Size size);

       void UpdateStatus(StoryStatus status);

       void ChangeAssignee(IPerson assignee);
    }
}
