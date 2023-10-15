using TaskManagementSystem.Models.Contracts;
using TaskManagementSystem.Models.Enums;
using TaskManagementSystem.Models.Enums.Statuses;

namespace TaskManagementSystem.Core.Contracts
{
    public interface IRepository
    {
        IReadOnlyCollection<ITeam> Teams { get; }

        IReadOnlyCollection<IPerson> People { get; }

        IReadOnlyCollection<IBoard> Boards { get; }

        IReadOnlyCollection<IAssignable> AssignableTasks { get; }

        IReadOnlyCollection<IFeedback> Feedbacks { get; }

        ITeam CreateTeam(string teamName);

        IPerson CreatePerson(string personName);

        IBoard CreateBoard(string boardName);

        IBug CreateBug(string title, string description, Priority priority, 
            Severity severity, IReadOnlyCollection<string> stepsToReproduce);

        IStory CreateStory(string title, string description, Priority priority, Size size);

        IFeedback CreateFeedback(string title, string description, int rating);

        string UpdateBugPriority(IBug bug, Priority priority);

        string UpdateBugSeverity(IBug bug, Severity severity);

        string UpdateBugStatus(IBug bug, BugStatus status);

        string UpdateStoryPriority(IStory story, Priority priority);

        string UpdateStorySize(IStory story, Size size);

        string UpdateStoryStatus(IStory story, StoryStatus status);

        string UpdateFeedbackRating(IFeedback feedback, int rating);

        string UpdateFeedbackStatus(IFeedback feedback, FeedbackStatus status);

        bool TeamExists(string teamName);

        bool PersonExists(string personName);

        bool BoardExists(string boardName);

        ITeam GetTeamByName(string teamName);

        IBoard GetBoardByName(string boardName);

        T GetTaskByID<T>(int ID) where T : ITaskItem;

        IPerson GetPersonByName(string personName);

        List<ITaskItem> GetAllTasks();
    }
}
