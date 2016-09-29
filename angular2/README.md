# TDiary.Angular2
Angular2 (rc4) UI to Consume the API data served by .NET Core TDiary Project

# Installation notes
1. Set up the WebApi from the [TDiary Project](http://github.com/jakimber/tdiary "TDiary Project") as that is where this product gets its data from.
2. clone this repo `git clone http://github.com/jakimber/tdiary.angular2`
3. `cd ./tdiary.angular2`
3. `npm install`
4. Adust the api `baseUrl` to where your WebApi is running from in data.service.ts
4. `npm start`

# Version Notes
* Upgraded to AngularJs V2.0.0 rc4
* Upgraded to use the new Router, Router-deprecated is no longer
* Upgraded to the new Forms model as old one is to be deprecated in next release.