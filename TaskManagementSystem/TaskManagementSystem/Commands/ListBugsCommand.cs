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
        private const string InvalidParametersCountErrorMessage = "Command ListBugs cannot accept more than 2 parameters.";

        public ListBugsCommand(IList<string> parameters, IRepository repository) 
            : base(parameters, repository)
        {
        }

        public override string Execute()
        {
            var bugs = this.FilterBugs();

            if (!bugs.Any())
            {
                throw new EmptyListException(EmptyBugsListErrorMessage);
            }

            if (base.Parameters.Count == 1)
            {
                if (Enum.TryParse(base.Parameters[0], true, out BugStatus status))
                {
                    this.FilterByStatus(bugs, status);
                }
                else
                {
                    var assignee = base.Repository.GetPersonByName(base.Parameters[0]);
                    this.FilterByAssignee(bugs, assignee);
                }
            }
            else if (base.Parameters.Count == 2)
            {
                Enum.TryParse(base.Parameters[0], out BugStatus status);
                var assignee = base.Repository.GetPersonByName(base.Parameters[1]);

                this.FilterByStatus(bugs, status);
                this.FilterByAssignee(bugs, assignee);
            }
            else
            {
                throw new InvalidUserInputException(InvalidParametersCountErrorMessage);
            }

            this.Sort(bugs);

            return string.Join(Environment.NewLine, bugs);
        }

        private void Sort(List<IBug> bugs)
        {
            bugs
                .OrderBy(b => b.Title)
                .ThenBy(b => b.Priority)
                .ThenBy(b => b.Severity)
                .ToList();
        }

        private List<IBug> FilterBugs()
        {
            return base.Repository.GetAllTasks()
                .Where(t => t.TaskType == TaskType.Bug)
                .Select(t => (IBug)t)
                .ToList();
        }

        private void FilterByStatus(List<IBug> bugs, BugStatus status)
        {
            bugs.Where(b => b.Status == status);
        }

        private void FilterByAssignee(List<IBug> bugs, IPerson assignee)
        {
            bugs.Where(b => b.Assignee == assignee);
                
        }
    }
}
