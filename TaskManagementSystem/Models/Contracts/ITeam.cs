namespace TaskManagementSystem.Models.Contracts
{
    public interface ITeam : IHasName
    {
        IReadOnlyCollection<IPerson> People { get; }

        IReadOnlyCollection<IBoard> Boards { get; }

        void AddPerson(IPerson person);

        void AddBoard(IBoard board);
    }
}
