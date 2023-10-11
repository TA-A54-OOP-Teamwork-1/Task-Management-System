﻿using TaskManagementSystem.Helpers;
using TaskManagementSystem.Models.Contracts;

namespace TaskManagementSystem.Models
{
    public class Person : IPerson
    {
        private const int NameMinLength = 5;
        private const int NameMaxLength = 15;

        private readonly string NameIsNullError = "Name cannot be null!";
        private readonly string InvalidNameLengthError = $"Name must be between {NameMinLength} and {NameMaxLength} symbols long!";

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
                ValidationHelper.StringIsNull(value, NameIsNullError);
                ValidationHelper.ValidateIntRange(value.Length, NameMinLength, 
                    NameMaxLength, InvalidNameLengthError);

                this.name = value;
            }
        }

        public IReadOnlyCollection<ITaskItem> Tasks { get; }

        public IReadOnlyCollection<string> ActivityHistory { get; }
    }
}
