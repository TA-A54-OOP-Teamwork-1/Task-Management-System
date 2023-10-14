using TaskManagementSystem.Core.Contracts;
using TaskManagementSystem.Models.Enums;

namespace TaskManagementSystem.Commands
{
    public class CreateStoryCommand : BaseCommand
    {
        private const int ExpectedParametersCount = 5;

        public CreateStoryCommand(IList<string> parameters, IRepository repository) 
            : base(parameters, repository)
        {
        }

        public override string Execute()
        {
            base.ValidateParametersCount(ExpectedParametersCount);

            var title = base.Parameters[0];
            var description = base.Parameters[1];
            var priority = base.ParseEnum<Priority>(base.Parameters[2]);
            var size = base.ParseEnum<Size>(base.Parameters[3]);
            var boardName = base.Parameters[4];

            var board = base.Repository.GetBoardByName(boardName);
            var story = base.Repository.CreateStory(title, description, priority, size);

            board.AddTask(story);

            var log = $"Story with ID {story.ID} was created.";

            board.LogActivity(log);
            story.LogActivity(log);

            return log;
        }
    }
}
