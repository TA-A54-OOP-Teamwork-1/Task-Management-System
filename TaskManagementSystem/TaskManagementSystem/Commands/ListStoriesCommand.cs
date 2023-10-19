using System.Text;

using TaskManagementSystem.Core.Contracts;
using TaskManagementSystem.Exceptions;
using TaskManagementSystem.Models.Contracts;
using TaskManagementSystem.Models.Enums;
using TaskManagementSystem.Models.Enums.Statuses;

namespace TaskManagementSystem.Commands
{
    public class ListStoriesCommand : BaseCommand
    {
        private const string EmptyStoriesListErrorMessage = "No stories to display!";
        private const string InvalidFormatErrorMessage = "Invalid input format!";

        private const int ExpectedParametersMinCount = 2;
        private const int ExpectedParametersMaxCount = 4;

        public ListStoriesCommand(IList<string> parameters, IRepository repository)
            : base(parameters, repository)
        {
        }

        public override string Execute()
        {
            base.ValidateParametersCount(ExpectedParametersMinCount, ExpectedParametersMaxCount);

            var stories = this.FilterStories();

            this.ValidateEmptyList(stories);
            this.ValidateInputFormat(base.Parameters);

            if (base.Parameters.Contains("-fsa"))
            {
                var status = base.ParseEnum<StoryStatus>(base.Parameters[1]);
                var assignee = base.Repository.GetPersonByName(base.Parameters[2]);

                stories = this.FilterByStatus(stories, status);
                stories = this.FilterByAssignee(stories, assignee);
            }
            else if (base.Parameters.Contains("-fs"))
            {
                var status = base.ParseEnum<StoryStatus>(base.Parameters[1]);
                stories = this.FilterByStatus(stories, status);
            }
            else if (base.Parameters.Contains("-fa"))
            {
                var assignee = base.Repository.GetPersonByName(base.Parameters[1]);
                stories = this.FilterByAssignee(stories, assignee);
            }

            if (base.Parameters.Contains("-st"))
            {
                stories = this.SortByTitle(stories);
            }
            else if (base.Parameters.Contains("-sp"))
            {
                stories = this.SortByPriority(stories);
            }
            else if (base.Parameters.Contains("-ss"))
            {
                stories = this.SortBySize(stories);
            }

            var output = new StringBuilder();
            stories.ForEach(s => output.AppendLine(s.ToString()));

            return output.ToString();
        }

        private void ValidateInputFormat(IList<string> inputParameters)
        {
            if (!inputParameters.Contains("-f") || !inputParameters.Contains("-s"))
            {
                throw new InvalidUserInputException(InvalidFormatErrorMessage);
            }
        }

        private void ValidateEmptyList(List<IStory> stories)
        {
            if (!stories.Any())
            {
                throw new EmptyListException(EmptyStoriesListErrorMessage);
            }
        }

        private List<IStory> FilterStories()
        {
            return base.Repository.GetAllTasks()
                .Where(t => t.TaskType == TaskType.Story)
                .Select(t => (IStory)t)
                .ToList();
        }

        private List<IStory> FilterByStatus(List<IStory> stories, StoryStatus status)
        {
            return stories
                .Where(s => s.Status == status)
                .ToList();
        }

        private List<IStory> FilterByAssignee(List<IStory> stories, IPerson assignee)
        {
            return stories
                .Where(s => s.Assignee == assignee)
                .ToList();

        }

        private List<IStory> SortByTitle(List<IStory> stories)
        {
            return stories
                .OrderBy(s => s.Title)
                .ToList();
        }

        private List<IStory> SortByPriority(List<IStory> stories)
        {
            return stories
                .OrderBy(s => s.Priority)
                .ToList();
        }

        private List<IStory> SortBySize(List<IStory> stories)
        {
            return stories
                .OrderBy(s => s.Size)
                .ToList();
        }
    }
}
