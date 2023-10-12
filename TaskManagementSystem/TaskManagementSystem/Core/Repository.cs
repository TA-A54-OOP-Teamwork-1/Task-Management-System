using System;
using System.Net.Http.Headers;
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
        private const string NotExistentErrorMessage = "{0} with ID {1} does not exist!";
        // Use only a list of teams and use LINQ to filter collections
        private List<ITeam> teams = new List<ITeam>();
        private List<IMember> people = new List<IMember>();

        public IReadOnlyCollection<ITeam> Teams
        {
            get { return this.teams; }
        }

        public IReadOnlyCollection<IMember> People
        {
            get { return this.people; }
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

        public void CreateMember(string name)
        {
            IMember member = new Member(name);
            people.Add(member);
        }

        public void CreateNewBoardInTeam(string boardName, ITeam team)
        {
            IBoard board = new Board(boardName);
            team.AddBoard(board);
        }
        
        public void CreateNewBug(string title, string description, Priority priority, Severity severity, IList<string> stepsToReproduce, IBoard board)
        {
            IMember assignee = default;
            //int id = teams.Select(x => x.Boards.Where(y => y.Tasks.Select(z => z.GetType().Equals(typeof(IBug)))));
            int id = 0;
            //IBug bug = new Bug(id, title, description, stepsToReproduce.ToList(), priority, severity, assignee);
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
            ValidationHelper.ValidateNull(bug, string.Format(NotExistentErrorMessage, nameof(Bug), bugID));
            bug.UpdatePriority(priority);
        }

        public void ChangeBugSeverity(int bugID, Severity severity)
        {
            var bug = GetTask<IBug>(bugID);
            ValidationHelper.ValidateNull(bug, string.Format(NotExistentErrorMessage, nameof(Bug), bugID));
            bug.UpdateSeverity(severity);
        }

        public void ChangeBugStatus(int bugID, BugStatus status)
        {
            var bug = GetTask<IBug>(bugID);
            ValidationHelper.ValidateNull(bug, string.Format(NotExistentErrorMessage, nameof(Bug), bugID));
            bug.UpdateStatus(status);
        }

        public void ChangeStoryPriority(int storyID, Priority priority)
        {
            var story = GetTask<IStory>(storyID);
            ValidationHelper.ValidateNull(story, string.Format(NotExistentErrorMessage, nameof(Story), storyID));
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

        // API methods

        public bool TeamExists(string teamName)
        {
            return this.teams.Any(t => t.Name == teamName);
        }

        public bool MemberExists(string username)
        {
            return this.teams.Any(t => t.Members.Any(x => x.Name == username));
        }

        public T? GetTask<T>(int ID) where T : class
        {
            foreach (var team in this.teams)
            {
                foreach (var board in team.Boards)
                {
                    foreach (var task in board.Tasks)
                    {
                        if (task.ID == ID)
                        {
                            return (T)task;
                        }
                    }
                }
            }

            return null;
        }

        public ITeam GetTeam(string teamName)
        {
           return this.teams.FirstOrDefault(t => t.Name == teamName);
        }
    }
}
