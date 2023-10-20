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
        ShowAllTeamMembers,
        ShowAllTeamBoards,
        ShowBoardActivity,

        AddPersonToTeam,
        AddCommentToTask,
        
        AssignTaskToPerson,
        UnassignTaskToPerson,

        ListAllTasks,
        ListBugs,
        ListStories,
        ListFeedbacks,
        ListTasksWithAssignee
    }
}