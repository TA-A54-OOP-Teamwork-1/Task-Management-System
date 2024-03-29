﻿using TaskManagementSystem.Core.Contracts;
using TaskManagementSystem.Models;
using TaskManagementSystem.Models.Contracts;
using TaskManagementSystem.Models.Enums;

namespace TaskManagementSystem.Commands
{
    public class ChangeStorySizeCommand : BaseCommand
    {
        private const int ExpectedParametersCount = 2;

        public ChangeStorySizeCommand(IList<string> parameters, IRepository repository) 
            : base(parameters, repository)
        {
        }

        public override string Execute()
        {
            base.ValidateParametersCount(ExpectedParametersCount);

            var storyID = base.ParseInt(base.Parameters[0]);
            var size = base.ParseEnum<Size>(base.Parameters[1]);

            var story = base.Repository.GetTaskByID<IStory>(storyID);

            base.EnsureNotEqual(size, story.Size);

            var result = base.Repository.UpdateStorySize(story, size);

            return result;
        }
    }
}
