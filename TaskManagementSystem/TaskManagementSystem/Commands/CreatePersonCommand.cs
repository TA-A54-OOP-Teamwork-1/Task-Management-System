using TaskManagementSystem.Core.Contracts;
using TaskManagementSystem.Exceptions;

namespace TaskManagementSystem.Commands
{
    public class CreatePersonCommand : BaseCommand
    {
        private const string PersonAlreadyExistsErrorMessage = "Person with name {0} already exists!";

        private const int ExpectedParametersCount = 1;

        public CreatePersonCommand(IList<string> parameters, IRepository repository)
            : base(parameters, repository)
        {
        }

        public override string Execute()
        {
            base.ValidateParametersCount(ExpectedParametersCount);

            var personName = Parameters[0];

            if (base.Repository.PersonExists(personName))
            {
                throw new InvalidUserInputException(string.Format(PersonAlreadyExistsErrorMessage, personName));
            }

            var person = base.Repository.CreatePerson(personName);
            var log = $"Person with name {person.Name} was created.";
            person.LogActivity(log);

            return log;
        }
    }
}
