using TaskManagementSystem.Core.Contracts;
using TaskManagementSystem.Models.Contracts;
using TaskManagementSystem.Models.Enums;

namespace TaskManagementSystem.Commands
{
    public class ChangeBugSeverityCommand : BaseCommand
    {
        private const int ExpectedParametersCount = 2;

        public ChangeBugSeverityCommand(IList<string> parameters, IRepository repository)
            : base(parameters, repository)
        {
        }

        public override string Execute()
        {
            base.ValidateParametersCount(ExpectedParametersCount);

            int bugID = base.ParseInt(base.Parameters[0]);
            Severity severity = base.ParseEnum<Severity>(base.Parameters[1]);

            IBug bug = (IBug)base.GetTask(bugID, string.Format(NotExistentErrorMessage, "Bug", bugID));

            base.Repository.ChangeBugSeverity(bug, severity);

            return $"Priority of Bug with ID {bugID} changed to {severity}";
        }
    }
}
