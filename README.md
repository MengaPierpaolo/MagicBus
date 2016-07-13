# Magic Bus Travel Diary
# .NET Core Sample Project
See a working prototype version at our [Pre-Production publish location](http://magicbus.azurewebsites.net/ "See a working prototype")
---
## Summary
Using the dotnet core command line, trying to use just VSCode (to prove it's possible),
and relying on Visual Studio when the reliable old friend helps avoid a headache,
here's a sample application using the theme of a Travel Diary as it's domain.
This has helped to learn and find issues much quicker than using the very simple quick-start projects that i have found dotted around.

*Note: Please see the Issues log in Github for known issues and enhancements that are still in progress.

## Architecture Overview
The project consists of two main parts.

1. The Web UI - An ASP.NET Core MVC application intended to be the UI for the application.
In other GitHub repositories, I have created Angular2 and ReactJs versions of the UI too.
2. An Asp.Net Core WebApi that is used to serve and save data from the UI of choice into (for now)
a SQLite Database created using Entity Framework Core Code Migrations.

The solution has then been divided into different dotnet projects to match a tried and tested
architecture which provides for relative ease of maintenance and optional swapping of component pieces.

## Editor Choice
The projects an be edited using VSCode 1.1+ or Visual Studio 2015 Update 2

---
## Requirements
### VS Code:
* Visual Studio Code 1.1+
* Microsoft .NET Core 1.0.0 SDK

### If you prefer Visual Studio:
* Visual Studio 2015 Update 3
* Microsoft .NET Core 1.0.0 SDK
* Microsoft .NET Core 1.0.0 VS 2015 Tooling Preview 2

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
*Note:* It is recommended to run the projects with the assistance of a local instance
of IIS rather than two seperate instances of VSCode or Visual Studio

### VSCode
1. `git clone https://github.com/jakimber/tdiary`
2. `cd .\tdiary\`
2. `dotnet restore`
3. `cd .\src\TDiary\`
4. `bower install`
5. `cd ..\TDiary.Api`
5. `dotnet ef database update --context MigrationsContext` Note:  I have an [outstanding issue] (https://github.com/aspnet/EntityFramework/issues/5894) with migrations after EF Core v1.0.0.  I am having to rename the table name in the migration file, and then rename it in the db (sqlite.exe) once it's created.  Waiting on response to issue.  You will need to `ALTER TABLE Experience RENAME TO Experiences` in sqlite.exe for this to work past this point.
6. To develop the WebApi, `dotnet run`
7. To develop the Web UI, make sure the above WebApi setup is completed and that you are running it in a second instance of your editor, or that you are hosting the WebApi in a local instance of IIS.
8. `cd ..\TDiary`
9. `dotnet ef database update` will create the users.db for AspNet Identity.
10.  `dotnet run` (or run the project in your editor)

---
### Visual Studio
1. `git clone https://github.com/jakimber/tdiary`
2. Open .\src\TDiary.Api\TDiary.Api.xproj in VS
3. Wait for the restore to finish and then Build the solution
4. `update-database -Context MigrationsContext` in package manager console
5. You can now develop the WebApi
7. To develop the UI, ensure you have the TDiary.Api project running in local IIS, or another Visual Studio instance.  Then
8. open .\src\TDiary\TDiary.xproj
9. `update-database` in package manager console to create the Users.db for AspNet Identity
10. Run the project
