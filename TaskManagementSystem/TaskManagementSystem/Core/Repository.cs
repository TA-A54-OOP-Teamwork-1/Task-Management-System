using TaskManagementSystem.Core.Contracts;
using TaskManagementSystem.Exceptions;
using TaskManagementSystem.Helpers;
using TaskManagementSystem.Models;
using TaskManagementSystem.Models.Contracts;
using TaskManagementSystem.Models.Enums;
using TaskManagementSystem.Models.Enums.Statuses;

namespace TaskManagementSystem.Core
{
    public class Repository : IRepository
    {
        private const string TaskNotExistentErrorMessage = "{0} with ID {1} does not exist!";
        private const string TeamNotExistentErrorMessage = "Team with name {0} does not exist!";
        private const string BoardNotExistentErrorMessage = "Team with name {0} does not exist!";
       
        private List<ITeam> teams = new List<ITeam>();
        private List<IMember> members = new List<IMember>();

        public IReadOnlyCollection<ITeam> Teams
        {
            get { return this.teams; }
        }

        public IReadOnlyCollection<IMember> Members
        {
            get { return this.members; }
        }

        public void CreateTeam(string teamName)
        {
            if (this.TeamExists(teamName))
            {
                throw new InvalidUserInputException($"Team with name {teamName} already exists.");
            }

            var team = new Team(teamName);
            this.teams.Add(team);
        }

        public void CreateMember(string name)
        {
            var member = new Member(name);
            members.Add(member);
        }

        public void CreateNewBoardInTeam(string boardName, string teamName)
        {
            var board = new Board(boardName);
            var team = this.GetTeam(teamName);
            team.AddBoard(board);
        }
        
        public void CreateNewBug(string title, string description, Priority priority, Severity severity, IReadOnlyCollection<string> stepsToReproduce, string boardName)
        {
            var board = this.GetBoard(boardName);
            var nextID = board.Tasks.Count + 1;
            var bug = new Bug(nextID, title, description, priority, severity, stepsToReproduce);
            board.AddTask(bug);

            // get all bugs - board.Tasks.Where(t => t.GetType().Name == "Bug");
            // get all stories - board.Tasks.Where(t => t.GetType().Name == "Story");
            // get all feedback - board.Tasks.Where(t => t.GetType().Name == "Feedback");
        }

        public void CreateNewStory(string title, string description, Priority priority, Size size, StoryStatus status, IMember assignee, IBoard board)
        {
            throw new NotImplementedException();
        }

        public void CreateNewFeedback(string title, string description, int rating, FeedbackStatus feedbackStatus, IBoard board)
        {
            throw new NotImplementedException();
        }

        public void AddMemberToTeam(IMember name, ITeam team)
        {
            throw new NotImplementedException();
        }

        public void ChangeBugPriority(int bugID, Priority priority)
        {
            var bug = GetTask<IBug>(bugID);
            bug.UpdatePriority(priority);
        }

        public void ChangeBugSeverity(int bugID, Severity severity)
        {
            var bug = GetTask<IBug>(bugID);
            bug.UpdateSeverity(severity);
        }

        public void ChangeBugStatus(int bugID, BugStatus status)
        {
            var bug = GetTask<IBug>(bugID);
            bug.UpdateStatus(status);
        }

        public void ChangeStoryPriority(int storyID, Priority priority)
        {
            var story = GetTask<IStory>(storyID);
            story.UpdatePriority(priority);
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

        public void ShowMemberActivity(IMember member)
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

        public void AssignTaskToMember(ITaskItem task, IMember member)
        {
            throw new NotImplementedException();
        }

        public void UnassignTaskToMember(ITaskItem task, IMember member)
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

        public void ListBugs(IMember assignee)
        {
            throw new NotImplementedException();
        }

        public void ListBugs(IMember assignee, BugStatus bugStatus)
        {
            throw new NotImplementedException();
        }

        public void ListStories(StoryStatus storyStatus)
        {
            throw new NotImplementedException();
        }

        public void ListStories(IMember assignee)
        {
            throw new NotImplementedException();
        }

        public void ListStories(IMember assignee, BugStatus bugStatus)
        {
            throw new NotImplementedException();
        }

        public void ListFeedback(FeedbackStatus feedbackStatus)
        {
            throw new NotImplementedException();
        }

        public void ListFeedback(IMember assignee)
        {
            throw new NotImplementedException();
        }

        public void ListFeedback(IMember assignee, FeedbackStatus feedbackStatus)
        {
            throw new NotImplementedException();
        }

        public bool TeamExists(string teamName)
        {
            return this.teams.Any(t => t.Name == teamName);
        }

        public bool MemberExists(string username)
        {
            return this.teams.Any(t => t.MemberNames.Any(n => n == username));
        }

        private T GetTask<T>(int ID) where T : ITaskItem
        {
            var task = this.teams
                .SelectMany(team => team.Boards)
                .SelectMany(board => board.Tasks)
                .FirstOrDefault(task => task.ID == ID);

            ValidationHelper.ValidateNull(task, string.Format(TaskNotExistentErrorMessage, nameof(T).Substring(1), ID));

            return (T)task;

            //foreach (var team in this.teams)
            //{
            //    foreach (var board in team.Boards)
            //    {
            //        foreach (var task in board.Tasks)
            //        {
            //            if (task.ID == ID)
            //            {
            //                return (T)task;
            //            }
            //        }
            //    }
            //}

            //return null;
        }

        private ITeam? GetTeam(string teamName)
        {
            var team = this.teams.FirstOrDefault(t => t.Name == teamName);
            ValidationHelper.ValidateNull(team, string.Format(TeamNotExistentErrorMessage, teamName));
            return team;
        }

        private IBoard? GetBoard(string boardName)
        {
            // SelectMany - [1, 2, 3] [4, 5, 6] => [1, 2, 3, 4, 5, 6] (flattens)

            var board = this.teams.SelectMany(team => team.Boards).FirstOrDefault(board => board.Name == boardName);
            ValidationHelper.ValidateNull(board, string.Format(BoardNotExistentErrorMessage, boardName));
            return board;
        }
    }
}
