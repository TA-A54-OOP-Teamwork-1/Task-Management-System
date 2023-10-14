namespace TaskManagementSystem.Models.Contracts
{
    public interface IAssignable : IHasID
    {
        void SetAssignee(IPerson person);

        void RemoveAssignee();
    }
}
