using TaskManagementSystem.Core.Contracts;

namespace TaskManagementSystem.Commands
{
    public class CreatePersonCommand : BaseCommand
    {
        private const int ExpectedParametersCount = 1;

        public CreatePersonCommand(IList<string> parameters, IRepository repository)
            : base(parameters, repository)
        {
        }

        public override string Execute()
        {
            base.ValidateParametersCount(ExpectedParametersCount);

            string name = Parameters[0];

            base.Repository.CreatePerson(name);
            
            return $"New person with name {name} was created.";
        }
    }
}
