using TaskManagementSystem.Models.Contracts;

namespace TaskManagementSystem.Models
{
    public class Comment : IComment
    {
        public Comment(string author, string message)
        {
            this.Author = author;
            this.Message = message;
        }

        public string Author { get; }

        public string Message { get; }        
    }
}
