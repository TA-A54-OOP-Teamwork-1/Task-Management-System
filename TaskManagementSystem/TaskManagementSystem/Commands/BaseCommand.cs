using TaskManagementSystem.Core.Contracts;
using TaskManagementSystem.Commands.Contracts;

namespace TaskManagementSystem.Commands
{
    public abstract class BaseCommand : ICommand
    {
        public BaseCommand(IList<string> parameters, IRepository repository)
        {
            this.Parameters = parameters;
            this.Repository = repository;
        }

        protected IList<string> Parameters { get; }

        protected IRepository Repository { get; }

        public abstract string Execute();
    }
}
