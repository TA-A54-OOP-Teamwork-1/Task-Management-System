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
        private List<ITeam> teams = new List<ITeam>();

        public IReadOnlyCollection<ITeam> Teams
        {
            get { return this.teams; }
        }

        public void CreateTeam(string teamName)
        {
            // Do not alllow creating a team if teamName is already used
            if (DoesTeamExist(teamName))
            {
                throw new InvalidUserInputException($"Team with name {teamName} already exists.");
            }

            ITeam team = new Team(teamName);
            this.teams.Add(team);
        }

        public void CreatePerson(string personName, string teamToAddPersonTo)
        {
            // Do not allow creating a user if personName is already used
            if (DoesPersonExist(personName))
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
            if (DoesBoardNameExist(boardName, teamToAddBoardTo))
            {
                throw new InvalidUserInputException($"Board with name {boardName} already exists.");
            }

            ITeam team = FindTeamByName(teamToAddBoardTo);
            IBoard board = new Board(boardName);
            team.AddBoard(board);
        }

        public void AddPersonToTeam(string name, string team)
        {
            throw new NotImplementedException();
        }

        public void ChangeBugPriority(IBug bug, Priority priority)
        {
            throw new NotImplementedException();
        }

        public void ChangeBugSeverity(IBug bug, Severity severity)
        {
            throw new NotImplementedException();
        }

        public void ChangeBugStatus(IBug bug, BugStatus status)
        {
            throw new NotImplementedException();
        }

        public void ChangeFeedbackRating(IFeedback feedback, int rating)
        {
            throw new NotImplementedException();
        }

        public void ChangeFeedbackStatus(IFeedback feedback, FeedbackStatus status)
        {
            throw new NotImplementedException();
        }

        public void ChangeStoryPriority(IStory story, Priority priority)
        {
            throw new NotImplementedException();
        }

        public void ChangeStorySize(IStory story, Size size)
        {
            throw new NotImplementedException();
        }

        public void ChangeStoryStatus(IStory story, StoryStatus status)
        {
            throw new NotImplementedException();
        }

        public void CreateNewBug(string title, string description, Priority priority, Severity severity, string assignee, IList<string> stepsToReproduce, string board)
        {
            throw new NotImplementedException();
        }

        public void CreateNewFeedback(string title, string description, int rating, FeedbackStatus feedbackStatus, string board)
        {
            throw new NotImplementedException();
        }

        public void CreateNewStory(string title, string description, Priority priority, Size size, StoryStatus status, string assignee, string board)
        {
            throw new NotImplementedException();
        }

        public void ShowAllPeople()
        {
            throw new NotImplementedException();
        }

        public void ShowAllTeamBoards(string team)
        {
            throw new NotImplementedException();
        }

        public void ShowAllTeamMembers(string team)
        {
            throw new NotImplementedException();
        }

        public void ShowAllTeams()
        {
            throw new NotImplementedException();
        }

        public void ShowBoardActivity(string board)
        {
            throw new NotImplementedException();
        }

        public void ShowPersonActivity(string person)
        {
            throw new NotImplementedException();
        }

        public void ShowTeamActivity(string team)
        {
            throw new NotImplementedException();
        }

        // API methods

        private bool DoesTeamExist(string teamName)
        {
            foreach (ITeam team in this.teams)
            {
                if (team.Name.Equals(teamName))
                {
                    return true;
                }
            }
            return false;
        }

        private bool DoesPersonExist(string username)
        {
            foreach (ITeam team in this.teams)
            {
                foreach (IPerson member in team.Members)
                {
                    if (member.Name.Equals(username))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool DoesBoardNameExist(string boardName, string team)
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
