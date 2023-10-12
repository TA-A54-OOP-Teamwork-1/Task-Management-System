using TaskManagementSystem.Models.Enums;
using TaskManagementSystem.Models.Enums.Statuses;

namespace TaskManagementSystem.Models.Contracts
{
    public interface IStory : ITaskItem, IAssignable
    {
        Priority Priority { get; }

        Size Size { get; }

        StoryStatus Status { get; }

        IMember Assignee { get; }

       void UpdatePriority(Priority priority);

       void UpdateSize(Size size);

       void UpdateStatus(StoryStatus status);
    }
}
