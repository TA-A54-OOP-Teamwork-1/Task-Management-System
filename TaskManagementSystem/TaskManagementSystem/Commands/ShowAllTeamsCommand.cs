using System.Text;
using TaskManagementSystem.Core.Contracts;
using TaskManagementSystem.Exceptions;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.Commands
{
    public class ShowAllTeamsCommand : BaseCommand
    {
        private const string NoTeamsErrorMessage = "No teams are present in the application!";

        private const int ExpectedParametersCount = 0;

        public ShowAllTeamsCommand(IList<string> parameters, IRepository repository)
            : base(parameters, repository)
        {
        }

        public override string Execute()
        {
            base.ValidateParametersCount(ExpectedParametersCount);

            if (!base.Repository.Teams.Any())
            {
                throw new EmptyListException(NoTeamsErrorMessage);
            }

            StringBuilder output = new StringBuilder();

            base.Repository.Teams
                .ToList()
                .ForEach(team => output.AppendLine(team.ToString()));

            output.Append("End of displaying!");

            return output.ToString();
        }
    }
}
