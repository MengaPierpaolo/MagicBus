# TDiary
# .NET Core RC2 Travel Diary Project

## Notes
1. Can be edited using Visual Studio 2015 Update 2, or VSCode 1.1+
3. Uses EF to SQLite.  Please see initial setup instruction below.

---
## Requirements
### Visual Studio
1. Visual Studio 2015 Update 2
2. Microsoft .NET Core 1.0.0 RC2 - SDK Preview
3. Microsoft .NET Core 1.0.0 RC2 - VS 2015 Tooling Preview

### VS Code
1. Visual Studio Code 1.1+
2. Microsoft .NET Core 1.0.0 RC2 - SDK Preview

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
### VSCode
1. `git clone https://github.com/jakimber/tdiary`
2. `cd tdiary`
2. `dotnet restore`
3. `bower install .\src\TDiary`
4. `dotnet ef database update --context MigrationsContext`
5. `dotnet run` (or run in vscode after autogeneration of task-runner and launch files)

### Visual Studio
1. Clone the repo
2. Open TDiary.xproj and add any of the dependencies you wish to debug to the created .sln file
3. 'update-database --context MigrationsContext' in package manager console
