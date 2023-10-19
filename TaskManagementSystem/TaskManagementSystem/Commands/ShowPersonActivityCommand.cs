using System.Text;
using TaskManagementSystem.Core.Contracts;

namespace TaskManagementSystem.Commands
{
    public class ShowPersonActivityCommand : BaseCommand
    {
        private const int ExpectedParametersCount = 1;

        public ShowPersonActivityCommand(IList<string> parameters, IRepository repository)
            : base(parameters, repository)
        {
        }

        public override string Execute()
        {
            base.ValidateParametersCount(ExpectedParametersCount);

            var personName = base.Parameters[0];
            var person = base.Repository.GetPersonByName(personName);

            StringBuilder output = new StringBuilder();

            person.ActivityHistory
                .ToList()
                .ForEach(logEntry => output.AppendLine(logEntry.ToString()));

            output.Append("End of displaying!");

            return output.ToString();
        }
    }
}
