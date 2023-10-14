using TaskManagementSystem.Commands;
using TaskManagementSystem.Commands.Contracts;
using TaskManagementSystem.Commands.Enums;
using TaskManagementSystem.Core.Contracts;
using TaskManagementSystem.Exceptions;

namespace TaskManagementSystem.Core
{
    public class CommandFactory : ICommandFactory
    {
        private const string CommandDoesNotExistErrorMessage = "Command with name {0} does not exist.";

        private readonly IRepository repository;

        public CommandFactory(IRepository repository)
        {
            // TODO : may be check for null repository
            this.repository = repository;
        }
        public ICommand Create(string commandLine)
        {
            var arguments = commandLine.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var commandType = this.ParseCommandType(arguments[0]);


            List<string> commandParams = this.ExtractCommandParameters(arguments);

            switch (commandType)
            {
                case CommandType.CreateTeam:
                    return new CreateTeamCommand(commandParams, repository);
                case CommandType.CreatePerson:
                    return new CreatePersonCommand(commandParams, repository);
                case CommandType.CreateBoard:
                    return new CreateBoardCommand(commandParams, repository);
                case CommandType.CreateBug:
                    return new CreateBugCommand(commandParams, repository);
                case CommandType.CreateStory:
                case CommandType.CreateFeedback:
                case CommandType.AddPersonToTeam:
                case CommandType.ChangeBugPriority:
                    return new ChangeBugPriorityCommand(commandParams, repository);
                case CommandType.ChangeBugSeverity:
                case CommandType.ChangeBugStatus:
                case CommandType.ChangeStoryPriority:
                case CommandType.ChangeStorySize:
                case CommandType.ChangeStoryStatus:
                case CommandType.ChangeFeedbackRating:
                case CommandType.ChangeFeedbackStatus:
                case CommandType.ShowAllPeople:
                case CommandType.ShowPersonActivity:
                case CommandType.ShowAllTeams:
                case CommandType.ShowTeamActivity:
                case CommandType.ShowAllTeamPeople:
                case CommandType.ShowAllTeamBoards:
                case CommandType.ShowBoardActivity:
                case CommandType.AssignTaskToPerson:
                case CommandType.UnassignTaskToPerson:
                case CommandType.AddCommentToATask:
                case CommandType.ListAllTasks:
                case CommandType.ListBugs:
                case CommandType.ListStories:
                case CommandType.ListFeedback:
                case CommandType.ListTasksWithAssignee:
                    return new ListAllTasksCommand(commandParams, repository);
                default:
                    throw new InvalidUserInputException(string.Format(CommandDoesNotExistErrorMessage, commandType));
            }
        }

        private CommandType ParseCommandType(string value)
        {
            Enum.TryParse(value, true, out CommandType result);
            return result;
        }

        private List<string> ExtractCommandParameters(string[] arguments)
        {
            List<string> parameters = new List<string>();

            for (int i = 1; i < arguments.Length; i++)
            {
                parameters.Add(arguments[i]);
            }

            return parameters;
        }
    }
}
