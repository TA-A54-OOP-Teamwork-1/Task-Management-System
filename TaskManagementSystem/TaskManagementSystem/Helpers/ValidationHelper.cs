namespace TaskManagementSystem.Helpers
{
    public static class ValidationHelper
    {
        private const string NullValueErrorMessage = "{0} cannot be null!";
        private const string InvalidLengthErrorMessage = "{0} must be between {1} and {2}.";

        public static void ValidateNull(object? value, string propertyName)
        {
            if (value == null)
            {
                throw new ArgumentNullException(string.Format(NullValueErrorMessage, propertyName));
            }
        }

        public static void ValidateIntRange(int value, int min, int max, string propertyName)
        {
            if (value < min || value > max)
            {
                throw new ArgumentException(string.Format(InvalidLengthErrorMessage, propertyName, min, max));
            }
        }

        public static void ValidateString(string value, int minLength, int maxLength, string propertyName)
        {
            ValidateNull(value, propertyName);
            ValidateIntRange(value.Length, minLength, maxLength, $"{propertyName} length");                
        }
    }
}
