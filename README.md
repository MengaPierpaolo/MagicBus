# TDiary
## .NET Core RC2 Travel Diary Project

## Notes
1. Can be edited using Visual Studio 2015 Update 2, or VSCode 1.1
2. If wanting to debug, Visual Studio is still the best tool as VSCode support for multi project debugging is still TBD
3. Uses EF to SQLite.  Please see initial setup instruction below.

## Requirements
### Visual Studio
1. Visual Studio 2015 Update 2
2. Microsoft .NET Core 1.0.0 RC2 - SDK Preview
3. Microsoft .NET Core 1.0.0 RC2 - VS 2015 Tooling Preview

### VS Code
1. Visual Studio Code 1.1.0
2. Microsoft .NET Core 1.0.0 RC2 - SDK Preview

### Tools
1. Node.js 4.4.*
2. Bower
3. Gulp

### Client Dependencies
1. bootstrap 3.3.6
2. jquery 1.11.2 +
3. jquery-validation
4. jquery-validation-unotrusive

### Initial setup instructions - VSCode (to automate)
1. Clone the repo
2. dotnet restore in \TDiary and \TDiary.Model
3. dotnet build in \TDiary
4. dotnet ef database update in \TDiary
5. bower install in \TDiary
6. dotnet run (or run in vscode)

### Initial setup instructions - Visual Studio
1. Clone the repo
2. Open the .sln file
3. 
