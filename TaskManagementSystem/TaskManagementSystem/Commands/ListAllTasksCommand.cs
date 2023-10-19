using System.Text;

using TaskManagementSystem.Core.Contracts;
using TaskManagementSystem.Exceptions;
using TaskManagementSystem.Models.Contracts;

namespace TaskManagementSystem.Commands
{
    public class ListAllTasksCommand : BaseCommand
    {
        private const string EmptyTasksListErrorMessage = "No tasks to display!";
        private const string InvalidFormatErrorMessage = "Invalid input format!";        

        private const int ExpectedParametersCount = 2;

        public ListAllTasksCommand(IList<string> parameters, IRepository repository) 
            : base(parameters, repository)
        {
        }

        public override string Execute()
        {
            base.ValidateParametersCount(ExpectedParametersCount);

            var tasks = base.Repository.GetAllTasks();
            
            this.ValidateEmptyList(tasks);
            this.ValidateInputFormat(base.Parameters);

            var title = base.Parameters[1];


            if (base.Parameters.Contains("-ft"))
            {
                tasks = this.FilterTasksByTitle(tasks, title);
            }
            else if (base.Parameters.Contains("-st"))
            {
                tasks = this.SortTasksByTitle(tasks, title);
            }
                
            var output = new StringBuilder();
            tasks.ForEach(t => output.AppendLine(t.ToString()));
            
            return output.ToString();
        }

        private void ValidateInputFormat(IList<string> inputParameters)
        {
            if (!inputParameters.Contains("-f") || !inputParameters.Contains("-s"))
            {
                throw new InvalidUserInputException(InvalidFormatErrorMessage);
            }
        }

        private void ValidateEmptyList(List<ITaskItem> tasks)
        {
            if (!tasks.Any())
            {
                throw new EmptyListException(EmptyTasksListErrorMessage);
            }
        }

        private List<ITaskItem> FilterTasksByTitle(List<ITaskItem> tasks, string title)
        {
            return tasks
                .Where(t => t.Title == title)
                .ToList();
        }

        private List<ITaskItem> SortTasksByTitle(List<ITaskItem> tasks, string title)
        {
            return tasks
                .OrderBy(t => t.Title)
                .ToList();
        }
    }
}