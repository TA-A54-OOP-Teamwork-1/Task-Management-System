namespace TaskManagementSystem.Models.Contracts
{
    public interface IAssignable
    {
        void SetAssignee(IMember member);

        void RemoveAssignee();
    }
}
