﻿using TaskManagementSystem.Core.Contracts;
using TaskManagementSystem.Models.Contracts;
using TaskManagementSystem.Models.Enums.Statuses;

namespace TaskManagementSystem.Commands
{
    public class ChangeFeedbackStatusCommand : BaseCommand
    {
        private const int ExpectedParametersCount = 2;

        public ChangeFeedbackStatusCommand(IList<string> parameters, IRepository repository) 
            : base(parameters, repository)
        {
        }

        public override string Execute()
        {
            base.ValidateParametersCount(ExpectedParametersCount);

            var feedbackID = base.ParseInt(base.Parameters[0]);
            var status = base.ParseEnum<FeedbackStatus>(base.Parameters[1]);

            var feedback = base.Repository.GetTaskByID<IFeedback>(feedbackID);
            var log = base.Repository.UpdateFeedbackStatus(feedback, status);

            feedback.LogActivity(log);
            return log;
        }
    }
}