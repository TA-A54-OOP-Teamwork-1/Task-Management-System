﻿using TaskManagementSystem.Helpers;
using TaskManagementSystem.Models.Contracts;

namespace TaskManagementSystem.Models
{
    public class Person : IPerson
    {
        private const int NameMinLength = 5;
        private const int NameMaxLength = 15;

        private const string NameIsNullErrorMessage = "Name cannot be null!";
        private const string InvalidNameLengthErrorMessage = "Name must be between {0} and {1} symbols long!";

        private string name;
        private List<ITaskItem> tasks;
        private List<string> activityHistory;

        public Person(string name)
        {
            this.tasks = new List<ITaskItem>();
            this.activityHistory = new List<string>();

            this.Name = name;
        }

        public string Name
        {
            get { return this.name; }
            init
            {
                ValidationHelper.StringIsNull(value, NameIsNullErrorMessage);
                ValidationHelper.ValidateIntRange(value.Length, NameMinLength, 
                    NameMaxLength, string.Format(InvalidNameLengthErrorMessage, NameMinLength, NameMaxLength));

                this.name = value;
            }
        }

        public IReadOnlyCollection<ITaskItem> Tasks
        {
            get { return this.tasks; }
        }

        public IReadOnlyCollection<string> ActivityHistory
        {
            get { return this.activityHistory; }
        }

        public void AddTask(ITaskItem task)
        {
            this.tasks.Add(task);
        }

        public void LogActivityHistory(string log)
        {
            this.activityHistory.Add($"[{DateTime.Now.ToString("dd/MM/yyyy")}] | log");
        }
    }
}
