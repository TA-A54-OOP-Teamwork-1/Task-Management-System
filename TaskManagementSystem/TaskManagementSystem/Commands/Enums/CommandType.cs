﻿namespace TaskManagementSystem.Commands.Enums
{
    public enum CommandType
    {
        CreateTeam,
        CreatePerson,
        CreateBoard,
        CreateNewBug,
        CreateNewStory,
        CreateNewFeedback,
        AddPersonToTeam,
        ChangeBugPriority,
        ChangeBugSeverity,
        ChangeBugStatus,
        ChangeStoryPriority,
        ChangeStorySize,
        ChangeStoryStatus,
        ChangeFeedbackRating,
        ChangeFeedbackStatus,
        ShowAllPeople,
        ShowPersonActivity,
        ShowAllTeams,
        ShowTeamActivity,
        ShowAllTeamMembers,
        ShowAllTeamBoards,
        ShowBoardActivity
    }
}
