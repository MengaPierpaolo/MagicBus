# Magic Bus Travel Diary

## .NET Core Sample Project

See a working prototype version at our [Pre-Production publish location](<http://magicbus.azurewebsites.net/> "See a working prototype")

## Summary

Using the dotnet core 1.0.0 command line tools and VSCode here's a sample application using the theme of a Travel Diary as it's domain.

*Note: Please see the Issues log in Github for known issues and enhancements that are still in progress.

## Architecture Overview

The project consists of two main parts.

1. The Web UI - An ASP.NET Core MVC application intended to be the UI for the application.  In other GitHub repositories, I have created Angular2 and ReactJs versions of the UI too.
1. An Asp.Net Core WebApi that is used to serve and save data from the UI of choice into (for now) a SQLite Database created using Entity Framework Core Code Migrations.

## Editor Choice

The projects an be edited using VSCode 1.1+ or Visual Studio 2015 Update 3

---

## Requirements

### VS Code

* Visual Studio Code 1.1+
* Microsoft .NET Core 1.0.1 SDK

### If you prefer Visual Studio

* Visual Studio 2015 Update 3
* Microsoft .NET Core 1.0.1 SDK
* Microsoft .NET Core 1.0.1 VS 2015 Tooling Preview 2

### Extra Tools required

* Node.js 4.4.*
* Bower

### Client Dependencies in use

* bootstrap 3.3.6
* font-awesome
* jquery 1.11.2 +
* jquery-validation
* jquery-validation-unotrusive

---

## Initial setup instructions

---

### VSCode

1. `git clone https://github.com/jakimber/tdiary`
1. `cd .\tdiary\`
1. `dotnet restore`
1. `cd .\src\TDiary\`
1. `bower install`1
1. `cd ..\TDiary.Api`
1. `dotnet ef database update --context MigrationsContext`
1. To develop the WebApi, `dotnet run`
1. To develop the Web UI, make sure the above WebApi setup is completed and that you are running it in a second instance of your editor, or that you are hosting the WebApi in a local instance of IIS.
1. `cd ..\TDiary`
1. `dotnet ef database update --context UserDbContext` will create the users.db for AspNet Identity.
1. `dotnet ef database update --context LocalizationDbContext` will create the localization.db for language localization.
1. `dotnet run` (or run the project in your editor)

---

### Visual Studio

1. `git clone https://github.com/jakimber/tdiary`
1. Open .\src\TDiary.Api\TDiary.Api.xproj in VS
1. Wait for the restore to finish and then Build the solution
1. `update-database -Context MigrationsContext` in package manager console
1. You can now develop the WebApi
1. To develop the UI, ensure you have the TDiary.Api project running in local IIS, or another Visual Studio instance.  Then
1. open .\src\TDiary\TDiary.xproj
1. `dotnet ef database update --context UserDbContext` will create the users.db for AspNet Identity.
1. `dotnet ef database update --context LocalizationDbContext` will create the localization.db for language localization
1. Run the project
