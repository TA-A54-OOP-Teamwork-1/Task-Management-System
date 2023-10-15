using TaskManagementSystem.Core.Contracts;
using TaskManagementSystem.Models.Contracts;
using TaskManagementSystem.Models.Enums.Statuses;

namespace TaskManagementSystem.Commands
{
    public class ChangeStoryStatusCommand : BaseCommand
    {
        private const int ExpectedParametersCount = 2;

        public ChangeStoryStatusCommand(IList<string> parameters, IRepository repository) 
            : base(parameters, repository)
        {
        }

        public override string Execute()
        {
            base.ValidateParametersCount(ExpectedParametersCount);

            var storyID = base.ParseInt(base.Parameters[0]);
            var status = base.ParseEnum<StoryStatus>(base.Parameters[1]);

            var story = base.Repository.GetTaskByID<IStory>(storyID);
            var result = base.Repository.UpdateStoryStatus(story, status);

            return result;
        }
    }
}
