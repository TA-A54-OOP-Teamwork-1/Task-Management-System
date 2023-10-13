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
            base.ValidateParametersCount(ExpectedParametersCount);

            string name = Parameters[0];

            base.Repository.CreateTeam(name);

            return $"New team with name {name} was created.";
        }
    }
}
