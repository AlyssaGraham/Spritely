Dev setup
chocolately (optional)

Requirements
Redis instance
node
dotnet


The Memurai redis for windows can be used for local testing
https://www.memurai.com/
> choco install redis-64

Dev setup
Verify and configure Redis instance
You can use memurai-cli.exe if using Memurai

Sample command
e.g. SET test "Hello world"
GET test
> "Hello world"

navigate to .\spritely\spritely 
> dotnet run spritely.csproj

navigate to .\spritely\spritely-ui\
> npm run serve

Default dev configurations 
Redis: http://localhost:6379
Spritely UI: http://localhost:8080
Spritely Api: http://localhost:5000
Swagger: http://localhost:5000/swagger/v1/swagger.json

Configurations
.\spritely\spritely\spritely-ui\src\config\config.json 
	spritelyHost: host of Spritely backend

.\spritely\spritely\appsettings.json
	Redis.host: Redis instance host
	Redis.port: Redis instance port

Limitations
- Add testing
- Logging needs to be implemented
- Better error handling needs to be implemented
- Implement usage limits (could lead to tiered subscription model)
	- This is mostly to prevent DDOS
- Improve testing coverage
- Prevent malicious URLs from being shortened - need to research resources for this
- Need to implement a better way to issue random shortURLs and handling the need to increment the number of characters in the random string
- Implement the ability to make custom short links (could be part of the tiered subscription model)
- Improve ReadME / write in Markdown
- Build CI/CD
- Implement a performant way to reuse shortlinks for the same URLs
- Implement clean up of old shortlinks
- Implement ability to have shortlinks expire in a user specified amount of time
- localization
- accessibility
- create wiremock for Redis to remove that as a necessity for local development
- Create Postman collection
