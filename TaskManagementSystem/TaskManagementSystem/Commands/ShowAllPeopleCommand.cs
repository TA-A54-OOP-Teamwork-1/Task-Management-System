using System.Text;
using TaskManagementSystem.Core.Contracts;
using TaskManagementSystem.Exceptions;

namespace TaskManagementSystem.Commands
{
    public class ShowAllPeopleCommand : BaseCommand
    {
        private const string NoPeopleErrorMessage = "No people are present in the application!";

        private const int ExpectedParametersCount = 0;

        public ShowAllPeopleCommand(IList<string> parameters, IRepository repository)
            : base(parameters, repository)
        {
        }

        public override string Execute()
        {
            base.ValidateParametersCount(ExpectedParametersCount);

            if (!base.Repository.People.Any())
            {
                throw new EmptyListException(NoPeopleErrorMessage);
            }

            StringBuilder output = new StringBuilder();

            base.Repository.People
                .ToList()
                .ForEach(person => output.AppendLine(person.ToString()));

            return output.ToString();
        }
    }
}
