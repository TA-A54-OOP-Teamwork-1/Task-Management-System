using TaskManagementSystem.Core.Contracts;

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

            string boardName = Parameters[0];
            string teamName = Parameters[1];

            base.Repository.CreateNewBoardInTeam(boardName, teamName);

            return $"New board with name {boardName} was created and added to to team {teamName}";
        }
    }
}