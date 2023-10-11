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

        private const string InvalidTitleLength = "Title must be between 10 and 50 symbols long.";
        private const string InvalidDescriptionLength = "Description must be between 10 and 500 symbols long.";

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
                ValidatorHelper.IntIsInRange(value.Length, TitleMinLength,
                    TitleMaxLength, InvalidTitleLength);

                this.title = value;
            }
        }

        public string Description
        {
            get { return this.description; }
            init
            {
                ValidatorHelper.IntIsInRange(value.Length, DescriptionMinLength,
                    DescriptionMaxLength, InvalidDescriptionLength);

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