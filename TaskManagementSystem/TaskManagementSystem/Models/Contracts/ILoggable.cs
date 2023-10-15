namespace TaskManagementSystem.Models.Contracts
{
    public interface ILoggable
    {
        IReadOnlyCollection<string> ActivityHistory { get; }

        string LastActivity { get; }
    }
}
