using System.Text;

using TaskManagementSystem.Core.Contracts;
using TaskManagementSystem.Exceptions;

namespace TaskManagementSystem.Commands
{
    public class ListAllTasksCommand : BaseCommand
    {
        private const string EmptyTasksListErrorMessage = "No tasks to list!";

        private const int ExpectedParametersCount = 1;

        public ListAllTasksCommand(IList<string> parameters, IRepository repository) 
            : base(parameters, repository)
        {
        }

        public override string Execute()
        {
            base.ValidateParametersCount(ExpectedParametersCount);

            var title = base.Parameters[0];
            var output = new StringBuilder();

            var filtered = base.Repository.GetAllTasks()
                .Where(t => t.Title == title)
                .OrderBy(t => t.Title);

            if (!filtered.Any())
            {
                throw new EmptyListException(EmptyTasksListErrorMessage);
            }

            foreach (var task in filtered)
            {
                output.AppendLine(task.ToString());
                output.AppendLine(new string('-', 15));
            }

            return output.ToString().Trim();
        }
    }
}
