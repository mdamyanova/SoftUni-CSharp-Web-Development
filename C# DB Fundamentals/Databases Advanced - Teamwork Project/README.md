# Everyday Journal - Software University DB Advanced Teamwork Project 
Everyday Journal is Console-Based application, using C#, Entity Framework and SQL Server.
The idea of the project is to represent e-Journal mainly for tasks for the day and food counsumed by the day.
Everyday Jorunal can help for living a healthy life if the user has some individual diet and if he would like easy access to look for his diet.

## General Requirements for the Project
- Full range of **CRUD operations** 
  - **Create** eating for the day/part of the day, create task/s for the day
  - **Read** information about current day/choosen day
  - **Update** information about the food/tasks of choosen day
  - **Delete** information about the food/tasks of choosen day
- **Console-Based** application
- **Underlying Database** - MS SQL Server
- **Object-Relational Mapping technology** - Entity Framework
- **Version Control System** - Git

## Tables and Relations of the Project
- Main Tables
  - Foods 
    - Id (int), Food (string), Date (relation with table Dates) 
  - Tasks
    - Id (int), Task (string), Date (relation with table Dates)
  - Mornings 
    - Id (int), Food (relation with table Foods), Task (relation with table Task), Date (relation with table Date)
  - Afternoons
    - Id (int), Food (relation with table Foods), Task (relation with table Task), Date (relation with table Date)
  - Evenings 
    - Id (int), Food (relation with table Foods), Task (relation with table Task), Date (relation with table Date)
  - Dates 
    - Id (int), Date (Date), Foods (relation with table Foods), Tasks (relation with table Tasks)
- Relation Tables 
  - DateFood 
    - DateId, FoodId
  - DateTasks 
    - DateId, TaskId
    
## Contributors
[mdamyanova](https://github.com/mdamyanova)
[Martotko](https://github.com/Martotko)
[lubomirv999](https://github.com/lubomirv999)
[Milena81](https://github.com/Milena81)
