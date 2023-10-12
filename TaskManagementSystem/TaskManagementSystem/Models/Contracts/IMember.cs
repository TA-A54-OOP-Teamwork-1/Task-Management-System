namespace TaskManagementSystem.Models.Contracts
{
    public interface IMember : IHasName
    {
        IReadOnlyCollection<ITaskItem> Tasks { get; }

        IReadOnlyCollection<string> ActivityHistory { get; }

        void AddTask(ITaskItem task);

        void LogActivityHistory(string log);
    }
}
