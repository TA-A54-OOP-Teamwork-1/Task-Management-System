using TaskManagementSystem.Helpers;
using TaskManagementSystem.Models.Contracts;

namespace TaskManagementSystem.Models
{
    public class Team : ITeam
    {
        private const int NameMinLength = 5;
        private const int NameMaxLength = 15;

        private const string NameIsNullErrorMessage = "Name cannot be null!";
        private const string InvalidNameLengthErrorMessage = "Name must be between {0} and {1} symbols long!";

        private string name;
        private List<IMember> members;
        private List<IBoard> boards;

        public Team(string name)
        {
            this.members = new List<IMember>();
            this.boards = new List<IBoard>();
            
            this.Name = name;
        }

        public string Name
        {
            get { return this.name; }
            init
            {
                ValidationHelper.ValidateNull(value, NameIsNullErrorMessage);
                ValidationHelper.ValidateIntRange(value.Length, NameMinLength,
                    NameMaxLength, string.Format(InvalidNameLengthErrorMessage, NameMinLength, NameMaxLength));

                this.name = value;
            }
        }

        public IReadOnlyCollection<IMember> Members
        {
            get { return this.members; }
        }

        public IReadOnlyCollection<IBoard> Boards
        {
            get { return this.boards; }
        }

        public void AddMember(IMember member)
        {
            this.members.Add(member);
        }

        public void AddBoard(IBoard board)
        {
            this.boards.Add(board);
        }
    }
}
