# Magic Bus - React
---
A React.js version of the Magic Bus Travel Diary UI first developed as a dotnet core MVC app (see other repository)
---
# System Requirements
1. Node & npm
2. `npm install webpack browser-sync -g`
3. Optional: Local instance of IIS

# Initial setup instructions
1. Set up an instance of TDiary.Api in Local IIS if not running it in node / VSCode / VS (See the Readme instructions in the [Original Project](https://github.com/jakimber/tdiary "Original Magic Bus Project"))
2. Clone this repo
3. `npm install`
4. There is a currently hard-coded path to the WebApi for the data - change according to the port where you are running the TDiary.Api
5. `npm run webpack`
6. `npm run start`

# Dependency info (see package.json)
1. babel for transpiling
2. webpack (with a couple of plugins) for packaging .js and .css
3. browser-synch for auto-reload
4. react and react-bootstrap
5. Bootstrap for basic reactive styling
6. flux for store/distributor/component architecture
7. [axios](https://github.com/mzabriskie/axios "axios on github") for ajax calls
