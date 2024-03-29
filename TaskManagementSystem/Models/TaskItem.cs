﻿using System.Text;
using TaskManagementSystem.Helpers;
using TaskManagementSystem.Models.Contracts;
using TaskManagementSystem.Models.Enums;

namespace TaskManagementSystem.Models
{
    public abstract class TaskItem : ITaskItem
    {
        private const int TitleMinLength = 10;
        private const int TitleMaxLength = 50;
        private const int DescriptionMinLength = 10;
        private const int DescriptionMaxLength = 500;

        private string title;
        private string description;
        private readonly List<IComment> comments;
        private readonly List<IEvent> activityHistory;

        protected TaskItem(int id, string title, string desciption, TaskType taskType)
        {
            this.comments = new List<IComment>();
            this.activityHistory = new List<IEvent>();

            this.ID = id;
            this.TaskType = taskType;
            this.Title = title;
            this.Description = desciption;
        }

        public int ID { get; }

        public TaskType TaskType { get; }

        public string Title
        {
            get { return this.title; }
            init
            {
                ValidationHelper.ValidateString(value, TitleMinLength, TitleMaxLength, nameof(this.Title));
                this.title = value;
            }
        }

        public string Description
        {
            get { return this.description; }
            init
            {
                ValidationHelper.ValidateString(value, DescriptionMinLength, DescriptionMaxLength, nameof(this.Description));
                this.description = value;
            }
        }

        public IReadOnlyCollection<IComment> Comments
        {
            get { return this.comments; }
        }

        public IReadOnlyCollection<IEvent> ActivityHistory
        {
            get { return this.activityHistory; }
        }

        public string LastActivity { get; private set; }

        public void AddComment(IComment comment)
        {
            this.comments.Add(comment);
            this.LogActivity($"Comment with author {comment.Author} was added to {this.TaskType} with ID {this.ID}.");
        }

        public override string ToString()
        {
            var output = new StringBuilder();

            output.AppendLine($" # Type: {this.TaskType}");
            output.AppendLine($" # ID: {this.ID}");
            output.Append($" # Title: {this.Title}");

            return output.ToString();
        }

        protected void LogActivity(string log)
        {
            this.LastActivity = log;
            this.activityHistory.Add(new Event(log));
        }
    }
}
