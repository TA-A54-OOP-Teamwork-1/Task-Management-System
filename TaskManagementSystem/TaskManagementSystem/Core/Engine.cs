using TaskManagementSystem.Commands.Contracts;
using TaskManagementSystem.Core.Contracts;

namespace TaskManagementSystem.Core
{
    public class Engine : IEngine
    {
        private const string TerminationCommand = "Exit";
        private const string EmptyCommandError = "Command can not be empty.";
        private const string ReportSeparator = "####################";

        private readonly ICommandFactory commandFactory;

        public Engine(ICommandFactory commandFactory)
        {
            this.commandFactory = commandFactory;
        }

        public void Start()
        {
            while (true)
            {
                try
                {
                    string inputCommand = Console.ReadLine().Trim();

                    if (inputCommand == string.Empty)
                    {
                        Console.WriteLine(EmptyCommandError);
                        continue;
                    }
                    else if (inputCommand.Equals(TerminationCommand, StringComparison.InvariantCultureIgnoreCase))
                    {
                        break;
                    }

                    ICommand command = commandFactory.Create(inputCommand);
                    string commandResult = command.Execute();
                    Console.WriteLine(commandResult.Trim());
                    Console.WriteLine(ReportSeparator);
                }
                catch (Exception ex)
                {
                    if (!string.IsNullOrEmpty(ex.Message))
                    {
                        Console.WriteLine(ex.Message);
                    }
                    else
                    {
                        Console.WriteLine(ex);
                    }
                }
            }
        }
    }
}
