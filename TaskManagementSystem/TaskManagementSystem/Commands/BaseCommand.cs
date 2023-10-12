using TaskManagementSystem.Core.Contracts;
using TaskManagementSystem.Commands.Contracts;
using TaskManagementSystem.Helpers;
using TaskManagementSystem.Exceptions;

namespace TaskManagementSystem.Commands
{
    public abstract class BaseCommand : ICommand
    {
        private const string InvalidParametersCountErrorMessage = "Parameters count is {0} and does not match expected count of {1}";
        protected const string NameIsNullMessage = "Team name can not be null.";
        protected const string InvalidNameLengthErrorMessage = "Team name must bebetween {0} and {1} characters logn, but it's length is {2}";

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
        /// <param name="compareValue"></param>        
        protected void ValidateParametersCount(int compareValue)
        {
            if (Parameters.Count != compareValue)
            {
                throw new InvalidUserInputException(string.Format(InvalidParametersCountErrorMessage, Parameters.Count, compareValue));
            }
        }
    }
}
