namespace TaskManagementSystem.Models.Contracts
{
    public interface IBoard : IHasName
    {
        IReadOnlyCollection<ITaskItem> Tasks { get; }

        IReadOnlyCollection<string> ActivityHistory { get; }
    }
}
