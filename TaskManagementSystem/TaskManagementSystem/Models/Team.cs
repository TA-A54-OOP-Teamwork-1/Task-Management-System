using TaskManagementSystem.Helpers;
using TaskManagementSystem.Models.Contracts;

namespace TaskManagementSystem.Models
{
    public class Team : ITeam
    {
        private const int NameMinLength = 5;
        private const int NameMaxLength = 15;

        private readonly string NameIsNullError = "Name cannot be null!";
        private readonly string InvalidNameLengthError = $"Name must be between {NameMinLength} and {NameMaxLength} symbols long!";

        private string name;
        private List<IPerson> members;
        private List<IBoard> boards;

        public Team(string name)
        {
            this.members = new List<IPerson>();
            this.boards = new List<IBoard>();
            
            this.Name = name;
        }

        public string Name
        {
            get { return this.name; }
            init
            {
                ValidationHelper.StringIsNull(value, NameIsNullError);
                ValidationHelper.ValidateIntRange(value.Length, NameMinLength,
                    NameMaxLength, InvalidNameLengthError);
            }
        }

        public IReadOnlyCollection<IPerson> Members { get; }

        public IReadOnlyCollection<IBoard> Boards { get; }

        public void AddMember(IPerson member) => this.members.Add(member);

        public void AddBoard(IBoard board) => this.boards.Add(board);
    }
}
