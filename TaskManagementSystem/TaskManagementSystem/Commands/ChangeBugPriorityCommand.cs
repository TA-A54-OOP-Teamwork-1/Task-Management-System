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

            var bugID = base.ParseInt(base.Parameters[0]);
            var priority = base.ParseEnum<Priority>(base.Parameters[1]);

            var bug = base.Repository.GetTaskByID<IBug>(bugID);
            var result = base.Repository.UpdateBugPriority(bug, priority);

            return result;
        }              
    }
}
