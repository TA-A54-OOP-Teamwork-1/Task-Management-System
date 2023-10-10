using TaskManagementSystem.Models.Contracts;
using TaskManagementSystem.Models.Enums;
using TaskManagementSystem.Models.Enums.Statuses;

namespace TaskManagementSystem.Models
{
    internal class Bug : TaskItem, IBug
    {
        private List<string> reproduceSteps;
        private Priority priority;
        private Severity severity;
        private BugStatus status;

        public Bug(int id, string title, string desciption) 
            : base(id, title, desciption)
        {
        }

        public IReadOnlyCollection<string> ReproduceSteps
        {
            get { return this.reproduceSteps; }
        }

        public Priority Priority
        {
            get { return this.priority; }
            init
            {

            }
        }

        public Severity Severity => throw new NotImplementedException();

        public BugStatus BugStatus => throw new NotImplementedException();

        public IPerson Assignee => throw new NotImplementedException();
    }
}
