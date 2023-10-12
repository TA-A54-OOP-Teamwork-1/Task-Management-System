namespace TaskManagementSystem.Models.Contracts
{
    public interface ITeam : IHasName
    {
        IReadOnlyCollection<IMember> Members { get; }

        IReadOnlyCollection<IBoard> Boards { get; }

        void AddMember(IMember member);

        void AddBoard(IBoard board);
    }
}
