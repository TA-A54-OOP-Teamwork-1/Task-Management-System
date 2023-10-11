using TaskManagementSystem.Exceptions;
using TaskManagementSystem.Models.Enums;
using TaskManagementSystem.Models.Enums.Statuses;

namespace TaskManagementSystem.Helpers
{
    public static class ValidationHelper
    {
        private const string InvalidParametersCountErrorMessage = "Parameters count is {0} and does not match expected count of {1}";
        private static readonly string InvalidPriority = $"Priority must be {Priority.Low}, {Priority.Medium} or {Priority.High}!";
        private static readonly string InvalidSeverity = $"Severity must be {Severity.Minor}, {Severity.Major} or {Severity.Critical}!";
        private static readonly string InvalidBugStatus = $"Status of a bug can be {BugStatus.Active} or {BugStatus.Fixed}!";
        private static readonly string InvalidSize = $"Size of a story can be {Size.Small}, {Size.Medium} or {Size.Large}!";
        private static readonly string InvalidStoryStatus = $"Status of a story can be {StoryStatus.NotDone}, {StoryStatus.InProgress} or {StoryStatus.Done}!";

        public static void ValidateParametersCount(IList<string> parameters, int valueToCompareTo)
        {
            if (parameters.Count != valueToCompareTo)
            {
                throw new InvalidUserInputException(string.Format(InvalidParametersCountErrorMessage, parameters.Count, valueToCompareTo));
            }
        }

        public static void StringIsNull(string value, string message)
        {
            if (value.Equals(null))
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

        public static void ValidatePriority(Priority priority)
        {
            if (priority != Priority.Low
                && priority != Priority.Medium
                && priority != Priority.High)
            {
                throw new ArgumentException(InvalidPriority);
            }
        }

        public static void ValidateSeverity(Severity severity)
        {
            if (severity != Severity.Minor
                && severity != Severity.Major
                && severity != Severity.Critical)
            {
                throw new ArgumentException(InvalidSeverity);
            }
        }

        public static void ValidateBugStatus(BugStatus status)
        {
            if (status != BugStatus.Active 
                && status != BugStatus.Fixed)
            {
                throw new ArgumentException(InvalidBugStatus);
            }
        }

        public static void ValidateSize(Size size)
        {
            if (size != Size.Small
                && size != Size.Medium
                && size != Size.Large)
            {
                throw new ArgumentException(InvalidSize);
            }
        }

        public static void ValidateStoryStatus(StoryStatus status)
        {
            if (status != StoryStatus.NotDone
                && status != StoryStatus.InProgress
                && status != StoryStatus.Done)
            {
                throw new ArgumentException(InvalidStoryStatus);
            }
        }
    }
}
