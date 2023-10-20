using TaskManagementSystem.Commands.Contracts;
using TaskManagementSystem.Core.Contracts;
using TaskManagementSystem.Exceptions;
using TaskManagementSystem.Helpers.Printers;
using TaskManagementSystem.Helpers.Printers.Contracts;

namespace TaskManagementSystem.Core
{
    public class Engine : IEngine
    {
        private const string TerminationCommand = "Exit";
        private const string EmptyCommandError = "Command can not be empty.";

        private readonly ICommandFactory commandFactory;
        private readonly IPrinter printer;

        public Engine(ICommandFactory commandFactory)
        {
            this.commandFactory = commandFactory;
            printer = new Printer();
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

                    printer.PrintInfo(commandResult);
                }
                catch (EmptyListException ex)
                {
                    ProcessException(ex);
                }
                catch (EntityNotFoundException ex)
                {
                    ProcessException(ex);
                }
                catch (InvalidUserInputException ex)
                {
                    ProcessException(ex);
                }
                catch (NotAllowedException ex)
                {
                    ProcessException(ex);
                }
                catch (Exception ex)
                {
                    ProcessException(ex, false);
                }
            }
        }

        private void ProcessException(Exception ex, bool b_ExpectedException = true)
        {
            if (!b_ExpectedException)
            {
                printer.PrintError($"Error : unexpected exception of type {ex.GetType()} handled!");
            }

            if (!string.IsNullOrEmpty(ex.Message))
            {
                printer.PrintError(ex.Message);                
            }
            else
            {
                printer.PrintError(ex);
            }
        }
    }
}
