namespace TaskManagementSystem.Models.Contracts
{
    public interface IPerson : IHasName, ITrackable
    {
        IReadOnlyCollection<IAssignable> Tasks { get; }

        void AssignTask(IAssignable task);

        void UnassignTask(IAssignable task);
    }
}
