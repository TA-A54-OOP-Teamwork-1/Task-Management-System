namespace TaskManagementSystem.Models.Contracts
{
    public interface IAssignable
    {
        void SetAssignee(IPerson person);

        void RemoveAssignee();
    }
}
