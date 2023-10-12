namespace TaskManagementSystem.Models.Contracts
{
    public interface ITeam : IHasName
    {
        IReadOnlyCollection<IPerson> Members { get; }

        IReadOnlyCollection<IBoard> Boards { get; }

        public void AddMember(IPerson member);

        public void AddBoard(IBoard board);
    }
}
