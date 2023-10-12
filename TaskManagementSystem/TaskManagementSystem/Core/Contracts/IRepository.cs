using TaskManagementSystem.Models.Contracts;
using TaskManagementSystem.Models.Enums;
using TaskManagementSystem.Models.Enums.Statuses;

namespace TaskManagementSystem.Core.Contracts
{
    public interface IRepository
    {
        IReadOnlyCollection<ITeam> Teams { get; }

        void CreateTeam(string name);

        void CreatePerson(string name, string teamToAddPersonTo);

        void CreateNewBoardInTeam(string name, string team);

        void CreateNewBug(string title, string description, Priority priority, Severity severity,
            string assignee, IList<string> stepsToReproduce, string board);

        void CreateNewStory(string title, string description, Priority priority,
            Size size, StoryStatus status, string assignee, string board);

        void CreateNewFeedback(string title, string description, int rating, FeedbackStatus feedbackStatus, string board);

        void AddPersonToTeam(string name, string team);

        void ChangeBugPriority(IBug bug, Priority priority);

        void ChangeBugSeverity(IBug bug, Severity severity);

        void ChangeBugStatus(IBug bug, BugStatus status);

        void ChangeStoryPriority(int storyID, Priority priority);

        void ChangeStorySize(int storyID, Size size);

        void ChangeStoryStatus(int storyID, StoryStatus status);

        void ChangeFeedbackRating(int feedbackID, int rating);

        void ChangeFeedbackStatus(int feedbackID, FeedbackStatus status);

        void ShowAllPeople();

        void ShowPersonActivity(string person);

        void ShowAllTeams();

        void ShowTeamActivity(string team);

        void ShowAllTeamMembers(string team);

        void ShowAllTeamBoards(string team);

        void ShowBoardActivity(string board);

        void AssignTaskToPerson(int taskID, string personName);

        void UnassignTaskToPerson(int taskID, string personName);

        void AddCommentToATask(int commentID, int taskID);

        void ListAllTasks();


        void ListBugs(BugStatus bugStatus);
        void ListBugs(string assignee);
        void ListBugs(string assignee, BugStatus bugStatus);

        void ListStories(StoryStatus storyStatus);
        void ListStories(string assignee);
        void ListStories(string assignee, BugStatus bugStatus);

        void ListFeedback(FeedbackStatus feedbackStatus);
        void ListFeedback(string assignee);
        void ListFeedback(string assignee, FeedbackStatus feedbackStatus);

        //void ListTasksWithAssignee(string assignee);
        //void ListTasksWithAssignee(string type, int status);
        //void ListTasksWithAssignee(string assignee, string type, int status);        
    }
}
