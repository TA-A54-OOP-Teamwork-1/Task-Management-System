using TaskManagementSystem.Core.Contracts;
using TaskManagementSystem.Commands.Contracts;
using TaskManagementSystem.Exceptions;
using TaskManagementSystem.Models.Contracts;

namespace TaskManagementSystem.Commands
{
    public abstract class BaseCommand : ICommand
    {
        private const string InvalidParametersCountErrorMessage = "Parameters count is {0} and does not match expected count of {1}!";
        private const string CouldNotParseIntegerErrorMessage = "Could not be parsed to int!";
        private const string CouldNotParseEnumErrorMessage = "None of the enums in {0} matches the value {1}!";

        protected const string NotExistentErrorMessage = "{0} with ID {1} does not exist!";

        public BaseCommand(IList<string> parameters, IRepository repository)
        {
            this.Parameters = parameters;
            this.Repository = repository;
        }

        protected IList<string> Parameters { get; }

        protected IRepository Repository { get; }

        public abstract string Execute();

        /// <summary>
        /// Used by all commands to ensure correct amount or parameters
        /// </summary>
        /// <param name="expectedCount"></param>        
        protected void ValidateParametersCount(int expectedCount)
        {
            if (Parameters.Count != expectedCount)
            {
                throw new InvalidUserInputException(string.Format(InvalidParametersCountErrorMessage, Parameters.Count, expectedCount));
            }
        }

        protected int ParseInt(string integer)
        {
            if (int.TryParse(integer, out int parsedInteger))
            {
                throw new InvalidUserInputException(CouldNotParseIntegerErrorMessage);
            }

            return parsedInteger;
        }

        protected ITaskItem GetTask(int ID, string message)
        {
            foreach (var team in this.Repository.Teams)
            {
                foreach (var board in team.Boards)
                {
                    foreach (var task in board.Tasks)
                    {
                        if (task.ID == ID)
                        {
                            return task;
                        }
                    }
                }
            }

            throw new EntityNotFoundException(message);
        }

        protected T ParseEnum<T>(string value) where T : struct
        {
            if (Enum.TryParse(value, out T result))
            {
                throw new InvalidUserInputException(string.Format(CouldNotParseEnumErrorMessage, typeof(T), value));
            }

            return result;
        }
    }
}
