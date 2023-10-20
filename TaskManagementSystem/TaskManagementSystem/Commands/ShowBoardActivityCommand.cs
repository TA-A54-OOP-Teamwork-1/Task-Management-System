using System.Text;
using TaskManagementSystem.Core.Contracts;
using TaskManagementSystem.Exceptions;
using TaskManagementSystem.Models.Contracts;

namespace TaskManagementSystem.Commands
{
    public class ShowBoardActivityCommand : BaseCommand
    {
        private const string EmptyActivityLogErrorMessage = "Board with name {0} does not have any activity logged yet!";

        private const int ExpectedParametersCount = 1;

        public ShowBoardActivityCommand(IList<string> parameters, IRepository repository)
            : base(parameters, repository)
        {
        }

        public override string Execute()
        {
            base.ValidateParametersCount(ExpectedParametersCount);

            var boardName = base.Parameters[0];
            var board = base.Repository.GetBoardByName(boardName);

            if (!board.ActivityHistory.Any())
            {
                throw new EmptyListException(string.Format(EmptyActivityLogErrorMessage, boardName));
            }

            var allEvents = new List<IEvent>();
            
            allEvents.AddRange(
                board.ActivityHistory
                    .ToList()
            );

            allEvents.AddRange(
                board.Tasks
                    .SelectMany(t => t.ActivityHistory)
                    .ToList()
            );

            allEvents = allEvents.OrderBy(e => e.TimeStamp).ToList();

            StringBuilder output = new StringBuilder();

            allEvents.ForEach(e => output.AppendLine(e.ToString()));

            return output.ToString();
        }
    }
}
