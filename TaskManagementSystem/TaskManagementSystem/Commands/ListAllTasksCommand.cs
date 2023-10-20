using System.Text;

using TaskManagementSystem.Core.Contracts;
using TaskManagementSystem.Exceptions;
using TaskManagementSystem.Models.Contracts;

namespace TaskManagementSystem.Commands
{
    public class ListAllTasksCommand : BaseCommand
    {
        private const string EmptyTasksListErrorMessage = "No tasks to display!";       

        private const int ExpectedParametersMinCount = 1;
        private const int ExpectedParametersMaxCount = 2;

        public ListAllTasksCommand(IList<string> parameters, IRepository repository) 
            : base(parameters, repository)
        {
        }

        public override string Execute()
        {
            base.ValidateParametersCount(ExpectedParametersMinCount, ExpectedParametersMaxCount);

            var tasks = base.Repository.GetAllTasks();
            
            this.ValidateEmptyList(tasks);
            base.ValidateInputFormat();

            if (base.Parameters.Contains("-ft")) // ListAllTasks "-st"
            {
                var title = base.Parameters[1];
                tasks = this.FilterTasksByTitle(tasks, title);
                this.ValidateEmptyList(tasks);
            }
            else if (base.Parameters.Contains("-st"))
            {
                tasks = this.SortTasksByTitle(tasks);
            }
                
            var output = new StringBuilder();
            tasks.ForEach(t => output.AppendLine(t.ToString()));
            
            return output.ToString();
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

        private List<ITaskItem> SortTasksByTitle(List<ITaskItem> tasks)
        {
            return tasks
                .OrderBy(t => t.Title)
                .ToList();
        }
    }
}