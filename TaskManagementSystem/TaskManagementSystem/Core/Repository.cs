using TaskManagementSystem.Core.Contracts;
using TaskManagementSystem.Exceptions;
using TaskManagementSystem.Models;
using TaskManagementSystem.Models.Contracts;
using TaskManagementSystem.Models.Enums;
using TaskManagementSystem.Models.Enums.Statuses;

namespace TaskManagementSystem.Core
{
    public class Repository : IRepository
    {
        // Use only a list of teams and use LINQ to filter collections
        private List<ITeam> teams = new List<ITeam>();

        public IReadOnlyCollection<ITeam> Teams
        {
            get { return this.teams; }
        }

        public void CreateTeam(string teamName)
        {
            // Do not alllow creating a team if teamName is already used
            if (TeamExists(teamName))
            {
                throw new InvalidUserInputException($"Team with name {teamName} already exists.");
            }

            ITeam team = new Team(teamName);
            this.teams.Add(team);
        }

        public void CreatePerson(string personName, string teamToAddPersonTo)
        {
            // Do not allow creating a user if personName is already used
            if (PersonExists(personName))
            {
                throw new InvalidUserInputException($"User with name {personName} already exists.");
            }

            ITeam team = FindTeamByName(teamToAddPersonTo);
            IPerson person = new Person(personName);
            team.AddMember(person);
        }

        public void CreateNewBoardInTeam(string boardName, string teamToAddBoardTo)
        {
            // Do not alllow creating a team if teamName is already used
            if (BoardExists(boardName, teamToAddBoardTo))
            {
                throw new InvalidUserInputException($"Board with name {boardName} already exists.");
            }

            ITeam team = FindTeamByName(teamToAddBoardTo);
            IBoard board = new Board(boardName);
            team.AddBoard(board);
        }

        public void CreateNewBug(string title, string description, Priority priority, Severity severity, string assignee, IList<string> stepsToReproduce, string board)
        {
            throw new NotImplementedException();
        }

        public void CreateNewStory(string title, string description, Priority priority, Size size, StoryStatus status, string assignee, string board)
        {
            throw new NotImplementedException();
        }

        public void CreateNewFeedback(string title, string description, int rating, FeedbackStatus feedbackStatus, string board)
        {
            throw new NotImplementedException();
        }

        public void AddPersonToTeam(string name, string team)
        {
            throw new NotImplementedException();
        }

        public void ChangeBugPriority(IBug bug, Priority priority)
        {
            bug.UpdatePriority(priority);
        }

        public void ChangeBugSeverity(IBug bug, Severity severity)
        {
            bug.UpdateSeverity(severity);
        }

        public void ChangeBugStatus(IBug bug, BugStatus status)
        {
            bug.UpdateStatus(status);
        }

        public void ChangeStoryPriority(int storyID, Priority priority)
        {
            throw new NotImplementedException();
        }

        public void ChangeStorySize(int storyID, Size size)
        {
            throw new NotImplementedException();
        }

        public void ChangeStoryStatus(int storyID, StoryStatus status)
        {
            throw new NotImplementedException();
        }

        public void ChangeFeedbackRating(int feedbackID, int rating)
        {
            throw new NotImplementedException();
        }

        public void ChangeFeedbackStatus(int feedbackID, FeedbackStatus status)
        {
            throw new NotImplementedException();
        }

        public void ShowAllPeople()
        {
            throw new NotImplementedException();
        }

        public void ShowPersonActivity(string person)
        {
            throw new NotImplementedException();
        }

        public void ShowAllTeams()
        {
            throw new NotImplementedException();
        }

        public void ShowTeamActivity(string team)
        {
            throw new NotImplementedException();
        }

        public void ShowAllTeamMembers(string team)
        {
            throw new NotImplementedException();
        }

        public void ShowAllTeamBoards(string team)
        {
            throw new NotImplementedException();
        }

        public void ShowBoardActivity(string board)
        {
            throw new NotImplementedException();
        }

        public void AssignTaskToPerson(int taskID, string personName)
        {
            throw new NotImplementedException();
        }

        public void UnassignTaskToPerson(int taskID, string personName)
        {
            throw new NotImplementedException();
        }

        public void AddCommentToATask(int commentID, int taskID)
        {
            throw new NotImplementedException();
        }

        public void ListAllTasks()
        {
            throw new NotImplementedException();
        }

        public void ListBugs(BugStatus bugStatus)
        {
            throw new NotImplementedException();
        }

        public void ListBugs(string assignee)
        {
            throw new NotImplementedException();
        }

        public void ListBugs(string assignee, BugStatus bugStatus)
        {
            throw new NotImplementedException();
        }

        public void ListStories(StoryStatus storyStatus)
        {
            throw new NotImplementedException();
        }

        public void ListStories(string assignee)
        {
            throw new NotImplementedException();
        }

        public void ListStories(string assignee, BugStatus bugStatus)
        {
            throw new NotImplementedException();
        }

        public void ListFeedback(FeedbackStatus feedbackStatus)
        {
            throw new NotImplementedException();
        }

        public void ListFeedback(string assignee)
        {
            throw new NotImplementedException();
        }

        public void ListFeedback(string assignee, FeedbackStatus feedbackStatus)
        {
            throw new NotImplementedException();
        }

        // API methods

        private bool TeamExists(string teamName)
        {
            return this.teams.Any(t => t.Name == teamName);
        }

        private bool PersonExists(string username)
        {
            return this.teams.Any(t => t.Members.Any(x => x.Name == username));
        }

        private bool BoardExists(string boardName, string team)
        {
            ITeam wantedTeam = FindTeamByName(team);

            foreach (IBoard board in wantedTeam.Boards)
            {
                if (board.Name == boardName)
                {
                    return true;
                }
            }
            return false;
        }

        private ITeam FindTeamByName(string teamName)
        {
            foreach (var item in Teams)
            {
                if (item.Name == teamName)
                {
                    return item;
                }
            }

            throw new InvalidUserInputException($"Team with name {teamName} does not exist.");
        }
    }
}
