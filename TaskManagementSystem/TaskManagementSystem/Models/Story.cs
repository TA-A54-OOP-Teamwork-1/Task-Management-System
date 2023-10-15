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
            var previousPriority = this.Priority;
            this.Priority = priority;

            base.LogActivity($"Priority of [Story - ID: {this.ID}] changed from {previousPriority} to {priority}.");
        }

        public void ChangeSize(Size size)
        {
            var previousSize = this.Size;
            this.Size = size;

            base.LogActivity($"Size of [Story - ID: {this.ID}] changed from {previousSize} to {size}.");
        }

        public void ChangeStatus(StoryStatus status)
        {
            var previousStatus = this.Status;
            this.Status = status;

            base.LogActivity($"Status of [Story - ID: {this.ID}] changed from {previousStatus} to {status}.");
        }
        
        public void SetAssignee(IPerson person)
        {
            this.Assignee = person;
            base.LogActivity($"Person with name {person.Name} has been set as assignee to Story with ID {this.ID}.");
        }

        public void RemoveAssignee()
        {
            this.Assignee = null;
            base.LogActivity($"Assignee removed.");
        }
    }
}
