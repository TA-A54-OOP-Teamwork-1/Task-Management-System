using TaskManagementSystem.Core.Contracts;
using TaskManagementSystem.Models;
using TaskManagementSystem.Models.Contracts;

namespace TaskManagementSystem.Commands
{
    public class AddCommentToTaskCommand : BaseCommand
    {
        private const int ExpectedParametersCount = 3;

        public AddCommentToTaskCommand(IList<string> parameters, IRepository repository) : base(parameters, repository)
        {
        }

        public override string Execute()
        {
            base.ValidateParametersCount(ExpectedParametersCount);

            var author = base.Parameters[0];
            var taskID = base.ParseInt(Parameters[1]);
            var comment = new Comment(base.Parameters[2], author);
            var task = base.Repository.GetTaskByID<ITaskItem>(taskID);

            task.AddComment(comment);

            return $"New comment added to task with ID {taskID}";
        }
    }
}
