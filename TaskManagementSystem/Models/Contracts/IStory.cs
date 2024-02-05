using TaskManagementSystem.Models.Enums;
using TaskManagementSystem.Models.Enums.Statuses;

namespace TaskManagementSystem.Models.Contracts
{
    public interface IStory : IAssignable
    {
        Priority Priority { get; }

        Size Size { get; }

        StoryStatus Status { get; }

        void ChangePriority(Priority priority);

        void ChangeSize(Size size);

        void ChangeStatus(StoryStatus status);
    }
}
