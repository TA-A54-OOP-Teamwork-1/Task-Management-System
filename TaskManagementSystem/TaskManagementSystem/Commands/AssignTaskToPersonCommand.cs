using TaskManagementSystem.Core.Contracts;
using TaskManagementSystem.Exceptions;
using TaskManagementSystem.Models.Contracts;

namespace TaskManagementSystem.Commands
{
    public class AssignTaskToPersonCommand : BaseCommand
    {
        private const string PersonNotAMemberOfAnyTeamErrorMessage = "The person with name {0} is not a member of any team, thus can not have a task assigned!";
        private const string AssignTaskMultipleTImesNotAllowedErrorMessage = "Task with ID {0} already assigned to person with name {1}!";
        private const string TaskNotOfAssignbleTypeErrorMessage = "Task with ID {0} of type {1} can not b assigned! It should be of type Bug or Story.";

        private const int ExpectedParametersCount = 2;

        public AssignTaskToPersonCommand(IList<string> parameters, IRepository repository) : base(parameters, repository)
        {
        }

        public override string Execute()
        {
            base.ValidateParametersCount(ExpectedParametersCount);

            var personName = base.Parameters[0];
            var taskID = base.ParseInt(Parameters[1]);

            var person = base.Repository.GetPersonByName(personName);
            var task = base.Repository.GetTaskByID<ITaskItem>(taskID);

            if (!base.Repository.Teams.Any(x => x.People.Any(x => x.Name == personName)))
            {
                throw new InvalidUserInputException(string.Format(PersonNotAMemberOfAnyTeamErrorMessage, personName));
            }

            if (!(task is IAssignable))
            {
                throw new InvalidUserInputException(string.Format(TaskNotOfAssignbleTypeErrorMessage, task.ID, task.TaskType));
            }

            if (person.Tasks.Any(x => x.ID == taskID))
            {
                throw new NotAllowedException(string.Format(AssignTaskMultipleTImesNotAllowedErrorMessage, taskID, personName));
            }

            person.AssignTask((IAssignable)task);

            return $"Task of type {task.TaskType} with ID {taskID} has been assigned to person with name {personName}!";
        }
    }
}
