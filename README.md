# TDiary.React
---
A React.js version of the TDiary UI
---
# System Requirements
1. Node & npm
2. `npm install webpack browser-sync -g`
3. Optional: Local instance of IIS

# Initial setup instructions
1. Set up an instance of TDiary.Api in Local IIS if not running it in node / VSCode / VS
2. Clone the repo
3. `npm install`
4. There is a currently hard-coded path to the WebApi for the data - change accordingly
5. `npm run webpack`
6. `npm run start`

# Dependency info (see package.json)
1. babel for transpiling
2. webpack (with a couple of pluugins) for packaging .js and .css
3. browser-synch for auto-reload
4. react and react-bootstrap
5. Bootstrap for basic reactive styling
6. flux for store/distributor.component architecture
7. jQuery for ajax calls to WebApi
