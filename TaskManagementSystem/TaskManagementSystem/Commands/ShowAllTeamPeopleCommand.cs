using System.Text;
using TaskManagementSystem.Core.Contracts;
using TaskManagementSystem.Exceptions;

namespace TaskManagementSystem.Commands
{
    public class ShowAllTeamPeopleCommand : BaseCommand
    {
        private const string NoPeopleErrorMessage = "No people are present in team {0}!";

        private const int ExpectedParametersCount = 1;

        public ShowAllTeamPeopleCommand(IList<string> parameters, IRepository repository)
            : base(parameters, repository)
        {
        }

        public override string Execute()
        {
            base.ValidateParametersCount(ExpectedParametersCount);

            var teamName = base.Parameters[0];
            var team = base.Repository.GetTeamByName(teamName);

            if (!team.People.Any())
            {
                throw new EmptyListException(string.Format(NoPeopleErrorMessage, teamName));
            }

            StringBuilder output = new StringBuilder();

            team.People
                .ToList()
                .ForEach(member => output.AppendLine(member.ToString()));

            output.Append("End of displaying!");

            return output.ToString();
        }
    }
}
