using TaskManagementSystem.Core.Contracts;
using TaskManagementSystem.Models;
using TaskManagementSystem.Models.Contracts;
using TaskManagementSystem.Models.Enums;

namespace TaskManagementSystem.Commands
{
    public class ChangeStoryPriorityCommand : BaseCommand
    {
        private const int ExpectedParametersCount = 2;

        public ChangeStoryPriorityCommand(IList<string> parameters, IRepository repository) 
            : base(parameters, repository)
        {
        }

        public override string Execute()
        {
            base.ValidateParametersCount(ExpectedParametersCount);

            var storyID = base.ParseInt(base.Parameters[0]);
            var priority = base.ParseEnum<Priority>(base.Parameters[1]);

            var story = base.Repository.GetTaskByID<IStory>(storyID);

            base.EnsureNotEqual(priority, story.Priority);

            var result = base.Repository.UpdateStoryPriority(story, priority);

            return result;
        }
    }
}
