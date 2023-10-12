using TaskManagementSystem.Core.Contracts;
using TaskManagementSystem.Models.Contracts;
using TaskManagementSystem.Models.Enums.Statuses;

namespace TaskManagementSystem.Commands
{
    public class ChangeBugStatusCommand : BaseCommand
    {
        private const int ExpectedParametersCount = 2;

        public ChangeBugStatusCommand(IList<string> parameters, IRepository repository)
            : base(parameters, repository)
        {
        }

        public override string Execute()
        {
            base.ValidateParametersCount(ExpectedParametersCount);

            int bugID = base.ParseInt(base.Parameters[0]);
            BugStatus status = base.ParseEnum<BugStatus>(base.Parameters[1]);

            base.Repository.ChangeBugStatus(bugID, status);

            return $"Priority of Bug with ID {bugID} changed to {status}";
        }
    }
}
