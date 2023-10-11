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
    }
}
