using TaskManagementSystem.Core.Contracts;
using TaskManagementSystem.Commands.Contracts;
using TaskManagementSystem.Exceptions;
using TaskManagementSystem.Helpers;

namespace TaskManagementSystem.Commands
{
    public abstract class BaseCommand : ICommand
    {
        private const string CannotChangePriorityErrorMessage = "Already {0}!";
        private const string InvalidFormatErrorMessage = "Invalid input format!";
        private const string CouldNotParseIntegerErrorMessage = "Could not be parsed to int!";
        private const string CouldNotParseEnumErrorMessage = "{0} is invalid!";  
        private const string InvalidParametersCountErrorMessage = "Parameters count is {0} and does not match expected count of {1}!";

        public BaseCommand(IList<string> parameters, IRepository repository)
        {
            this.Parameters = parameters;
            this.Repository = repository;
        }

        protected IList<string> Parameters { get; }

        protected IRepository Repository { get; }

        public abstract string Execute();
      
        protected void ValidateParametersCount(int expectedCount)
        {
            if (Parameters.Count != expectedCount)
            {
                throw new InvalidUserInputException(string.Format(InvalidParametersCountErrorMessage, Parameters.Count, expectedCount));
            }
        }

        protected void ValidateParametersCount(int min, int max)
        {
            ValidationHelper.ValidateIntRange(Parameters.Count, min, max, "Parameters");
        }

        protected void EnsureNotEqual<TEnumOne, TEnumTwo>(TEnumOne firstValue, TEnumTwo secondValue) 
            where TEnumOne : struct 
            where TEnumTwo : struct
        {
            if(firstValue.Equals(secondValue))
            {
                throw new NotAllowedException(string.Format(CannotChangePriorityErrorMessage, firstValue));
            }
        }

        protected int ParseInt(string integer)
        {
            if (!int.TryParse(integer, out int parsedInteger))
            {
                throw new InvalidUserInputException(CouldNotParseIntegerErrorMessage);
            }

            return parsedInteger;
        }
            
        protected T ParseEnum<T>(string value) where T : struct
        {
            if (!Enum.TryParse(value, out T result))
            {
                throw new InvalidUserInputException(string.Format(CouldNotParseEnumErrorMessage, value));
            }

            return result;
        }

        protected void ValidateInputFormat()
        {
            var inputParametersAsString = string.Join(" ", this.Parameters);

            var containsFilterOperation = inputParametersAsString.Contains("-f");
            var containsSortOperation = inputParametersAsString.Contains("-s");

            if (!containsFilterOperation && !containsSortOperation)
            {
                throw new InvalidUserInputException(InvalidFormatErrorMessage);
            }
        }
    }
}
