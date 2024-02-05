using System.Text;

using TaskManagementSystem.Core.Contracts;
using TaskManagementSystem.Exceptions;
using TaskManagementSystem.Models.Enums.Statuses;
using TaskManagementSystem.Models.Contracts;
using TaskManagementSystem.Models.Enums;

namespace TaskManagementSystem.Commands
{
    public class ListTasksWithAssigneeCommand : BaseCommand
    {
        private const string EmptyAssignableTasksListErrorMessage = "No assigned tasks to display.";
        private const string StatusDoesNotExistErrorMessage = "No such status {0}!";

        private const int ExpectedParametersMinCount = 2;
        private const int ExpectedParamentersMaxCount = 4;

        public ListTasksWithAssigneeCommand(IList<string> parameters, IRepository repository) : base(parameters, repository)
        {
        }

        public override string Execute()
        {
            base.ValidateParametersCount(ExpectedParametersMinCount, ExpectedParamentersMaxCount);

            var assignableTasks = new List<IAssignable>(base.Repository.AssignableTasks);

            this.ValidateEmptyList(assignableTasks);
            base.ValidateInputFormat();

            if (base.Parameters.Contains("-fsa"))
            {
                var statusInput = base.Parameters[1];

                if (Enum.TryParse(statusInput, out BugStatus bugStatus))
                {
                    assignableTasks = this.FilterByBugStatus(assignableTasks, bugStatus);
                }
                else if (Enum.TryParse(statusInput, out StoryStatus storyStatus))
                {
                    assignableTasks = this.FilterByStoryStatus(assignableTasks, storyStatus);
                }
                else
                {
                    throw new InvalidUserInputException(string.Format(StatusDoesNotExistErrorMessage, statusInput));
                }

                var assignee = base.Repository.GetPersonByName(base.Parameters[1]);
                assignableTasks = this.FilterByAssignee(assignableTasks, assignee);
            }
            else if (base.Parameters.Contains("-fs"))
            {
                var statusInput = base.Parameters[0];

                if (Enum.TryParse(statusInput, out BugStatus bugStatus))
                {
                    assignableTasks = this.FilterByBugStatus(assignableTasks, bugStatus);
                }
                else if (Enum.TryParse(statusInput, out StoryStatus storyStatus))
                {
                    assignableTasks = this.FilterByStoryStatus(assignableTasks, storyStatus);
                }
                else
                {
                    throw new InvalidUserInputException(string.Format(StatusDoesNotExistErrorMessage, statusInput));
                }
            }
            else if (base.Parameters.Contains("-fa"))
            {
                var assignee = base.Repository.GetPersonByName(base.Parameters[0]);
                assignableTasks = this.FilterByAssignee(assignableTasks, assignee);
            }

            this.ValidateEmptyList(assignableTasks);

            if (base.Parameters.Contains("-st"))
            {
                assignableTasks = this.SortByTitle(assignableTasks);
            }

            var output = new StringBuilder();
            assignableTasks.ForEach(t => output.AppendLine(t.ToString()));

            return output.ToString();
        }

        private void ValidateEmptyList(List<IAssignable> assignableTasks)
        {
            if (!assignableTasks.Any())
            {
                throw new EmptyListException(EmptyAssignableTasksListErrorMessage);
            }
        }

        private List<IAssignable> FilterByAssignee(List<IAssignable> assignableTasks, IPerson assignee)
        {
            return assignableTasks
                .Where(t => t.Assignee == assignee)
                .ToList();
        }

        private List<IAssignable> SortByTitle(List<IAssignable> assignableTasks)
        {
             return assignableTasks
                .OrderBy(t => t.Title)
                .ToList();
        }

        private List<IAssignable> FilterByBugStatus(List<IAssignable> assignableTasks, BugStatus status)
        {
            return assignableTasks
                .Where(t => t.TaskType == TaskType.Bug)
                .Select(t => (IBug)t)
                .Where(b => b.Status == status)
                .Select(b => (IAssignable)b)
                .ToList();
        }

        private List<IAssignable> FilterByStoryStatus(List<IAssignable> assignableTasks, StoryStatus status)
        {
            return assignableTasks
                .Where(t => t.TaskType == TaskType.Story)
                .Select(t => (IStory)t)
                .Where(s => s.Status == status)
                .Select(s => (IAssignable)s)
                .ToList();
        }
    }
}
