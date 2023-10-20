using TaskManagementSystem.Helpers.Printers.Contracts;

namespace TaskManagementSystem.Helpers.Printers
{
    // Using a Singleton for Printer
    public class Printer : IPrinter
    {
        public void PrintInfo(string message, bool newLine = true)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            if (newLine)
            {
                Console.WriteLine(message);
            }
            else
                Console.Write(message);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public void PrintError(string message, bool newLine = true)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            if (newLine)
            {
                Console.WriteLine(message);
            }
            else
                Console.Write(message);

            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public void PrintInfo(object obj, bool newLine = true)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            if (newLine)
            {
                Console.WriteLine(obj);
            }
            else
                Console.Write(obj);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public void PrintError(object obj, bool newLine = true)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            if (newLine)
            {
                Console.WriteLine(obj);
            }
            else
                Console.Write(obj);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
