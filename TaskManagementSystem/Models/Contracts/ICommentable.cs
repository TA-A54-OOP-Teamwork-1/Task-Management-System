namespace TaskManagementSystem.Models.Contracts
{
    public interface ICommentable
    {
        IReadOnlyCollection<IComment> Comments { get; }

        void AddComment(IComment comment);
    }
}
