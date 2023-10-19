using System.Text;
using TaskManagementSystem.Core.Contracts;
using TaskManagementSystem.Exceptions;

namespace TaskManagementSystem.Commands
{
    public class ShowAllTeamBoardsCommand : BaseCommand
    {
        private const string NoBoardsErrorMessage = "No boards are present in team {0}!";

        private const int ExpectedParametersCount = 1;

        public ShowAllTeamBoardsCommand(IList<string> parameters, IRepository repository)
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
                throw new EmptyListException(string.Format(NoBoardsErrorMessage, teamName));
            }

            StringBuilder output = new StringBuilder();

            team.Boards
                .ToList()
                .ForEach(board => output.AppendLine(board.ToString()));

            output.Append("End of displaying!");

            return output.ToString();
        }
    }
}
