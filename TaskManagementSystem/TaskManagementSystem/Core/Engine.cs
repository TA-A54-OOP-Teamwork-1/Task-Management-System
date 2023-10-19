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
        private const string ReportSeparator = "####################";

        private readonly ICommandFactory commandFactory;
        private readonly IPrinter printer;

        private string[] commands =
        {
            "CreateTeam NewTeam",
            "CreatePerson NewPerson_01",
            "CreatePerson NewPerson_02",
            "CreatePerson NewPerson_03",
            "CreatePerson NewPerson_04",
            "CreatePerson NewPerson_05",
            "ShowAllTeams",
            "ShowAllPeople",
            "CreateBoard SomeBoard NewTeam",
            "CreateBug SomeBugTitle1 SomeBugDescription1 High Critical Step1:SomeStep1;Step2:SomeOtherStep1; SomeBoard",
            "CreateBug SomeBugTitle2 SomeBugDescription2 High Critical Step1:SomeStep2;Step2:SomeOtherStep2; SomeBoard",
            "ChangeBugPriority 1 Medium",
            "ShowBoardActivity SomeBoard",
            "AddPersonToTeam NewPerson_01 NewTeam",
            "AssignTaskToPerson NewPerson_01 1",
            "AddPersonToTeam NewPerson_02 NewTeam",
            "AssignTaskToPerson NewPerson_02 2",
            "AddPersonToTeam NewPerson_03 NewTeam",
            "AddPersonToTeam NewPerson_04 NewTeam",
            "AddPersonToTeam NewPerson_05 NewTeam",
            "ShowAllTeamPeople NewTeam",
            "AddCommentToATask user 1 SomeCommentAboutTaksWithID_1",
            "UnassignTaskToPerson NewPerson_01 1",
            "ShowPersonActivity NewPerson_01",
            "ShowPersonActivity NewPerson_02",
            "CreateStory SomeStoryTitle2 SomeBugDescription2 High 1 SomeBoard",
            "CreateFeedback SomeFeedbackTitle SomeFeedbackDescription 5 SomeBoard",

            "ChangeBugPriority 1 Low",
            "ChangeBugSeverity 1 Critical",
            "ChangeBugSeverity 1 Major",
            "ChangeBugSeverity 1 Minor",

            "ChangeBugStatus 1 Fixed",

            "ChangeStoryPriority 2 Medium", // this will trow an error is we send 2 as ID which is in this case a bug
            "ChangeStoryPriority 3 Low",
        };
        int iterator = 0;

        public Engine(ICommandFactory commandFactory)
        {
            this.commandFactory = commandFactory;
            this.printer = new Printer();
        }

        public void Start()
        {
            while (iterator < commands.Length)
            {
                try
                {
                    string inputCommand = commands[iterator]; // Console.ReadLine().Trim();

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

                    Printer.Instance.PrintInfo(commandResult);
                    Printer.Instance.PrintInfo(ReportSeparator);
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

                iterator++;
            }
        }

        private void ProcessException(Exception ex, bool b_ExpectedException = true)
        {
            if (!b_ExpectedException)
            {
                Printer.Instance.PrintError($"Error : unexpected exception of type {ex.GetType()} handled!");
            }

            if (!string.IsNullOrEmpty(ex.Message))
            {
                Printer.Instance.PrintError(ex.Message);
                //Printer.Instance.PrintError(ex.StackTrace);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
