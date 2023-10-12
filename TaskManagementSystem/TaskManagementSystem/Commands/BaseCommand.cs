using TaskManagementSystem.Core.Contracts;
using TaskManagementSystem.Commands.Contracts;
using TaskManagementSystem.Helpers;
using TaskManagementSystem.Exceptions;
using TaskManagementSystem.Models.Enums;
using TaskManagementSystem.Models.Enums.Statuses;
using System.Xml.Linq;

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

        /// <summary>
        /// Use Genric method to simplify code
        /// Use for all enum parse calls
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        protected T TryParseStringToEnum<T>(string value) where T : struct
        {
            if (Enum.TryParse(value, true, out T resultInputType) == false)
            {
                throw new InvalidUserInputException($"None of the enums in {typeof(T).Name} match the value {value}.");
            }
            return resultInputType;
        }

        protected bool DoesTeamExist(string teamName)
        {
            // Do not alllow creating a team if teamName is already used
            if (Repository.TeamExists(teamName))
            {
                return true;
            }
            throw new InvalidUserInputException($"Team with name {teamName} already exists.");
        }
    }
}
