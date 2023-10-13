namespace TaskManagementSystem.Models.Contracts
{
    public interface ITeam : IHasName
    {
        IReadOnlyCollection<string> MemberNames { get; }

        IReadOnlyCollection<IBoard> Boards { get; }

        void AddMemberName(string memberName);

        void AddBoard(IBoard board);
    }
}
