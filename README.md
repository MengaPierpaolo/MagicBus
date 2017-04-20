# Magic Bus Travel Diary

## Summary

Using dotnet core and ReactJS here's a sample application using the theme of a Travel Diary as it's domain.

*Note: Please see the Issues log in Github for known issues and enhancements that are still in progress.

## Architecture Overview

The project consists of two parts.

1. An Asp.Net Core WebApi that is used to serve and save data from the UI of choice into (for now) a SQLite Database created using Entity Framework Core Code Migrations.

1. The Web UI.  One of two options all using the same WebApi as the datasource:
    1. An ASP.NET Core 1.1 MVC application.
    1. A ReactJS SPA UI.

## Development Requirements

* Visual Studio Code
* Microsoft .NET Core 1.1.1 SDK
* Node.js
* Bower

### Client Dependencies in use

* jquery
* font-awesome
* jquery-validation
* jquery-validation-unotrusive
* bootstrap + datepicker

## Initial setup instructions

NOTE: To develop the Web UIs, make sure the WebApi setup is completed and that you are running it in a second instance of your editor or a local instance of IIS.  There are further instructions in the relevant UI subfolders.

### WeAbpi

1. `git clone https://github.com/jakimber/MagicBus`
1. `cd .\MagicBus\src\MagicBus.Api\`
1. `dotnet restore`
1. `dotnet run` (or run the project in your editor)

### MVC UI

1. Get the WebApi above running first
1. `cd .\MagicBus\src\MagicBus.UI.MVC\`
1. `dotnet restore`
1. `bower install`
1. `dotnet run` (or run the project in your editor)

### ReactJS UI

[See the relevant project page for further information](https://github.com/jakimber/MagicBus/tree/master/src/MagicBus.UI.React "MagicBus ReactJS UI")
