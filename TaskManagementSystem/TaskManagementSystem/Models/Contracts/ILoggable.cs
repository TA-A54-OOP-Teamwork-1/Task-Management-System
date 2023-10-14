namespace TaskManagementSystem.Models.Contracts
{
    public interface ILoggable
    {
        IReadOnlyCollection<string> ActivityHistory { get; }

        void LogActivity(string log);
    }
}
