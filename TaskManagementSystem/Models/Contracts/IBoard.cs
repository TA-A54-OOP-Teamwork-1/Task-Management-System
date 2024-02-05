namespace TaskManagementSystem.Models.Contracts
{
    public interface IBoard : IHasName, ITrackable
    {
        IReadOnlyCollection<IAssignable> Tasks { get; }

        IReadOnlyCollection<IFeedback> Feedbacks { get; }

        void AddTask(IAssignable task);

        void AddFeedback(IFeedback feedback);
    }
}
