using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.Commands.Enums
{
    public enum CommandType
    {
        CreateTeam,
        CreatePerson,
        CreateNewBoardInTeam,
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
