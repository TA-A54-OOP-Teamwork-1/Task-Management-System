using TaskManagementSystem.Core.Contracts;
using TaskManagementSystem.Models.Enums;

namespace TaskManagementSystem.Commands
{
    public class CreateNewBugCommand : BaseCommand
    {
        private const int ExpectedParametersCount = 6;

        public CreateNewBugCommand(IList<string> parameters, IRepository repository)
            : base(parameters, repository)
        {
        }

        public override string Execute()
        {
            base.ValidateParametersCount(ExpectedParametersCount);
            
            string title = base.Parameters[0];
            string description = base.Parameters[1];
            Priority priority = base.ParseEnum<Priority>(base.Parameters[2]);
            Severity severity = base.ParseEnum<Severity>(base.Parameters[3]);
            IReadOnlyCollection<string> steps = base.Parameters[4].Split(";");
            string boardName = base.Parameters[5];

            base.Repository.CreateNewBug(title, description, priority, severity, steps, boardName);

            return "New bug was created.";
        }
    }
}
