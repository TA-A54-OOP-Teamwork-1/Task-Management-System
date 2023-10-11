using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        IList<ITeam> Teams { get; }

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
        void ChangeBugPriority(ITaskItem task, Priority priority);

        void ChangeBugSeverity(ITaskItem task, Severity severity);

        void ChangeBugStatus(ITaskItem task, BugStatus status);

        void ChangeStoryPriority(ITaskItem task, Priority priority);

        void ChangeStorySize(ITaskItem task, Size size);

        void ChangeStoryStatus(ITaskItem task, StoryStatus status);

        void ChangeFeedbackRating(ITaskItem task, int rating);

        void ChangeFeedbackStatus(ITaskItem task, FeedbackStatus status);

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
