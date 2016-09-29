# Magic Bus - React
---
A React.js version of the Magic Bus Travel Diary UI first developed as a dotnet core MVC app ([see main project page](https://github.com/jakimber/MagicBus "Magic Bus Project"))

---
# System Prerequisties
1. Node & npm

# Initial setup instructions
1. Set up an instance of the [MagicBus Api](https://github.com/jakimber/MagicBus "Magic Bus Project"))
1. `cd ./src/MagicBus.UI.React` 
1. `npm install`
4. There is currently a hard-coded Api path in for the data - manually change this according to the port where you are running the instance of the Api.
5. `npm run webpack`
6. in a second command window `npm start`

# Known issues
1. After updgrading to 15.2 [See this](https://github.com/themeteorchef/base/issues/157)
filter the errors in chrome dev-tools with this: `^(?!.*?Unknown prop)` in the filter box

# Dependency info (see package.json)
1. babel for transpiling
2. webpack (with a couple of plugins) for packaging .js and .css
3. browser-synch for auto-reload
4. react and react-bootstrap
5. Bootstrap for basic reactive styling
6. jQuery, as it's a dependency for bootstrap with the current version
7. flux for store/distributor/component architecture
8. [axios](https://github.com/mzabriskie/axios "axios on github") for ajax calls
