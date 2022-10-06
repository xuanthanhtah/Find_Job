# Find_Job_Solution
## Technologies
- ASP.NET 6
- Entity Framework
## Install packages 
- microsoft.entityframeworkcore.sqlserver
- microsoft.entityframeworkcore.tools
- microsoft.entityframeworkcore.design  
## Database creation guide
- edit AppSettings.json according to your computer
- right click FindJobSolotion.Data
- choose Open In Terminal
- type dotnet ef migrations add createdb
- type dotnet ef database update
