using TaskManagementSystem.Models.Contracts;
using TaskManagementSystem.Models.Enums;
using TaskManagementSystem.Models.Enums.Statuses;

namespace TaskManagementSystem.Core.Contracts
{
    // Create a new team.
    // Create a new person.
    // Create a new board in a team.
    // Create a new Bug/Story/Feedback in a board.

    // Add person to team.

    // Change the Priority/Severity/Status of a bug.
    // Change the Priority/Size/Status of a story.
    // Change the Rating/Status of a feedback.

    // Show all people.
    // Show person's activity.
    // Show all teams.
    // Show team's activity.
    // Show all team members.
    // Show all team boards.
    // Show board's activity.

    public interface IRepository
    {
        // 
        IReadOnlyCollection<ITeam> Teams { get; }

        // 
        void CreateTeam(string name);

        void CreatePerson(string name);

        void CreateNewBoardInTeam(string name, ITeam team);

        void CreateNewBug(string title, string description,Priority priority, Severity severity, 
            BugStatus status, IPerson assignee, IList<string> stepsToReproduce, IBoard board);

        void CreateNewStory(string title, string description, Priority priority, 
            Size size, StoryStatus status,IPerson assignee, IBoard board);

        void CreateNewFeedback(string title, string description, int rating,
            FeedbackStatus feedbackStatus, IBoard board);

        // 
        void AddPersonToTeam(string name, ITeam team);

        // ToDO : change ITaskItem with IBug etc...

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

        void ShowPersonActivity(IPerson person);

        void ShowAllTeams();

        void ShowTeamActivity(ITeam team);

        void ShowAllTeamMembers(ITeam team);

        void ShowAllTeamBoards(ITeam team);

        void ShowBoardActivity(IBoard board);
    }
}
