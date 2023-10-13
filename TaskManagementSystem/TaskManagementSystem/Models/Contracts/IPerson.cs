namespace TaskManagementSystem.Models.Contracts
{
    public interface IPerson : IHasName
    {
        IReadOnlyCollection<IAssignable> Tasks { get; }

        IReadOnlyCollection<string> ActivityHistory { get; }

        void AddTask(IAssignable task);

        void RemoveTask(IAssignable task);

        void LogActivityHistory(string log);
    }
}
