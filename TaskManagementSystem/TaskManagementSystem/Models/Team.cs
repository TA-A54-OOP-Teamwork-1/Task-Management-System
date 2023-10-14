using TaskManagementSystem.Helpers;
using TaskManagementSystem.Models.Contracts;

namespace TaskManagementSystem.Models
{
    public class Team : ITeam
    {
        private const int NameMinLength = 5;
        private const int NameMaxLength = 15;

        private string name;
        private List<IPerson> people;
        private List<IBoard> boards;

        public Team(string name)
        {
            this.people = new List<IPerson>();
            this.boards = new List<IBoard>();
            
            this.Name = name;
        }

        public string Name
        {
            get { return this.name; }
            init
            {
                ValidationHelper.ValidateString(value, NameMinLength, NameMaxLength, nameof(this.Name));
                this.name = value;
            }
        }

        public IReadOnlyCollection<IPerson> People
        {
            get { return this.people; }
        }

        public IReadOnlyCollection<IBoard> Boards
        {
            get { return this.boards; }
        }

        public void AddPerson(IPerson person)
        {
            this.people.Add(person);
        }

        public void AddBoard(IBoard board)
        {
            this.boards.Add(board);
        }
    }
}
