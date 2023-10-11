using TaskManagementSystem.Models.Contracts;
using TaskManagementSystem.Models.Enums;
using TaskManagementSystem.Models.Enums.Statuses;

namespace TaskManagementSystem.Core.Contracts
{
    public interface IRepository
    {
        // 
        IReadOnlyCollection<ITeam> Teams { get; }

        // 
        void CreateTeam(string name);

        void CreatePerson(string name, string teamToAddPersonTo);

        void CreateNewBoardInTeam(string name, string team);

        void CreateNewBug(string title, string description, Priority priority, Severity severity,
            string assignee, IList<string> stepsToReproduce, string board);

        void CreateNewStory(string title, string description, Priority priority,
            Size size, StoryStatus status, string assignee, string board);

        void CreateNewFeedback(string title, string description, int rating, FeedbackStatus feedbackStatus, string board);

        // 
        void AddPersonToTeam(string name, string team);

        // 
        void ChangeBugPriority(IBug bug, Priority priority);

        void ChangeBugSeverity(IBug bug, Severity severity);

        void ChangeBugStatus(IBug bug, BugStatus status);

        void ChangeStoryPriority(IStory story, Priority priority);

        void ChangeStorySize(IStory story, Size size);

        void ChangeStoryStatus(IStory story, StoryStatus status);

        void ChangeFeedbackRating(IFeedback feedback, int rating);

        void ChangeFeedbackStatus(IFeedback feedback, FeedbackStatus status);

        // 
        void ShowAllPeople();

        void ShowPersonActivity(string person);

        void ShowAllTeams();

        void ShowTeamActivity(string team);

        void ShowAllTeamMembers(string team);

        void ShowAllTeamBoards(string team);

        void ShowBoardActivity(string board);
    }
}
