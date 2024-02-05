namespace TaskManagementSystem.Models.Contracts
{
    public interface IAssignable : ITaskItem
    {
        IPerson Assignee { get; }

        void SetAssignee(IPerson person);

        void RemoveAssignee();
    }
}
