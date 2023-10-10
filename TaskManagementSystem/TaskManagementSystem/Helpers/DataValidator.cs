namespace TaskManagementSystem.Helpers
{
    public static class DataValidator
    {
        public static void IntIsInRange(int value, int min, int max, string message)
        {
            if (value < min || value > max)
            {
                throw new ArgumentException(message);
            }
        }
    }
}
