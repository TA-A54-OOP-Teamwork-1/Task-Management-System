# Task-Management-System
-- Group project developed by Plamen and Ventsislav --

Task Management System is a console application that will help a small team of developers to organize and manage their work tasks.
The application supports Bug, Story and Feedback tasks and the following commands:<br><br>
**NOTE: no whitespaces are allowed in the input arguments**

1. Create a new person. / requires person name /<br>
  • **CreatePerson TestPerson**

2. Show all people.<br>
  • **ShowAllPeople**

3. Show person's activity. / required person name /<br>
	• **ShowPersonActivity TestPerson**

4. Create a new team. / requires team name /<br>
  • **CreateTeam TestTeam**

5. Show all teams.<br>
  • **ShowAllTeams**

6. Show team's activity. / requires team name /<br>
  • **ShowTeamActivity TestTeam**

7. Add person to team. / requires person name and team name /<br>
  • **AddPersonToTeam TestPerson TestTeam**

8. Show all team members. / requires team name /<br>
  • **ShowAllTeamMembers TestTeam**

9. Create a new board in a team. / requires board name and a team name /<br>
  • **CreateBoard TestBoard TestTeam**

10. Show all team boards. / requires team name /<br>
  • **ShowAllTeamBoards TestTeam**

11. Show board's activity. / requires board name /<br>
  • **ShowBoardActivity TestBoard**

12. Create a new Bug in a board. / requires title, description, priority, severity, steps to reproduce and board name /<br> 
  • **CreateBug FixPrintingTeamFunctionality TeamMembeersAreNotIndented High Major CreateNewTeam;AddTwoNewMembers;PrintTeam; TestBoard**

13. Create a new Story in a board. / requires title, description, priority, size, board name /<br>
  • **CreateStory SomeStoryTitle SomeStoryDescription Medium Medium TestBoard**

14. Create a new Feedback in a board. / requires title, description, rating, board name /<br>
  • **CreateFeedback SomeFeedbackTitle SomeFeedbackDescription 3 TestBoard**

15. Change the Priority/Severity/Status of a bug. / requires bug id and new value /<br>
  • **ChangeBugPriority 0 Low**<br>
  • **ChangeBugSeverity 0 Minor**<br>
  • **ChangeBugStatus 0 Fixed**

16. Change the Priority/Size/Status of a story. / requires story id and new value /<br>
  • **ChangeStoryPriority 1 Low**<br>
  • **ChangeStorySize 1 Minor**<br>
  • **ChangeStoryStatus 1 Done**
  
17. Change the Rating/Status of a feedback. / requires feedback id and new value /<br>
  • **ChangeFeedbackRating 2 5**<br>
  • **ChangeFeedbackStatus 2 Scheduled**<br>
  
18. Assign/Unassign a task to a person. / requires task id and person name /<br> 
  • **AssignTaskToPerson 0 TestPerson**
  
19. Add comment to a task. / author, comment content and task id /<br>
  • **AddCommentToTask Author 0 SomeCommentFromAuthor**

20. List all tasks.<br><br>
	• Filter by title / -ft /  
      		- **ListAllTasks -ft**<br><br>
    	• Sort by title / -st /<br>
	• NOTE! FILTER IS ALWAYS BEFORE SORTING!<br>
	• Right: ListAllTasks -ft -st<br>
	• Wrong: ListAllTasks -st -ft <br>
		- **ListAllTasks -ft -st**

22. List bugs/stories/feedback only.
  o Filter by status and/or assignee / -fs, -fa, -fsa /
  o Sort by title/priority/severity/size/rating (depending on the task type) / -st, -sp, -ss, -ss, -sr / 
    - NOTE! BOTH SIZE AND SEVERITY ARE /-ss/ BUT SIZE IS FOR STORIES AND SEVERITY IS FOR BUGS. FILTER IS ALWAYS BEFORE SORTING!
    - Right: ListBugs -fsa (status) (assignee) -ss
    - Wrong: ListBugs -ss -fsa (status) (assignee)
    
23. List tasks with assignee.
  o Filter by status and/or assignee / -fs, -fa, -fsa /
  o Sort by title / -st /
    - NOTE! FILTER IS ALWAYS BEFORE SORTING!
    - Right: ListTasksWithAssignee -fsa (status) (assignee) -st
    - Wrong: ListTasksWithAssignee -st -fsa (status) (assignee)

