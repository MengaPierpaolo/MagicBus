# Magic Bus Travel Diary
# .NET Core (RC2) Sample Project
---
## Summary
Using the dotnet core command line, trying to use just VSCode (to prove it's possible), and relying on Visual Studio when the reliable old friend helps avoid a headache, here's a sample application using the theme of a Travel Diary as it's domain.  This helps to find issues and learn much quicker than using the very simple quick-start projects that i have found dotted around.

## Architecture Overview
The project consists of two main parts.

1. The Web UI - An ASP.NET Core MVC application intended to be the UI for the application.  In other GitHub repositories, I have created Angular2 and ReactJs versions of the UI too.

2. An Asp.Net Core WebApi that is used to serve and save data from the UI of choice into (for now) a SQLite Database created using Entity Framework Core Code Migrations.

## Editor Choice
The projects an be edited using Visual Studio 2015 Update 2, or VSCode 1.1+

---
## Requirements
### VS Code:
* Visual Studio Code 1.1+
* Microsoft .NET Core 1.0.0 RC2 - SDK Preview

### If you prefer Visual Studio:
* Visual Studio 2015 Update 2
* Microsoft .NET Core 1.0.0 RC2 - SDK Preview
* Microsoft .NET Core 1.0.0 RC2 - VS 2015 Tooling Preview

### Extra Tools required
* Node.js 4.4.*
* Bower

### Client Dependencies in use
* bootstrap 3.3.6
* jquery 1.11.2 +
* jquery-validation
* jquery-validation-unotrusive

---
## Initial setup instructions
---
*Note:* It is recommended to run the projects with the assistance of a local instance of IIS rather than two seperate instances of VSCode or Visual Studio

### VSCode
1. `git clone https://github.com/jakimber/tdiary`
2. `cd .\tdiary\`
2. `dotnet restore`
3. `cd .\src\TDiary\`
4. `bower install`
5. `dotnet ef database update --context MigrationsContext`
6. To develop the WebApi, You will need to move the database from the MVC project to the Api Project: `copy .\bin\Debug\netcoreapp1.0\TDiary.db ..\TDiary.Api\bin\Debug\netcoreapp1.0\TDiary.db`  you can then `cd ..\TDiary.Api\` and then `dotnet run`
7. To develop the Web UI, make sure the above WebApi setup is completed and that you are running it in a second instance of your editor, or that you are hosting the WebApi in a local instance of IIS.
8. ensure you are in the TDiary\src\TDiary directory and then `dotnet run` (or run the project in your editor)

*Note:* you will need to adjust web ports due to conflicts if you are debugging both projects in VSCode rather than relying on a local instance of IIS to host.  You can do this with a combination of the Url in AppSettings.json and the use of .UseUrls("http://localhost:5050") in the startup.cs of one of the projects

---
### Visual Studio
1. `git clone https://github.com/jakimber/tdiary`
2. Open .\src\TDiary\TDiary.xproj in VS
3. Build the solution
4. `update-database -Context MigrationsContext` in package manager console
5. To develop the WebApi, You will need to move the database from the MVC project to the Api Project: `copy .\bin\Debug\netcoreapp1.0\TDiary.db ..\TDiary.Api\bin\Debug\netcoreapp1.0\TDiary.db`
6. open the .\src\TDiary.Api\TDiary.Api.xproj in VS then F5
7. To develop the UI, ensure you have the TDiary.Api project running in local IIS, or another Visual Studio instance.  You can then use the Visual Studio F5 debugging experience

*Note:* you may need to adjust web ports due to conflicts or randomly assigned ports if you are debugging both projects in Visual Studio rather than relying on a local instance of IIS to host.  You can do this with a combination of changing the Url in AppSettings.json and the use of .UseUrls("http://localhost:5050") in the startup.cs of the projects

