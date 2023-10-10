using TaskManagementSystem.Commands.Contracts;
using TaskManagementSystem.Commands.Enums;
using TaskManagementSystem.Core.Contracts;

namespace TaskManagementSystem.Core
{
    public class CommandFactory : ICommandFactory
    {
        private readonly IRepository repository;

        public CommandFactory(IRepository repository)
        {
            // ToDo : may be check for null repository
            this.repository = repository;
        }

        public ICommand Create(string commandLine)
        {
            // 
            string[] arguments = commandLine.Split(',', StringSplitOptions.RemoveEmptyEntries);

            // 
            CommandType command = ParseCommandType(arguments[0]);

            // 
            switch (command)
            {
                case CommandType.CreateTeam:
                    break;
                default:
                    break;
            }

            throw new NotImplementedException();
        }

        private CommandType ParseCommandType(string value)
        {
            Enum.TryParse(value, true, out CommandType commandType);
            return commandType;
        }
    }
}
