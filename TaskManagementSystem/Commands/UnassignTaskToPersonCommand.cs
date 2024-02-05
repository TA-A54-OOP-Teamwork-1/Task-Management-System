using TaskManagementSystem.Core.Contracts;
using TaskManagementSystem.Exceptions;
using TaskManagementSystem.Models.Contracts;

namespace TaskManagementSystem.Commands
{
    public class UnassignTaskToPersonCommand : BaseCommand
    {
        private const string TaskNotFoundErrorMessage = "Task with ID {0} not found for person with name {1}, thus could not be unassigned!";

        private const int ExpectedParametersCount = 2;

        public UnassignTaskToPersonCommand(IList<string> parameters, IRepository repository) : base(parameters, repository)
        {
        }

        public override string Execute()
        {
            base.ValidateParametersCount(ExpectedParametersCount);

            var personName = base.Parameters[0];
            var taskID = base.ParseInt(Parameters[1]);

            var person = base.Repository.GetPersonByName(personName);
            var task = base.Repository.GetTaskByID<ITaskItem>(taskID);

            if (!person.Tasks.Any(x => x.ID == taskID))
            {
                throw new NotAllowedException(string.Format(TaskNotFoundErrorMessage, taskID, personName));
            }

            person.UnassignTask((IAssignable)task);

            return $"Task of type {task.TaskType} with ID {taskID} has been unassigned to person with name {personName}!";
        }
    }
}
