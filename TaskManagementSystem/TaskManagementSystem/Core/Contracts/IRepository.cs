using TaskManagementSystem.Models.Contracts;
using TaskManagementSystem.Models.Enums;
using TaskManagementSystem.Models.Enums.Statuses;

namespace TaskManagementSystem.Core.Contracts
{
    public interface IRepository
    {
        IReadOnlyCollection<ITeam> Teams { get; }

        IReadOnlyCollection<IMember> Members { get; }

        void CreateTeam(string name);

        void CreateMember(string name);

        void CreateNewBoardInTeam(string name, string teamName);

        void CreateNewBug(
            string title, 
            string description,
            Priority priority, 
            Severity severity, 
            IReadOnlyCollection<string> stepsToReproduce, 
            string boardName
        );

        void CreateNewStory(string title, string description, Priority priority,
            Size size, StoryStatus status, IMember assignee, IBoard board);

        void CreateNewFeedback(string title, string description, int rating, FeedbackStatus feedbackStatus, IBoard board);

        void AddMemberToTeam(IMember name, ITeam team);

        void ChangeBugPriority(int bugID, Priority priority);

        void ChangeBugSeverity(int bugID, Severity severity);

        void ChangeBugStatus(int bugID, BugStatus status);

        void ChangeStoryPriority(int storyID, Priority priority);

        void ChangeStorySize(IStory story, Size size);

        void ChangeStoryStatus(IStory story, StoryStatus status);

        void ChangeFeedbackRating(IFeedback feedback, int rating);

        void ChangeFeedbackStatus(IFeedback feedback, FeedbackStatus status);

        void ShowAllPeople();

        void ShowMemberActivity(IMember member);

        void ShowAllTeams();

        void ShowTeamActivity(ITeam team);

        void ShowAllTeamMembers(ITeam team);

        void ShowAllTeamBoards(ITeam team);

        void ShowBoardActivity(IBoard board);

        void AssignTaskToMember(ITaskItem task, IMember member);

        void UnassignTaskToMember(ITaskItem task, IMember member);

        void AddCommentToATask(IComment comment, ITaskItem task);

        void ListAllTasks();


        void ListBugs(BugStatus bugStatus);
        void ListBugs(IMember assignee);
        void ListBugs(IMember assignee, BugStatus bugStatus);

        void ListStories(StoryStatus storyStatus);
        void ListStories(IMember assignee);
        void ListStories(IMember assignee, BugStatus bugStatus);

        void ListFeedback(FeedbackStatus feedbackStatus);
        void ListFeedback(IMember assignee);
        void ListFeedback(IMember assignee, FeedbackStatus feedbackStatus);

        //void ListTasksWithAssignee(string assignee);
        //void ListTasksWithAssignee(string type, int status);
        //void ListTasksWithAssignee(string assignee, string type, int status);        

        bool TeamExists(string team);
        bool MemberExists(string member);
    }
}
