namespace TaskManagementSystem.Models.Contracts
{
    public interface ITeam : IHasName
    {
        IReadOnlyCollection<IPerson> Members { get; }

        IReadOnlyCollection<IBoard> Boards { get; }
    }
}
