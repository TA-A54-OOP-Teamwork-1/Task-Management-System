using TaskManagementSystem.Commands.Contracts;
using TaskManagementSystem.Core.Contracts;
using TaskManagementSystem.Exceptions;

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
                    string inpuCmmand = Console.ReadLine().Trim();

                    if (inpuCmmand == string.Empty)
                    {
                        Console.WriteLine(EmptyCommandError);
                        continue;
                    }
                    else if (inpuCmmand.Equals(TerminationCommand, StringComparison.InvariantCultureIgnoreCase))
                    {
                        break;
                    }

                    ICommand command = commandFactory.Create(inpuCmmand);
                    string commandResult = command.Execute();
                    Console.WriteLine(commandResult.Trim());
                    Console.WriteLine(ReportSeparator);
                }
                //catch (InvalidUserInputException ex)
                //{
                //    Console.Write(ex.Message);
                //}
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
