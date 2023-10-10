using TaskManagementSystem.Helpers;
using TaskManagementSystem.Models.Contracts;

namespace TaskManagementSystem.Models
{
    public abstract class TaskItem : ITaskItem
    {
        private const int TITLE_MIN_LENGTH = 10;
        private const int TITLE_MAX_LENGTH = 50;
        private const int DESCRIPTION_MIN_LENGTH = 10;
        private const int DESCRIPTION_MAX_LENGTH = 500;

        private const string INVALID_TITLE_LENGTH = "Title must be between 10 and 50 symbols long.";
        private const string INVALID_DESCRIPTION_LENGTH = "Description must be between 10 and 500 symbols long.";

        private string title;
        private string description;
        private List<IComment> comments;
        private List<string> history;

        protected TaskItem(int id, string title, string desciption)
        {
            this.ID = id;
            this.Title = title;
            this.Description = desciption;
        }

        public int ID { get; }

        public string Title
        {
            get { return this.title; }
            init
            {
                DataValidator.IntIsInRange(value.Length, TITLE_MIN_LENGTH,
                    TITLE_MAX_LENGTH, INVALID_TITLE_LENGTH);

                this.title = value;
            }
        }

        public string Description
        {
            get { return this.description; }
            init
            {
                DataValidator.IntIsInRange(value.Length, DESCRIPTION_MIN_LENGTH,
                    DESCRIPTION_MAX_LENGTH, INVALID_DESCRIPTION_LENGTH);

                this.description = value;
            }
        }

        public IReadOnlyCollection<string> History
        {
            get { return this.history; }
        }

        public IReadOnlyCollection<IComment> Comments
        {
            get { return this.comments; }
        }

        public void AddComment(IComment comment)
        {
            this.comments.Add(comment);
        }
    }
}
