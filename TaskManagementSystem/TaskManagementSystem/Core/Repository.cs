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
        private const string PersonNotExistentErrorMessage = "Person with name {0} does not exist!";
        private const string TeamAlreadyExistsErrorMessage = "Team with name {0} already exists.";
        private const string PersonAlreadyExistsErrorMessage = "Person with name {0} already exists.";
        private const string BoardAlreadyExistsErrorMessage = "Board with name {0} already exists.";

        private List<ITeam> teams = new List<ITeam>();
        private List<IPerson> people = new List<IPerson>();

        public IReadOnlyCollection<ITeam> Teams
        {
            get { return this.teams; }
        }

        public IReadOnlyCollection<IPerson> People
        {
            get { return this.people; }
        }

        public string CreateTeam(string teamName)
        {
            if (this.TeamExists(teamName))
            {
                throw new InvalidUserInputException(string.Format(TeamAlreadyExistsErrorMessage, teamName));
            }

            var team = new Team(teamName);
            this.teams.Add(team);

            return $"Team with name {teamName} created.";
        }

        public string CreatePerson(string personName)
        {
            if (this.PersonExists(personName))
            {
                throw new InvalidUserInputException(string.Format(PersonAlreadyExistsErrorMessage, personName));
            }

            var person = new Person(personName);
            people.Add(person);

            return $"Person with name {personName} created.";
        }

        public string CreateNewBoardInTeam(string boardName, string teamName)
        {
            var board = new Board(boardName);

            if (this.BoardExist(boardName))
            {
                throw new InvalidUserInputException(string.Format(BoardAlreadyExistsErrorMessage, boardName));

            }

            var team = this.GetTeam(teamName);
            team.AddBoard(board);

            return $"Board with name {boardName} in team {teamName}.";
        }
        
        public string CreateNewBug(string title, string description, Priority priority, Severity severity, IReadOnlyCollection<string> stepsToReproduce, string boardName)
        {
            var board = this.GetBoard(boardName);
            var nextID = board.Tasks.Count + 1;
            var bug = new Bug(nextID, title, description, priority, severity, stepsToReproduce);
            board.AddTask(bug);

            return $"Bug with ID {nextID} created.";
        }

        public string CreateNewStory(string title, string description, Priority priority, Size size, string boardName)
        {
            var board = this.GetBoard(boardName);
            var nextID = board.Tasks.Count + 1;
            var story = new Story(nextID, title, description, priority, size);
            board.AddTask(story);

            return $"Story with ID {nextID} created.";
        }

        public string CreateNewFeedback(string title, string description, int rating, string boardName)
        {
            var board = this.GetBoard(boardName);
            var nextID = board.Tasks.Count + 1;
            var feedback = new Feedback(nextID, title, description, rating);
            board.AddTask(feedback);

            return $"Feedback with ID {nextID} created.";
        }

        public string AddPersonToTeam(string personName, string teamName)
        {
            var person = this.GetPerson(personName);
            var team = this.GetTeam(teamName);
            team.AddPerson(person);

            return $"Person with name {personName} added to team {teamName}.";
        }

        public string ChangeBugPriority(int bugID, Priority priority)
        {
            var bug = this.GetTask<IBug>(bugID);
            bug.ChangePriority(priority);

            return $"Bug priority changed to {priority}.";
        }

        public string ChangeBugSeverity(int bugID, Severity severity)
        { 
            var bug = this.GetTask<IBug>(bugID);
            bug.ChangeSeverity(severity);

            return $"Bug severity changed to {severity}.";
        }

        public string ChangeBugStatus(int bugID, BugStatus status)
        {
            var bug = this.GetTask<IBug>(bugID);
            bug.ChangeStatus(status);

            return $"Bug status changed to {status}.";
        }

        public string ChangeStoryPriority(int storyID, Priority priority)
        {
            var story = this.GetTask<IStory>(storyID);
            story.ChangePriority(priority);

            return $"Story priority changed to {priority}.";
        }

        public string ChangeStorySize(int storyID, Size size)
        {
            var story = this.GetTask<IStory>(storyID);
            story.ChangeSize(size);

            return $"Story size changed to {size}.";
        }

        public string ChangeStoryStatus(int storyID, StoryStatus status)
        {
            var story = this.GetTask<IStory>(storyID);
            story.ChangeStatus(status);
        
            return $"Story status changed to {status}.";
        }

        public string ChangeFeedbackRating(int feedbackID, int rating)
        {
            var feedback = this.GetTask<IFeedback>(feedbackID);
            feedback.ChangeRating(rating);

            return $"Feedback rating changed to {rating}.";
        }

        public string ChangeFeedbackStatus(int feedbackID, FeedbackStatus status)
        {
            var feedback = this.GetTask<IFeedback>(feedbackID);
            feedback.ChangeStatus(status);

            return $"Feedback status changed to {status}.";
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

        public void ShowAllTeamPeople(ITeam team)
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

        //

        public void AssignTaskToPerson(int taskID, string personName)
        {
            var task = (IAssignable)this.GetTask<ITaskItem>(taskID);
            var person = this.GetPerson(personName);

            person.AddTask(task);
            task.SetAssignee(person);
        }

        public void UnassignTaskToPerson(int taskID, string personName)
        {
            var task = (IAssignable)this.GetTask<ITaskItem>(taskID);
            var person = this.GetPerson(personName);

            person.RemoveTask(task);
            task.RemoveAssignee();
        }

        public void AddCommentToATask(IComment comment, int taskID)
        {
            var task = this.GetTask<ITaskItem>(taskID);
            task.AddComment(comment);
        }

        public void ListAllTasks()
        {
            this.teams
                .SelectMany(t => t.Boards)
                .SelectMany(b => b.Tasks)
                .ToList()
                .ForEach(Console.WriteLine);
        }

        public void ListBugs(BugStatus status)
        {
            this.teams
                .SelectMany(t => t.Boards)
                .SelectMany(b => b.Tasks)
                .Where(t => t.TaskType == TaskType.Bug)
                .Select(b => (IBug)b)
                .Where(b => b.Status == status)
                .ToList()
                .ForEach(Console.WriteLine);
        }

        public void ListBugs(string assigneeName)
        {
            this.teams
                .SelectMany(t => t.Boards)
                .SelectMany(b => b.Tasks)
                .Where(t => t.TaskType == TaskType.Bug)
                .Select(b => (IBug)b)
                .Where(b => b.Assignee.Name == assigneeName)
                .ToList()
                .ForEach(Console.WriteLine);
        }

        public void ListBugs(string assigneeName, BugStatus status)
        {
            this.teams
                .SelectMany(t => t.Boards)
                .SelectMany(b => b.Tasks)
                .Where(t => t.TaskType == TaskType.Bug)
                .Select(b => (IBug)b)
                .Where(b => b.Assignee.Name == assigneeName
                    && b.Status == status)
                .ToList()
                .ForEach(Console.WriteLine);
        }

        public void ListStories(StoryStatus status)
        {
            this.teams
                .SelectMany(t => t.Boards)
                .SelectMany(b => b.Tasks)
                .Where(t => t.TaskType == TaskType.Story)
                .Select(s => (IStory)s)
                .Where(s => s.Status == status)
                .ToList()
                .ForEach(Console.WriteLine);
        }

        public void ListStories(string assigneeName)
        {
            this.teams
                .SelectMany(t => t.Boards)
                .SelectMany(b => b.Tasks)
                .Where(t => t.TaskType == TaskType.Story)
                .Select(s => (IStory)s)
                .Where(s => s.Assignee.Name == assigneeName)
                .ToList()
                .ForEach(Console.WriteLine);
        }

        public void ListStories(string assigneeName, StoryStatus status)
        {
            this.teams
                .SelectMany(t => t.Boards)
                .SelectMany(b => b.Tasks)
                .Where(t => t.TaskType == TaskType.Bug)
                .Select(s => (IStory)s)
                .Where(s => s.Assignee.Name == assigneeName
                    && s.Status == status)
                .ToList()
                .ForEach(Console.WriteLine);
        }

        public void ListFeedback(FeedbackStatus status)
        {
            this.teams
                .SelectMany(t => t.Boards)
                .SelectMany(b => b.Tasks)
                .Where(t => t.TaskType == TaskType.Feedback)
                .Select(f => (IFeedback)f)
                .Where(f => f.Status == status)
                .ToList()
                .ForEach(Console.WriteLine);
        }

        private bool TeamExists(string teamName)
        {
            return this.teams.Any(t => t.Name == teamName);
        }

        private bool PersonExists(string personName)
        {
            return this.teams.Any(t => t.People.Any(m => m.Name == personName));
        }

        private bool BoardExist(string boardName)
        {
            return this.teams.Any(t => t.Boards.Any(b => b.Name == boardName));
        }        

        private ITeam GetTeam(string teamName)
        {
            var team = this.teams.FirstOrDefault(t => t.Name == teamName);
            ValidationHelper.ValidateNull(team, string.Format(TeamNotExistentErrorMessage, teamName));
            return team;
        }

        private IBoard GetBoard(string boardName)
        {
            // SelectMany - [1, 2, 3] [4, 5, 6] => [1, 2, 3, 4, 5, 6] (flattens)

            var board = this.teams.SelectMany(team => team.Boards).FirstOrDefault(board => board.Name == boardName);
            ValidationHelper.ValidateNull(board, string.Format(BoardNotExistentErrorMessage, boardName));
            return board;
        }

        private T GetTask<T>(int ID) where T : ITaskItem
        {           
            var task = this.teams
                .SelectMany(team => team.Boards)
                .SelectMany(board => board.Tasks)
                .FirstOrDefault(task => task.ID == ID);

            ValidationHelper.ValidateNull(task, string.Format(TaskNotExistentErrorMessage, nameof(T).Substring(1), ID));

            return (T)task;
        }

        private IPerson GetPerson(string personName)
        {
            var person = this.people.FirstOrDefault(m => m.Name == personName);
            ValidationHelper.ValidateNull(person, string.Format(PersonNotExistentErrorMessage, personName));
            return person;
        }
    }
}
