using TaskManagementSystem.Core.Contracts;
using TaskManagementSystem.Exceptions;

namespace TaskManagementSystem.Commands
{
    public class CreateTeamCommand : BaseCommand
    {
        private const string TeamAlreadyExistsErrorMessage = "Team with name {0} already exists!";

        private const int ExpectedParametersCount = 1;

        public CreateTeamCommand(IList<string> parameters, IRepository repository)
            : base(parameters, repository)
        {
        }

        public override string Execute()
        {
            base.ValidateParametersCount(ExpectedParametersCount);

            var teamName = Parameters[0];

            if (base.Repository.TeamExists(teamName))
            {
                throw new InvalidUserInputException(string.Format(TeamAlreadyExistsErrorMessage, teamName));
            }

            var team = base.Repository.CreateTeam(teamName);

            return $"Team with name {team.Name} was created.";
        }
    }
}
