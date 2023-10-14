﻿using TaskManagementSystem.Models.Enums;

namespace TaskManagementSystem.Models.Contracts
{   
    public interface ITaskItem : IHasID, ICommentable, ILoggable
    {
        TaskType TaskType { get; }

        string Title { get; }

        string Description { get; }
    }
}
