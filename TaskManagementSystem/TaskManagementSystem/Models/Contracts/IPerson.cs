namespace TaskManagementSystem.Models.Contracts
{
    public interface IPerson : IHasName, ILoggable
    {
        IReadOnlyCollection<IAssignable> Tasks { get; }

        void AddTask(IAssignable task);

        void RemoveTask(IAssignable task);
    }
}
