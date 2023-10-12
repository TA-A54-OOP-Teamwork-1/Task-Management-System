using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Core.Contracts;
using TaskManagementSystem.Models.Contracts;
using TaskManagementSystem.Models.Enums;
using TaskManagementSystem.Models.Enums.Statuses;

namespace TaskManagementSystem.Commands
{
    public class CreateNewBugCommand : BaseCommand
    {
        private const int ExpectedParametersCount = 7;

        public CreateNewBugCommand(IList<string> parameters, IRepository repository)
            : base(parameters, repository)
        {
        }

        public override string Execute()
        {
            // Validate parameters
            base.ValidateParametersCount(ExpectedParametersCount);

            // Extract title from parameters
            string title = Parameters[0];

            // Description
            string description = Parameters[1];

            // Priority
            Priority bugPriority = base.ParseEnum<Priority>(Parameters[2]);

            // Severity
            Severity bugSeverity = base.ParseEnum<Severity>(Parameters[3]);

            // Assignee
            IPerson assignee = null; // Parameters[4];

            // Steps to reproduce
            string[] steps = Parameters[5].Split(", ");

            // Board ID
            int.TryParse(Parameters[6], out int boardID);

            // 
            //Repository.CreateNewBug(title, description, bugPriority, bugSeverity, assignee, steps.ToList(), boardID);

            return "New Bug was created.";
        }
    }
}
