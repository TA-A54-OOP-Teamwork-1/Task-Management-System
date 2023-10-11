using TaskManagementSystem.Helpers;
using TaskManagementSystem.Models.Contracts;

namespace TaskManagementSystem.Models
{
    public abstract class TaskItem : ITaskItem
    {
        private const int TitleMinLength = 10;
        private const int TitleMaxLength = 50;
        private const int DescriptionMinLength = 10;
        private const int DescriptionMaxLength = 500;

        private readonly string NullValueError = "{0} cannot be null!";
        private readonly string InvalidLengthError = "{0} must be between {1} and {2} symbols long!";

        private string title;
        private string description;
        private readonly List<IComment> comments;
        private readonly List<string> history;

        protected TaskItem(int id, string title, string desciption)
        {
            this.comments = new List<IComment>();
            this.history = new List<string>();

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
                ValidationHelper.StringIsNull(value, string.Format(NullValueError, nameof(this.Title)));
               
                ValidationHelper.ValidateIntRange(value.Length, TitleMinLength, TitleMaxLength, 
                    string.Format(InvalidLengthError, nameof(this.Title), TitleMinLength, TitleMaxLength));                

                this.title = value;
            }
        }

        public string Description
        {
            get { return this.description; }
            init
            {
                ValidationHelper.StringIsNull(value, string.Format(NullValueError, nameof(this.Description)));

                ValidationHelper.ValidateIntRange(value.Length, DescriptionMinLength, DescriptionMaxLength, 
                    string.Format(InvalidLengthError, nameof(this.Description), DescriptionMinLength, DescriptionMaxLength));

                this.description = value;
            }
        }

        public IReadOnlyCollection<IComment> Comments
        {
            get { return this.comments; }
        }

        public IReadOnlyCollection<string> History
        {
            get { return this.history; }
        }

        public void AddComment(IComment comment)
        {
            this.comments.Add(comment);
        }
    }
}
