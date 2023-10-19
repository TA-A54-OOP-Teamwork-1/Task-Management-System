using System.Text;
using TaskManagementSystem.Core.Contracts;
using TaskManagementSystem.Exceptions;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.Commands
{
    public class ShowTeamActivityCommand : BaseCommand
    {
        private const string NoTeamActivityErrorMessage = "Team with name {0} has no activity logged yet!";

        private const int ExpectedParametersCount = 1;

        public ShowTeamActivityCommand(IList<string> parameters, IRepository repository)
            : base(parameters, repository)
        {
        }

        public override string Execute()
        {
            base.ValidateParametersCount(ExpectedParametersCount);

            var teamName = base.Parameters[0];
            var team = base.Repository.GetTeamByName(teamName);

            if (!team.Boards.Any())
            {
                throw new EmptyListException(string.Format(NoTeamActivityErrorMessage, teamName));
            }

            StringBuilder output = new StringBuilder();

            team.Boards
                .SelectMany(board => board.ActivityHistory)
                .ToList()
                .ForEach(logEntry => logEntry.ToString());
            
            output.Append("End of displaying!");

            return output.ToString();
        }
    }
}
