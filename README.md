# TDiary
# .NET Core (RC2) Travel Diary Project
---
## Summary
Using the dotnet core command line, trying to use just VSCode (to prove it's possible), and relying on Visual Studio when the reliable old friend helps avoid a headache, here's a sample application using the theme of a Travel Diary as it's domain.  This helps to find issues and learn much quicker than using the very simple quick-start projects that i have found dotted around.

## Architecture Overview
The project consists of two main parts.
1. The Web UI - An ASP.NET Core MVC application intended to be the UI for the application.  In other GitHub repositories, I have created Angular2 and ReactJs versions of the UI too.
2. An Asp.Net Core WebApi that is used to serve and save data from the UI of choice into (for now) a SQLite Database created using Entity Framework Core Code Migrations.

## Editor Choice
1. Can be edited using Visual Studio 2015 Update 2, or VSCode 1.1+
3. Uses EF to SQLite.  Please see initial setup instruction below.

---
## Requirements
### VS Code:
1. Visual Studio Code 1.1+
2. Microsoft .NET Core 1.0.0 RC2 - SDK Preview

### If you prefer Visual Studio:
1. Visual Studio 2015 Update 2
2. Microsoft .NET Core 1.0.0 RC2 - SDK Preview
3. Microsoft .NET Core 1.0.0 RC2 - VS 2015 Tooling Preview

### Tools
1. Node.js 4.4.*
2. Bower

### Client Dependencies in use
1. bootstrap 3.3.6
2. jquery 1.11.2 +
3. jquery-validation
4. jquery-validation-unotrusive

---
## Initial setup instructions
---
### VSCode
1. `git clone https://github.com/jakimber/tdiary`
2. `cd .\tdiary\`
2. `dotnet restore`
3. `cd .\src\TDiary\`
4. `bower install`
5. `dotnet ef database update --context MigrationsContext`

*Note:* It is recommended to run the projects from this point with the assistance of a local instance of IIS

To develop the WebApi, You will need to move the database from the MVC project to the Api Project:

6. `copy .\bin\Debug\netcoreapp1.0\TDiary.db ..\TDiary.Api\bin\Debug\netcoreapp1.0\TDiary.db`
7. `cd ..\TDiary.Api\` and then `dotnet run`

To develop the Web UI, make sure the above 2 items for the WebApi are completed or that you are hosting the WebApi in IIS

*Note:* you may need to adjust web ports due to conflicts if you are debugging both projects in VSCode rather than relying on a local instance of IIS to host.  You can do this with a combination of the Url in AppSettings.json and the use of .UseUrls("http://localhost:5050") in the startup.cs of one of the projects

8. ensure you are in the TDiary\src\TDiary directory and then `dotnet run` or *run* in vscode after autogeneration of task-runner and launch files

---
### Visual Studio
1. `git clone https://github.com/jakimber/tdiary`
2. Open .\src\TDiary\TDiary.xproj in VS
3. Build the solution
4. `update-database -Context MigrationsContext` in package manager console

To develop the WebApi, You will need to move the database from the MVC project to the Api Project:
5. `copy .\bin\Debug\netcoreapp1.0\TDiary.db ..\TDiary.Api\bin\Debug\netcoreapp1.0\TDiary.db`
6. open the .\src\TDiary.Api\TDiary.Api.xproj in VS then F5

7. To develop the UI, ensure you have the TDiary.Api project running in local IIS, or another Visual Studio instance

*Note:* you will need to adjust web ports due to conflicts if you are debugging both projects in Visual Studio rather than relying on a local instance of IIS to host.  You can do this with a combination ofchanging the Url in AppSettings.json and the use of .UseUrls("http://localhost:5050") in the startup.cs of one of the projects

You can then use the Visual Studio F5 debugging experience
