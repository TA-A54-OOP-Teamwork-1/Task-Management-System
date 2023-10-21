# Task-Management-System

Task Management System is a group project developed by Plamen and Ventsislav.

It is a console application that will help a small team of developers to organize and manage their work tasks.

The application supports the following commands:

• Create a new person. / requires person name /
• Show all people.
• Show person's activity. / required person name /
• Create a new team. / requires team name /
• Show all teams.
• Show team's activity. / requires team name /
• Add person to team. / requires person name and team name /
• Show all team members. / requires team name /
• Create a new board in a team. / requires board name and a team name /
• Show all team boards. / requires team name /
• Show board's activity. / requires board name /
• Create a new Bug in a board. / requires title, description, priority, severity, steps to reproduce and board name / 
• Create a new Story in a board. / requires title, description, priority, size, board name /
• Create a new Feedback in a board. / requires title, description, rating, board name /
• Change the Priority/Severity/Status of a bug. / requires bug id and new value /
• Change the Priority/Size/Status of a story. / requires story id and new value /
• Change the Rating/Status of a feedback. / requires feedback id and new value /
• Assign/Unassign a task to a person. / requires task id and person name / 
• Add comment to a task. / comment content and task id /

o List all tasks.
• Filter by title / -ft /
• Sort by title / -st /
  - NOTE! FILTER IS ALWAYS BEFORE SORTING
  - Right: ListAllTasks -ft -st
  - Wrong: ListAllTasks -st -ft

o List bugs/stories/feedback only.
• Filter by status and/or assignee / -fs, -fa, -fsa /
• Sort by title/priority/severity/size/rating (depending on the task type) / -st, -sp, -ss, -ss, -sr / 
  - NOTE! BOTH SIZE AND SEVERITY ARE /-ss/ BUT SIZE IS FOR STORIES AND SEVERITY IS FOR BUGS
          FILTER IS ALWAYS BEFORE SORTING
  - Right: ListBugs -fsa (status) (assignee) -ss
  - Wrong: ListBugs -ss -fsa (status) (assignee)
    
o List tasks with assignee.
• Filter by status and/or assignee / -fs, -fa, -fsa /
• Sort by title / -st /
  - NOTE! FILTER IS ALWAYS BEFORE SORTING
  - Right: ListTasksWithAssignee -fsa (status) (assignee) -st
  - Wrong: ListTasksWithAssignee -st -fsa (status) (assignee)

