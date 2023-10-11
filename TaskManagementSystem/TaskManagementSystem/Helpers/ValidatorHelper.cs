using TaskManagementSystem.Exceptions;

namespace TaskManagementSystem.Helpers
{
    public static class ValidatorHelper
    {
        private const string InvalidUserInputExceptionErrorMessage = "Parameters count is {0} and does not match expected count of {1}";

        public static void ValidateParametersCount(IList<string> parameters, int valueToCompareTo)
        {
            if (parameters.Count !=  valueToCompareTo)
            {
                throw new InvalidUserInputException(string.Format(InvalidUserInputExceptionErrorMessage, parameters.Count, valueToCompareTo));
            }
        }

        public static void IntIsInRange(int value, int min, int max, string message)
        {
            if (value < min || value > max)
            {
                throw new ArgumentException(message);
            }
        }
    }
}
