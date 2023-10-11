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
            Size size,
            IPerson assignee) 
            : base(id, title, desciption)
        {
            this.Status = StoryStatus.NotDone;

            this.Priority = priority;
            this.Size = size;
            this.Assignee = assignee;
        }

        public Priority Priority { get; private set; }

        public Size Size { get; private set; }

        public StoryStatus Status { get; private set; }

        public IPerson Assignee { get; private set; }
    }
}
