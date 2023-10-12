using TaskManagementSystem.Core.Contracts;
using TaskManagementSystem.Helpers;

namespace TaskManagementSystem.Commands
{
    public class CreateMemberCommand : BaseCommand
    {
        private const int ExpectedParametersCount = 2;

        public CreateMemberCommand(IList<string> parameters, IRepository repository)
            : base(parameters, repository)
        {
        }

        public override string Execute()
        {
            // Validate parameters
            base.ValidateParametersCount(ExpectedParametersCount);

            // Extract name from parameters
            string name = Parameters[0];

            // Extract team name to add member to, from parameters
            //string teamName = Parameters[1];

            base.Repository.CreateMember(name);
            
            return $"New Member with name {name} was created.";
        }
    }
}
