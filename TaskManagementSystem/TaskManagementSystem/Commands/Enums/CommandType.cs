namespace TaskManagementSystem.Commands.Enums
{
    public enum CommandType
    {
        CreateTeam,
        CreatePerson,
        CreateBoard,
        CreateBug,
        CreateStory,
        CreateFeedback,

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
        ShowAllTeamPeople,
        ShowAllTeamBoards,
        ShowBoardActivity,

        AddPersonToTeam,
        AddCommentToATask,
        
        AssignTaskToPerson,
        UnassignTaskToPerson,

        ListAllTasks,
        ListBugs,
        ListStories,
        ListFeedback,
        ListTasksWithAssignee
    }
}