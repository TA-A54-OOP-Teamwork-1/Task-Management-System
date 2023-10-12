using TaskManagementSystem.Core.Contracts;
using TaskManagementSystem.Models.Contracts;

namespace TaskManagementSystem.Commands
{
    public class CreateBoardCommand : BaseCommand
    {
        private const int ExpectedParametersCount = 2;

        public CreateBoardCommand(IList<string> parameters, IRepository repository)
            : base(parameters, repository)
        {
        }

        public override string Execute()
        {
            // Validate parameters
            base.ValidateParametersCount(ExpectedParametersCount);

            // Extract board name from parameters
            string boardName = Parameters[0];

            // Extract team name from parameters
            string teamName = Parameters[1];

            ITeam team = base.Repository.GetTeam(teamName);

            Repository.CreateNewBoardInTeam(boardName, teamName);

            return $"New board with name {boardName} was created and added to to team {teamName}";
        }
    }
}