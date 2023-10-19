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
        private const string TeamNotExistentErrorMessage = "Team with name {0} does not exist!";
        private const string BoardNotExistentErrorMessage = "Board with name {0} does not exist!";
        private const string TaskNotExistentErrorMessage = "{0} with ID {1} does not exist!";
        private const string PersonNotExistentErrorMessage = "Person with name {0} does not exist!";
        private const string TaskNotAssignableErrorMessage = "Task with ID {0} cannot be assigned/unassigned!";
        private const string EmptyListErrorMessage = "{0} list is empty!";
        
        private readonly List<ITeam> teams = new List<ITeam>();
        private readonly List<IPerson> people = new List<IPerson>();
        private readonly List<IBoard> boards = new List<IBoard>();
        private readonly List<IAssignable> assignableTasks = new List<IAssignable>();
        private readonly List<IFeedback> feedbacks = new List<IFeedback>();

        public IReadOnlyCollection<ITeam> Teams
        {
            get { return this.teams; }
        }

        public IReadOnlyCollection<IPerson> People
        {
            get { return this.people; }
        }

        public IReadOnlyCollection<IBoard> Boards
        {
            get { return this.boards; }
        }

        public IReadOnlyCollection<IAssignable> AssignableTasks
        {
            get { return this.assignableTasks; }
        }

        public IReadOnlyCollection<IFeedback> Feedbacks
        {
            get { return this.feedbacks; }
        }

        public ITeam CreateTeam(string teamName)
        {           
            var team = new Team(teamName);
            this.teams.Add(team);
            return team;
        }

        public IPerson CreatePerson(string personName)
        {           
            var person = new Person(personName);
            this.people.Add(person);
            return person;
        }

        public IBoard CreateBoard(string boardName)
        {
            var board = new Board(boardName);
            this.boards.Add(board);
            return board;
        }
        
        public IBug CreateBug(
            string title, 
            string description, 
            Priority priority, 
            Severity severity, 
            IReadOnlyCollection<string> stepsToReproduce)
        {
            var ID = this.assignableTasks.Count + 1;
            var bug = new Bug(ID, title, description, priority, severity, stepsToReproduce);
            this.assignableTasks.Add(bug);
            return bug;
        }

        public IStory CreateStory(string title, string description, Priority priority, Size size)
        {
            var ID = this.assignableTasks.Count + 1;
            var story = new Story(ID, title, description, priority, size);
            this.assignableTasks.Add(story);
            return story;
        }

        public IFeedback CreateFeedback(string title, string description, int rating)
        {
            var ID = this.assignableTasks.Count + 1;
            var feedback = new Feedback(ID, title, description, rating);
            this.feedbacks.Add(feedback);
            return feedback;
        }

        public string UpdateBugPriority(IBug bug, Priority priority)
        {
            bug.ChangePriority(priority);
            return bug.LastActivity;
        }

        public string UpdateBugSeverity(IBug bug, Severity severity)
        {
            bug.ChangeSeverity(severity);
            return bug.LastActivity;
        }

        public string UpdateBugStatus(IBug bug, BugStatus status)
        {
            bug.ChangeStatus(status);
            return bug.LastActivity;
        }

        public string UpdateStoryPriority(IStory story, Priority priority)
        {
            story.ChangePriority(priority);
            return story.LastActivity;
        }

        public string UpdateStorySize(IStory story, Size size)
        {
            story.ChangeSize(size);
            return story.LastActivity;
        }

        public string UpdateStoryStatus(IStory story, StoryStatus status)
        {
            story.ChangeStatus(status);
            return story.LastActivity;
        }

        public string UpdateFeedbackRating(IFeedback feedback, int rating)
        {
            feedback.ChangeRating(rating);
            return feedback.LastActivity;
        }

        public string UpdateFeedbackStatus(IFeedback feedback, FeedbackStatus status)
        {
            var previousStatus = feedback.Status;
            feedback.ChangeStatus(status);
            return $"Status of [Feedback - ID: {feedback.ID}] changed from {previousStatus} to {status}.";
        }

        public bool TeamExists(string teamName)
        {
            return this.teams.Any(t => t.Name == teamName);
        }

        public bool PersonExists(string personName)
        {
            return this.people.Any(p => p.Name == personName);
        }

        public bool BoardExists(string boardName)
        {
            return this.boards.Any(b => b.Name == boardName);
        }        

        public ITeam GetTeamByName(string teamName)
        {
            return this.teams.FirstOrDefault(t => t.Name == teamName) ??
            throw new EntityNotFoundException(string.Format(TeamNotExistentErrorMessage, teamName));
        }

        public IBoard GetBoardByName(string boardName)
        {
            return this.boards.FirstOrDefault(b => b.Name == boardName) ??
            throw new EntityNotFoundException(string.Format(BoardNotExistentErrorMessage, boardName));
        }

        public T GetTaskByID<T>(int ID) where T : ITaskItem
        {
            var type = typeof(T).Name.Substring(1);
            return (T)this.assignableTasks.FirstOrDefault(t => t.ID == ID && t is T) ?? 
                throw new EntityNotFoundException(string.Format(TaskNotExistentErrorMessage, type, ID));
        }

        public IPerson GetPersonByName(string personName)
        {
            return this.people.FirstOrDefault(m => m.Name == personName) ??
             throw new EntityNotFoundException(string.Format(PersonNotExistentErrorMessage, personName));
        }

        public List<ITaskItem> GetAllTasks()
        {
            var allTasks = new List<ITaskItem>(); 

            allTasks.AddRange(this.assignableTasks.Select(t => (ITaskItem)t));
            allTasks.AddRange(this.feedbacks);

            return allTasks;
        }
    }
}
