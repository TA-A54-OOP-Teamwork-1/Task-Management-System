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
            : base(id, title, desciption, TaskType.Story)
        {
            this.Status = StoryStatus.NotDone;
            this.Assignee = null;

            this.Priority = priority;
            this.Size = size;
        }

        public Priority Priority { get; private set; }

        public Size Size { get; private set; }

        public StoryStatus Status { get; private set; }

        public IPerson Assignee { get; private set; }

        public void ChangePriority(Priority priority)
        {
            this.Priority = priority;
        }

        public void ChangeSize(Size size)
        {
            this.Size = size;
        }

        public void ChangeStatus(StoryStatus status)
        {
            this.Status = status;
        }
        
        public void SetAssignee(IPerson person)
        {
            this.Assignee = person;
        }

        public void RemoveAssignee()
        {
            this.Assignee = null;
        }
    }
}
