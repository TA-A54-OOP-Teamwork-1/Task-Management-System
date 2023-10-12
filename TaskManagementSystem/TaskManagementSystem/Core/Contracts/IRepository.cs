using TaskManagementSystem.Models.Contracts;
using TaskManagementSystem.Models.Enums;
using TaskManagementSystem.Models.Enums.Statuses;

namespace TaskManagementSystem.Core.Contracts
{
    public interface IRepository
    {
        IReadOnlyCollection<ITeam> Teams { get; }

        void CreateTeam(string name);

        void CreatePerson(string name, ITeam team);

        void CreateNewBoardInTeam(string name, ITeam team);

        void CreateNewBug(string title, string description, Priority priority, Severity severity,
            IList<string> stepsToReproduce, IBoard board);

        void CreateNewStory(string title, string description, Priority priority,
            Size size, StoryStatus status, IPerson assignee, IBoard board);

        void CreateNewFeedback(string title, string description, int rating, FeedbackStatus feedbackStatus, IBoard board);

        void AddPersonToTeam(IPerson name, ITeam team);

        void ChangeBugPriority(IBug bug, Priority priority);

        void ChangeBugSeverity(IBug bug, Severity severity);

        void ChangeBugStatus(IBug bug, BugStatus status);

        void ChangeStoryPriority(IStory story, Priority priority);

        void ChangeStorySize(IStory story, Size size);

        void ChangeStoryStatus(IStory story, StoryStatus status);

        void ChangeFeedbackRating(IFeedback feedback, int rating);

        void ChangeFeedbackStatus(IFeedback feedback, FeedbackStatus status);

        void ShowAllPeople();

        void ShowPersonActivity(IPerson person);

        void ShowAllTeams();

        void ShowTeamActivity(ITeam team);

        void ShowAllTeamMembers(ITeam team);

        void ShowAllTeamBoards(ITeam team);

        void ShowBoardActivity(IBoard board);

        void AssignTaskToPerson(ITaskItem task, IPerson person);

        void UnassignTaskToPerson(ITaskItem task, IPerson person);

        void AddCommentToATask(IComment comment, ITaskItem task);

        void ListAllTasks();


        void ListBugs(BugStatus bugStatus);
        void ListBugs(IPerson assignee);
        void ListBugs(IPerson assignee, BugStatus bugStatus);

        void ListStories(StoryStatus storyStatus);
        void ListStories(IPerson assignee);
        void ListStories(IPerson assignee, BugStatus bugStatus);

        void ListFeedback(FeedbackStatus feedbackStatus);
        void ListFeedback(IPerson assignee);
        void ListFeedback(IPerson assignee, FeedbackStatus feedbackStatus);

        //void ListTasksWithAssignee(string assignee);
        //void ListTasksWithAssignee(string type, int status);
        //void ListTasksWithAssignee(string assignee, string type, int status);        

        bool TeamExists(string team);
        bool PersonExists(string person);
    }
}
