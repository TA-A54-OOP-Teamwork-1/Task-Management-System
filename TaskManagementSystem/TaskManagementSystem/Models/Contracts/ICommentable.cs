namespace TaskManagementSystem.Models.Contracts
{
    public interface ICommentable
    {
        IReadOnlyCollection<IComment> Comments { get; }
    }
}
