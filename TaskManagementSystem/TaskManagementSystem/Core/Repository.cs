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

        public void CreatePerson(string name, ITeam team)
        {
            IPerson person = new Person(name);
            team.AddMember(person);
        }

        public void CreateNewBoardInTeam(string boardName, ITeam team)
        {
            IBoard board = new Board(boardName);
            team.AddBoard(board);
        }
        
        public void CreateNewBug(string title, string description, Priority priority, Severity severity, IList<string> stepsToReproduce, IBoard board)
        {
            IPerson assignee = default;
            //int id = teams.Select(x => x.Boards.Where(y => y.Tasks.Select(z => z.GetType().Equals(typeof(IBug)))));
            int id = 0;
            //IBug bug = new Bug(id, title, description, stepsToReproduce.ToList(), priority, severity, assignee);
        }

        public void CreateNewStory(string title, string description, Priority priority, Size size, StoryStatus status, IPerson assignee, IBoard board)
        {
            throw new NotImplementedException();
        }

        public void CreateNewFeedback(string title, string description, int rating, FeedbackStatus feedbackStatus, IBoard board)
        {
            throw new NotImplementedException();
        }

        public void AddPersonToTeam(IPerson name, ITeam team)
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

        public void ChangeFeedbackRating(IFeedback feedback, int rating)
        {
            throw new NotImplementedException();
        }

        public void ChangeFeedbackStatus(IFeedback feedback, FeedbackStatus status)
        {
            throw new NotImplementedException();
        }

        public void ShowAllPeople()
        {
            throw new NotImplementedException();
        }

        public void ShowPersonActivity(IPerson person)
        {
            throw new NotImplementedException();
        }

        public void ShowAllTeams()
        {
            throw new NotImplementedException();
        }

        public void ShowTeamActivity(ITeam team)
        {
            throw new NotImplementedException();
        }

        public void ShowAllTeamMembers(ITeam team)
        {
            throw new NotImplementedException();
        }

        public void ShowAllTeamBoards(ITeam team)
        {
            throw new NotImplementedException();
        }

        public void ShowBoardActivity(IBoard board)
        {
            throw new NotImplementedException();
        }

        public void AssignTaskToPerson(ITaskItem task, IPerson person)
        {
            throw new NotImplementedException();
        }

        public void UnassignTaskToPerson(ITaskItem task, IPerson person)
        {
            throw new NotImplementedException();
        }

        public void AddCommentToATask(IComment comment, ITaskItem task)
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

        public void ListBugs(IPerson assignee)
        {
            throw new NotImplementedException();
        }

        public void ListBugs(IPerson assignee, BugStatus bugStatus)
        {
            throw new NotImplementedException();
        }

        public void ListStories(StoryStatus storyStatus)
        {
            throw new NotImplementedException();
        }

        public void ListStories(IPerson assignee)
        {
            throw new NotImplementedException();
        }

        public void ListStories(IPerson assignee, BugStatus bugStatus)
        {
            throw new NotImplementedException();
        }

        public void ListFeedback(FeedbackStatus feedbackStatus)
        {
            throw new NotImplementedException();
        }

        public void ListFeedback(IPerson assignee)
        {
            throw new NotImplementedException();
        }

        public void ListFeedback(IPerson assignee, FeedbackStatus feedbackStatus)
        {
            throw new NotImplementedException();
        }

        // API methods

        public bool TeamExists(string teamName)
        {
            return this.teams.Any(t => t.Name == teamName);
        }

        public bool PersonExists(string username)
        {
            return this.teams.Any(t => t.Members.Any(x => x.Name == username));
        }
    }
}
