using TaskManagementSystem.Core.Contracts;
using TaskManagementSystem.Models;
using TaskManagementSystem.Models.Contracts;
using TaskManagementSystem.Models.Enums;
using TaskManagementSystem.Models.Enums.Statuses;

namespace TaskManagementSystem.Core
{
    public class Repository : IRepository
    {
        private IList<ITeam> teams = new List<ITeam>();

        public IList<ITeam> Teams
        {
            get => new List<ITeam>(teams);
        }

        public void AddPersonToTeam(string name, ITeam team)
        {
            throw new NotImplementedException();
        }

        public void ChangeBugPriority(ITaskItem task, Priority priority)
        {
            throw new NotImplementedException();
        }

        public void ChangeBugSeverity(ITaskItem task, Severity severity)
        {
            throw new NotImplementedException();
        }

        public void ChangeBugStatus(ITaskItem task, BugStatus status)
        {
            throw new NotImplementedException();
        }

        public void ChangeFeedbackRating(ITaskItem task, int rating)
        {
            throw new NotImplementedException();
        }

        public void ChangeFeedbackStatus(ITaskItem task, FeedbackStatus status)
        {
            throw new NotImplementedException();
        }

        public void ChangeStoryPriority(ITaskItem task, Priority priority)
        {
            throw new NotImplementedException();
        }

        public void ChangeStorySize(ITaskItem task, Size size)
        {
            throw new NotImplementedException();
        }

        public void ChangeStoryStatus(ITaskItem task, StoryStatus status)
        {
            throw new NotImplementedException();
        }

        public void CreateNewBoardInTeam(string name, ITeam team)
        {
            throw new NotImplementedException();
        }

        public void CreateNewBug(string title, string description, Priority priority, Severity severity, BugStatus status, IPerson assignee, IList<string> stepsToReproduce, IBoard board)
        {
            throw new NotImplementedException();
        }

        public void CreateNewFeedback(string title, string description, int rating, FeedbackStatus feedbackStatus, IBoard board)
        {
            throw new NotImplementedException();
        }

        public void CreateNewStory(string title, string description, Priority priority, Size size, StoryStatus status, IPerson assignee, IBoard board)
        {
            throw new NotImplementedException();
        }

        public void CreatePerson(string name)
        {
            Console.WriteLine("Creating a person");
            throw new NotImplementedException();
        }

        public void CreateTeam(string name)
        {
            ITeam team = new Team(name);
            Teams.Add(team);
            Console.WriteLine($"Creating a new team with name {name}.");
        }

        public void ShowAllPeople()
        {
            throw new NotImplementedException();
        }

        public void ShowAllTeamBoards(ITeam team)
        {
            throw new NotImplementedException();
        }

        public void ShowAllTeamMembers(ITeam team)
        {
            throw new NotImplementedException();
        }

        public void ShowAllTeams()
        {
            throw new NotImplementedException();
        }

        public void ShowBoardActivity(IBoard board)
        {
            throw new NotImplementedException();
        }

        public void ShowPersonActivity(IPerson person)
        {
            throw new NotImplementedException();
        }

        public void ShowTeamActivity(ITeam team)
        {
            throw new NotImplementedException();
        }
    }
}
