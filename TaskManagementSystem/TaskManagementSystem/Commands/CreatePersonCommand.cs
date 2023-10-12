using TaskManagementSystem.Core.Contracts;
using TaskManagementSystem.Helpers;

namespace TaskManagementSystem.Commands
{
    public class CreatePersonCommand : BaseCommand
    {
        private const int ExpectedParametersCount = 2;

        public CreatePersonCommand(IList<string> parameters, IRepository repository)
            : base(parameters, repository)
        {
        }

        public override string Execute()
        {
            // Validate parameters
            base.ValidateParametersCount(ExpectedParametersCount);

            // Extract name from parameters
            string name = Parameters[0];

            // Extract team name to add person to, from parameters
            string teamName = Parameters[1];

            //Repository.CreatePerson(name, teamName);
            
            return $"New Person with name {name} was created and added to team {teamName}.";
        }
    }
}
