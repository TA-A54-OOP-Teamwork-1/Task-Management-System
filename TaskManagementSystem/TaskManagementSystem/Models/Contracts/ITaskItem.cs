using TaskManagementSystem.Models.Enums;

namespace TaskManagementSystem.Models.Contracts
{   
    public interface ITaskItem : ICommentable
    {
        TaskType TaskType { get; }

        int ID { get; }

        string Title { get; }

        string Description { get; }

        IReadOnlyCollection<string> History { get; }

        public void LogActivityHistory(string log);
    }
}
