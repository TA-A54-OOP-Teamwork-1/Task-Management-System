using TaskManagementSystem.Core.Contracts;

namespace TaskManagementSystem.Commands
{
    public class CreateTeamCommand : BaseCommand
    {
        private const int ExpectedParametersCount = 1;

        public CreateTeamCommand(IList<string> parameters, IRepository repository)
            : base(parameters, repository)
        {
        }

        public override string Execute()
        {
            // Validate parameters
            base.ValidateParametersCount(ExpectedParametersCount);

            // Extract name from parameters
            string name = Parameters[0];

            Repository.CreateTeam(name);

            return $"A new team with name {name} was created.";
        }
    }
}
