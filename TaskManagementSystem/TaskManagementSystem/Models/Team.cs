using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Models.Contracts;

namespace TaskManagementSystem.Models
{
    public class Team : ITeam
    {
        public Team(string name)
        {
            this.Name = name;
            Members = new List<IPerson>();
            Boards = new List<IBoard>();
        }

        public string Name { get; }

        public IReadOnlyCollection<IPerson> Members { get; }

        public IReadOnlyCollection<IBoard> Boards { get; }
    }
}
