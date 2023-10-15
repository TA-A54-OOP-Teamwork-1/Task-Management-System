namespace TaskManagementSystem.Models.Contracts
{
    public interface IPerson : IHasName, ILoggable
    {
        IReadOnlyCollection<IAssignable> Tasks { get; }

        void AssignTask(IAssignable task);

        void UnassignTask(IAssignable task);
    }
}
