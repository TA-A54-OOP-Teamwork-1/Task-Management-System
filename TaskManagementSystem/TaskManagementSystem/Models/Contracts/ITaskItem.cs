namespace TaskManagementSystem.Models.Contracts
{
    public interface ITaskItem : ICommentable
    {
        int ID { get; }

        string Title { get; }

        string Description { get; }

        IReadOnlyCollection<string> History { get; }
    }
}
