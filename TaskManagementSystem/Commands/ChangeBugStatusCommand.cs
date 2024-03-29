﻿using System.Runtime.CompilerServices;
using TaskManagementSystem.Core.Contracts;
using TaskManagementSystem.Exceptions;
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

            var bugID = base.ParseInt(base.Parameters[0]);
            var status = base.ParseEnum<BugStatus>(base.Parameters[1]);

            var bug = base.Repository.GetTaskByID<IBug>(bugID);

            base.EnsureNotEqual(status, bug.Status);

            var result = base.Repository.UpdateBugStatus(bug, status);

            return result;
        }
    }
}
