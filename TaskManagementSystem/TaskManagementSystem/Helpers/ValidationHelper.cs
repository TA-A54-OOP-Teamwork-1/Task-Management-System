namespace TaskManagementSystem.Helpers
{
    public static class ValidationHelper
    {
        public static void ValidateNull(object? value, string message)
        {
            if (value == null)
            {
                throw new ArgumentNullException(message);
            }
        }

        public static void ValidateIntRange(int value, int min, int max, string message)
        {
            if (value < min || value > max)
            {
                throw new ArgumentException(message);
            }
        }        
    }
}
