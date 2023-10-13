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

        /// <summary>
        /// Called by the Engine class with a command line string that holds all commands
        /// </summary>
        /// <param name="commandLine"></param>
        /// <returns></returns>
        public ICommand Create(string commandLine)
        {
            string[] arguments = commandLine.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            CommandType command = ParseCommandType(arguments[0]);
            List<string> commandParams = ExtractCommandParameters(arguments);

            // 
            switch (command)
            {
                case CommandType.CreateTeam:
                    return new CreateTeamCommand(commandParams, repository);
                case CommandType.CreateMember:
                    return new CreateMemberCommand(commandParams, repository);
                case CommandType.CreateBoard:
                    return new CreateBoardCommand(commandParams, repository);
                case CommandType.CreateNewBug:
                    return new CreateNewBugCommand(commandParams, repository);
                case CommandType.CreateNewStory:
                case CommandType.CreateNewFeedback:
                case CommandType.AddMemberToTeam:
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
                case CommandType.ShowMemberActivity:
                case CommandType.ShowAllTeams:
                case CommandType.ShowTeamActivity:
                case CommandType.ShowAllTeamMembers:
                case CommandType.ShowAllTeamBoards:
                case CommandType.ShowBoardActivity:
                case CommandType.AssignTaskToMember:
                case CommandType.UnAssignTaskToMember:
                case CommandType.AddCommentToATask:
                case CommandType.ListAllTasks:
                case CommandType.ListBugs:
                case CommandType.ListStories:
                case CommandType.ListFeedback:
                case CommandType.ListTasksWithAssignee:
                default:
                    throw new InvalidUserInputException(string.Format(CommandDoesNotExistErrorMessage, command));
            }
        }

        private CommandType ParseCommandType(string value)
        {
            Enum.TryParse(value, true, out CommandType commandType);
            return commandType;
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
