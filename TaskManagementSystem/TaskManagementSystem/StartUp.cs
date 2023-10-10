using TaskManagementSystem.Core;
using TaskManagementSystem.Core.Contracts;

namespace TaskManagementSystem
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            IRepository repository = new Repository();
            ICommandFactory commandFactory = new CommandFactory(repository);
            IEngine taskEngine = new Engine(commandFactory);
            taskEngine.Start();
        }
    }
}