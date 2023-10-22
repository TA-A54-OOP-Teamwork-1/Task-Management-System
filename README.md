# Task-Management-System
- Group project developed by Plamen and Ventsislav -

Task Management System is a console application that will help a small team of developers to organize and manage their work tasks. The system currently supports Bug, Story and Feedback tasks.
The application supports the following commands (NOTE : no whitespaces are allowed in input arguments):

• Create a new person. / requires person name /
  • **CreatePerson TestPerson**

• Show all people.
  • **ShowAllPeople**

• Show person's activity. / required person name /
  • **ShowPersonActivity TestPerson**

• Create a new team. / requires team name /
  • **CreateTeam TestTeam**

• Show all teams.
  • **ShowAllTeams**

• Show team's activity. / requires team name /
  • **ShowTeamActivity TestTeam**

• Add person to team. / requires person name and team name /
  • **AddPersonToTeam TestPerson TestTeam**

• Show all team members. / requires team name /
  • **ShowAllTeamMembers TestTeam**

• Create a new board in a team. / requires board name and a team name /
  • **CreateBoard TestBoard TestTeam**

• Show all team boards. / requires team name /
  • **ShowAllTeamBoards TestTeam**

• Show board's activity. / requires board name /
  • **ShowBoardActivity TestBoard**

• Create a new Bug in a board. / requires title, description, priority, severity, steps to reproduce and board name / 
  • **CreateBug FixPrintingTeamFunctionality TeamMembeersAreNotIndented High Major CreateNewTeam;AddTwoNewMembers;PrintTeam; TestBoard**

• Create a new Story in a board. / requires title, description, priority, size, board name /
  • **CreateStory SomeStoryTitle SomeStoryDescription Medium Medium TestBoard**

• Create a new Feedback in a board. / requires title, description, rating, board name /
  • **CreateFeedback SomeFeedbackTitle SomeFeedbackDescription 3 TestBoard**

• Change the Priority/Severity/Status of a bug. / requires bug id and new value /
  • **ChangeBugPriority 0 Low**
  • **ChangeBugSeverity 0 Minor**
  • **ChangeBugStatus 0 Fixed**

• Change the Priority/Size/Status of a story. / requires story id and new value /
  • **ChangeStoryPriority 1 Low**
  • **ChangeStorySize 1 Minor**
  • **ChangeStoryStatus 1 Done**
  
• Change the Rating/Status of a feedback. / requires feedback id and new value /
  • **ChangeFeedbackRating 2 5**
  • **ChangeFeedbackStatus 2 Scheduled**
  
• Assign/Unassign a task to a person. / requires task id and person name / 
  • **AssignTaskToPerson 0 TestPerson**
  
• Add comment to a task. / author, comment content and task id /
  • **AddCommentToTask Author 0 SomeCommentFromAuthor**

• List all tasks.  
  o Filter by title / -ft /  
  o Sort by title / -st /
    - NOTE! FILTER IS ALWAYS BEFORE SORTING!
    - Right: ListAllTasks -ft -st
    - Wrong: ListAllTasks -st -ft
  
  • **ListAllTasks -ft**
  • **ListAllTasks -ft -st**

• List bugs/stories/feedback only.
  o Filter by status and/or assignee / -fs, -fa, -fsa /
  o Sort by title/priority/severity/size/rating (depending on the task type) / -st, -sp, -ss, -ss, -sr / 
    - NOTE! BOTH SIZE AND SEVERITY ARE /-ss/ BUT SIZE IS FOR STORIES AND SEVERITY IS FOR BUGS. FILTER IS ALWAYS BEFORE SORTING!
    - Right: ListBugs -fsa (status) (assignee) -ss
    - Wrong: ListBugs -ss -fsa (status) (assignee)
    
• List tasks with assignee.
  o Filter by status and/or assignee / -fs, -fa, -fsa /
  o Sort by title / -st /
    - NOTE! FILTER IS ALWAYS BEFORE SORTING!
    - Right: ListTasksWithAssignee -fsa (status) (assignee) -st
    - Wrong: ListTasksWithAssignee -st -fsa (status) (assignee)

