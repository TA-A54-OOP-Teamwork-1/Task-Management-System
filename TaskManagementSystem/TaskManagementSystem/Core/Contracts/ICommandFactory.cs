using TaskManagementSystem.Commands.Contracts;

namespace TaskManagementSystem.Core.Contracts
{
    public interface ICommandFactory
    {
        ICommand Create(string commandLine);
    }
}
