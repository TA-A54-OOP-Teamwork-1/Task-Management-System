using System.Text;

using TaskManagementSystem.Core.Contracts;
using TaskManagementSystem.Exceptions;
using TaskManagementSystem.Models.Contracts;
using TaskManagementSystem.Models.Enums;
using TaskManagementSystem.Models.Enums.Statuses;

namespace TaskManagementSystem.Commands
{
    public class ListBugsCommand : BaseCommand
    {
        private const string EmptyBugsListErrorMessage = "No bugs to display.";
        private const string InvalidFormatErrorMessage = "Invalid input format!";

        private const int ExpectedParametersMinCount = 2;
        private const int ExpectedParametersMaxCount = 4;

        public ListBugsCommand(IList<string> parameters, IRepository repository) 
            : base(parameters, repository)
        {
        }

        public override string Execute()
        {
            base.ValidateParametersCount(ExpectedParametersMinCount, ExpectedParametersMaxCount);

            var bugs = this.FilterBugs();

            this.ValidateEmptyList(bugs);
            this.ValidateInputFormat(base.Parameters);

            if (base.Parameters.Contains("-fsa"))
            {
                var status = base.ParseEnum<BugStatus>(base.Parameters[1]);
                var assignee = base.Repository.GetPersonByName(base.Parameters[2]);

                bugs = this.FilterByStatus(bugs, status);
                bugs = this.FilterByAssignee(bugs, assignee);
            }
            else if (base.Parameters.Contains("-fs"))
            {
                var status = base.ParseEnum<BugStatus>(base.Parameters[1]);
                bugs = this.FilterByStatus(bugs, status);
            }
            else if (base.Parameters.Contains("-fa"))
            {
                var assignee = base.Repository.GetPersonByName(base.Parameters[1]);
                bugs = this.FilterByAssignee(bugs, assignee);
            }            

            if (base.Parameters.Contains("-st"))
            {
                bugs = this.SortByTitle(bugs);
            }
            else if (base.Parameters.Contains("-sp"))
            {
                bugs = this.SortByPriority(bugs);
            }
            else if (base.Parameters.Contains("-ss"))
            {
                bugs = this.SortBySeverity(bugs);
            }

            var output = new StringBuilder();
            bugs.ForEach(b => output.AppendLine(b.ToString()));

            return output.ToString();
        }

        private void ValidateInputFormat(IList<string> inputParameters)
        {
            if (!inputParameters.Contains("-f") || !inputParameters.Contains("-s"))
            {
                throw new InvalidUserInputException(InvalidFormatErrorMessage);
            }
        }

        private void ValidateEmptyList(List<IBug> bugs)
        {
            if (!bugs.Any())
            {
                throw new EmptyListException(EmptyBugsListErrorMessage);
            }
        }

        private List<IBug> FilterBugs()
        {
            return base.Repository.GetAllTasks()
                .Where(t => t.TaskType == TaskType.Bug)
                .Select(t => (IBug)t)
                .ToList();
        }

        private List<IBug> FilterByStatus(List<IBug> bugs, BugStatus status)
        {
            return bugs
                .Where(b => b.Status == status)
                .ToList();
        }

        private List<IBug> FilterByAssignee(List<IBug> bugs, IPerson assignee)
        {
            return bugs
                .Where(b => b.Assignee == assignee)
                .ToList();

        }

        private List<IBug> SortByTitle(List<IBug> bugs)
        {
            return bugs
                .OrderBy(b => b.Title)
                .ToList();
        }

        private List<IBug> SortByPriority(List<IBug> bugs)
        {
            return bugs
                .OrderBy(b => b.Priority)
                .ToList();
        }

        private List<IBug> SortBySeverity(List<IBug> bugs)
        {
             return bugs
                .OrderBy(b => b.Severity)
                .ToList();
        }
    }
}
