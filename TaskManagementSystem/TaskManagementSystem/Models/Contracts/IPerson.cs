namespace TaskManagementSystem.Models.Contracts
{
    public interface IPerson : IHasName
    {
        IReadOnlyCollection<ITaskItem> Tasks { get; }

        IReadOnlyCollection<string> ActivityHistory { get; }

        void AddTask(ITaskItem task);

        void LogActivityHistory(string log);
    }
}
