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
            this.repository = repository;
        }

        public ICommand Create(string commandLine)
        {
            var arguments = commandLine.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var inputCommand = arguments[0];
            bool commandParseSuccessful = this.ParseCommandType(inputCommand, out CommandType commandType);

            if (commandParseSuccessful)
            {
                List<string> commandParams = this.ExtractCommandParameters(arguments);

                switch (commandType)
                {
                    case CommandType.CreateTeam:
                        return new CreateTeamCommand(commandParams, this.repository);
                    case CommandType.CreatePerson:
                        return new CreatePersonCommand(commandParams, this.repository);
                    case CommandType.CreateBoard:
                        return new CreateBoardCommand(commandParams, this.repository);
                    case CommandType.CreateBug:
                        return new CreateBugCommand(commandParams, this.repository);
                    case CommandType.CreateStory:
                        return new CreateStoryCommand(commandParams, this.repository);
                    case CommandType.CreateFeedback:
                        return new CreateFeedbackCommand(commandParams, this.repository);
                    case CommandType.AddPersonToTeam:
                        return new AddPersonToTeamCommand(commandParams, this.repository);
                    case CommandType.ChangeBugPriority:
                        return new ChangeBugPriorityCommand(commandParams, this.repository);
                    case CommandType.ChangeBugSeverity:
                        return new ChangeBugSeverityCommand(commandParams, this.repository);
                    case CommandType.ChangeBugStatus:
                        return new ChangeBugStatusCommand(commandParams, this.repository);
                    case CommandType.ChangeStoryPriority:
                        return new ChangeStoryPriorityCommand(commandParams, this.repository);
                    case CommandType.ChangeStorySize:
                        return new ChangeStorySizeCommand(commandParams, this.repository);
                    case CommandType.ChangeStoryStatus:
                        return new ChangeStoryStatusCommand(commandParams, this.repository);
                    case CommandType.ChangeFeedbackRating:
                        return new ChangeFeedbackRatingCommand(commandParams, this.repository);
                    case CommandType.ChangeFeedbackStatus:
                        return new ChangeFeedbackStatusCommand(commandParams, this.repository);
                    case CommandType.ShowAllPeople:
                        return new ShowAllPeopleCommand(commandParams, this.repository);
                    case CommandType.ShowPersonActivity:
                        return new ShowPersonActivityCommand(commandParams, this.repository);
                    case CommandType.ShowAllTeams:
                        return new ShowAllTeamsCommand(commandParams, this.repository);
                    case CommandType.ShowTeamActivity:
                        return new ShowTeamActivityCommand(commandParams, this.repository);
                    case CommandType.ShowAllTeamMembers:
                        return new ShowAllTeamMembersCommand(commandParams, this.repository);
                    case CommandType.ShowAllTeamBoards:
                        return new ShowAllTeamBoardsCommand(commandParams, this.repository);
                    case CommandType.ShowBoardActivity:
                        return new ShowBoardActivityCommand(commandParams, this.repository);
                    case CommandType.AssignTaskToPerson:
                        return new AssignTaskToPersonCommand(commandParams, this.repository);
                    case CommandType.UnassignTaskToPerson:
                        return new UnassignTaskToPersonCommand(commandParams, this.repository);
                    case CommandType.AddCommentToTask:
                        return new AddCommentToTaskCommand(commandParams, this.repository);
                    case CommandType.ListAllTasks:
                        return new ListAllTasksCommand(commandParams, this.repository);
                    case CommandType.ListBugs:
                        return new ListBugsCommand(commandParams, this.repository);
                    case CommandType.ListStories:
                        return new ListStoriesCommand(commandParams, this.repository);                        
                    case CommandType.ListFeedbacks:
                        return new ListFeedbacksCommand(commandParams, this.repository);
                    case CommandType.ListTasksWithAssignee:
                        return new ListAllTasksCommand(commandParams, this.repository);
                }
            }

            throw new InvalidUserInputException(string.Format(CommandDoesNotExistErrorMessage, inputCommand));
        }

        private bool ParseCommandType(string value, out CommandType result)
        {
            return Enum.TryParse(value, true, out result);
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
