namespace TaskManagementSystem.Models.Contracts
{
    public interface ITeam : IHasName
    {
        IReadOnlyCollection<IPerson> Members { get; }

        IReadOnlyCollection<IBoard> Boards { get; }

        void AddMember(IPerson member);

        void AddBoard(IBoard board);
    }
}
