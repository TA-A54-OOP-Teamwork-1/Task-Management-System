namespace TaskManagementSystem.Models.Contracts
{
    public interface ITrackable
    {
        IReadOnlyCollection<IEvent> ActivityHistory { get; }

        string LastActivity { get; }
    }
}
