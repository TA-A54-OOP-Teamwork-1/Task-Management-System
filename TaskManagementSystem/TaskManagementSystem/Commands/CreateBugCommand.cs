using System.Text;
using TaskManagementSystem.Core.Contracts;
using TaskManagementSystem.Models.Enums;

namespace TaskManagementSystem.Commands
{
    public class CreateBugCommand : BaseCommand
    {
        private const int ExpectedParametersCount = 6;

        public CreateBugCommand(IList<string> parameters, IRepository repository)
            : base(parameters, repository)
        {
        }

        public override string Execute()
        {
            base.ValidateParametersCount(ExpectedParametersCount);

            var title = base.Parameters[0];
            var description = base.Parameters[1];
            var priority = base.ParseEnum<Priority>(base.Parameters[2]);
            var severity = base.ParseEnum<Severity>(base.Parameters[3]);
            var stepsToReproduce = base.Parameters[4].Split(";");
            var boardName = base.Parameters[5];

            var board = base.Repository.GetBoardByName(boardName);
            var bug = base.Repository.CreateBug(title, description, priority,
                severity, stepsToReproduce);

            board.AddTask(bug);

            var output = new StringBuilder();
            output.AppendLine(bug.LastActivity);
            output.Append(board.LastActivity);

            return bug.LastActivity;
        }
    }
}
