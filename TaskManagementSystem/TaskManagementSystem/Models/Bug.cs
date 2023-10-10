using TaskManagementSystem.Models.Enumerations;
using TaskManagementSystem.Models.Enumerations.Statuses;

namespace TaskManagementSystem.Models
{
    internal class Bug : TaskItem
    {
        private Priority priority;
        private Severity severity;
        private BugStatus status;

        public Bug(int id, string title, string desciption) 
            : base(id, title, desciption)
        {
        }
    }
}
