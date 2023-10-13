using TaskManagementSystem.Models.Contracts;
using TaskManagementSystem.Models.Enums;
using TaskManagementSystem.Models.Enums.Statuses;

namespace TaskManagementSystem.Models
{
    public class Story : TaskItem, IStory
    {
        public Story(
            int id, 
            string title, 
            string desciption,
            Priority priority,
            Size size
        ) 
            : base(id, title, desciption)
        {
            this.Status = StoryStatus.NotDone;
            this.Assignee = null;

            this.Priority = priority;
            this.Size = size;
        }

        public Priority Priority { get; private set; }

        public Size Size { get; private set; }

        public StoryStatus Status { get; private set; }

        public IMember Assignee { get; private set; }

        public void UpdatePriority(Priority priority)
        {
            this.Priority = priority;
        }

        public void UpdateSize(Size size)
        {
            this.Size = size;
        }

        public void UpdateStatus(StoryStatus status)
        {
            this.Status = status;
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
