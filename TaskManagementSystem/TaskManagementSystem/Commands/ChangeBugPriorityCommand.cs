using TaskManagementSystem.Core.Contracts;
using TaskManagementSystem.Models.Contracts;
using TaskManagementSystem.Models.Enums;

namespace TaskManagementSystem.Commands
{
    public class ChangeBugPriorityCommand : BaseCommand
    {           
        private const int ExpectedParametersCount = 2;

        public ChangeBugPriorityCommand(IList<string> parameters, IRepository repository) 
            : base(parameters, repository)
        {
        }

        public override string Execute()
        {
            base.ValidateParametersCount(ExpectedParametersCount);

            int bugID = base.ParseInt(base.Parameters[0]);
            Priority priority = base.ParseEnum<Priority>(base.Parameters[1]);

            IBug bug = (IBug)base.GetTask(bugID, string.Format(NotExistentErrorMessage, "Bug", bugID));

            base.Repository.ChangeBugPriority(bug, priority);

            return $"Priority of Bug with ID {bugID} changed to {priority}";
        }              
    }
}
