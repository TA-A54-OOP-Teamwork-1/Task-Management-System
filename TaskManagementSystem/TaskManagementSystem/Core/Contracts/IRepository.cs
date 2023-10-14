using TaskManagementSystem.Models.Contracts;
using TaskManagementSystem.Models.Enums;
using TaskManagementSystem.Models.Enums.Statuses;

namespace TaskManagementSystem.Core.Contracts
{
    public interface IRepository
    {
        IReadOnlyCollection<ITeam> Teams { get; }

        IReadOnlyCollection<IPerson> People { get; }

        string CreateTeam(string teamName);

        string CreatePerson(string personName);

        string CreateNewBoardInTeam(string boardName, string teamName);

        string CreateNewBug(
            string title, 
            string description,
            Priority priority, 
            Severity severity, 
            IReadOnlyCollection<string> stepsToReproduce, 
            string boardName
        );

        string CreateNewStory(string title, string description, Priority priority, Size size, string boardName);

        string CreateNewFeedback(string title, string description, int rating, string boardName);

        string AddPersonToTeam(string personName, string teamName);

        string ChangeBugPriority(int bugID, Priority priority);

        string ChangeBugSeverity(int bugID, Severity severity);

        string ChangeBugStatus(int bugID, BugStatus status);

        string ChangeStoryPriority(int storyID, Priority priority);

        string ChangeStorySize(int storyID, Size size);

        string ChangeStoryStatus(int storyID, StoryStatus status);

        string ChangeFeedbackRating(int feedbackID, int rating);

        string ChangeFeedbackStatus(int feedbackID, FeedbackStatus status);

        void ShowAllPeople();

        void ShowPersonActivity(IPerson person);

        void ShowAllTeams();

        void ShowTeamActivity(ITeam team);

        void ShowAllTeamPeople(ITeam team);

        void ShowAllTeamBoards(ITeam team);

        void ShowBoardActivity(IBoard board);

        //

        void AssignTaskToPerson(int taskID, string personName);

        void UnassignTaskToPerson(int taskID, string personName);

        void AddCommentToATask(IComment comment, int taskID);

        void ListAllTasks();

        IReadOnlyCollection<ITaskItem> ListBugs(BugStatus status);

        void ListBugs(string assigneeName);

        void ListBugs(string assigneeName, BugStatus status);

        void ListStories(StoryStatus status);

        void ListStories(string assigneeName);

        void ListStories(string assigneeName, StoryStatus status);

        void ListFeedback(FeedbackStatus status);
    }
}
