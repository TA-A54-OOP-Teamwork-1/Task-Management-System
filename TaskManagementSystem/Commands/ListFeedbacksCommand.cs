﻿using System.Text;

using TaskManagementSystem.Core.Contracts;
using TaskManagementSystem.Exceptions;
using TaskManagementSystem.Models.Contracts;
using TaskManagementSystem.Models.Enums.Statuses;
using TaskManagementSystem.Models.Enums;

namespace TaskManagementSystem.Commands
{
    public class ListFeedbacksCommand : BaseCommand
    {
        private const string EmptyFeedbacksListErrorMessage = "No feedbacks to display.";

        private const int ExpectedParametersMinCount = 2;
        private const int ExpectedParametersMaxCount = 3;

        public ListFeedbacksCommand(IList<string> parameters, IRepository repository) 
            : base(parameters, repository)
        {
        }

        public override string Execute()
        {
            base.ValidateParametersCount(ExpectedParametersMinCount, ExpectedParametersMaxCount);

            var feedbacks = this.FilterFeedbacks();

            this.ValidateEmptyList(feedbacks);
            base.ValidateInputFormat();

            if (base.Parameters.Contains("-fs"))
            {
                var status = base.ParseEnum<FeedbackStatus>(base.Parameters[1]);
                feedbacks = this.FilterByStatus(feedbacks, status);
            }

            this.ValidateEmptyList(feedbacks);

            if (base.Parameters.Contains("-st"))
            {
                feedbacks = this.SortByTitle(feedbacks);
            }
            else if (base.Parameters.Contains("-sr"))
            {
                feedbacks = this.SortByRating(feedbacks);
            }

            var output = new StringBuilder();
            feedbacks.ForEach(f => output.AppendLine(f.ToString()));

            return output.ToString();
        }

        private void ValidateEmptyList(List<IFeedback> feedbacks)
        {
            if (!feedbacks.Any())
            {
                throw new EmptyListException(EmptyFeedbacksListErrorMessage);
            }
        }

        private List<IFeedback> FilterFeedbacks()
        {
            return base.Repository.GetAllTasks()
                .Where(t => t.TaskType == TaskType.Feedback)
                .Select(t => (IFeedback)t)
                .ToList();
        }

        private List<IFeedback> FilterByStatus(List<IFeedback> feedbacks, FeedbackStatus status)
        {
            return feedbacks
                .Where(f => f.Status == status)
                .ToList();
        }

        private List<IFeedback> SortByTitle(List<IFeedback> feedbacks)
        {
            return feedbacks
                .OrderBy(f => f.Title)
                .ToList();
        }

        private List<IFeedback> SortByRating(List<IFeedback> feedbacks)
        {
            return feedbacks
                .OrderBy(f => f.Rating)
                .ToList();
        }
    }
}
