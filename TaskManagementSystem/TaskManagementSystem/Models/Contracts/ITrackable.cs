namespace TaskManagementSystem.Models.Contracts
{
    public interface ITrackable
    {
        IReadOnlyCollection<string> ActivityHistory { get; }

        string LastActivity { get; }
    }
}
