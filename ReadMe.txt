Payroc technical audition

Technology Auditon – URL Shortner 
 
The Problem  
 
Context: Imagine that It's the summer of 2006. Twitter launched just a few months ago, and "tweeting" has become all the rage.   
 
You: You're a CS undergrad at Stanford University, and you love to tweet all day long with your friends, especially when you're in class. One thing you find that you're doing a lot is sharing a lot of URLs. Cool blogs you've read and links to funny cat pictures. But URLs are long and don't leave much room for anything else in your tweet. One day, you go to paste a Google Maps URL or New York Times article into a tweet, and BAM! You're already over the 140 character limit.  You think: "there's got to be a better way."  
 
Your big idea: You decide to architect and build the world's first URL shortening service.  This is going to be your big start-up idea. You're going to be rich, or at least internet-famous.  You have your laptop, $100 (for cloud hosting, and for GoDaddy to register a domain) and a free weekend. "That's all an entrepreneur needs these days," you think.  
 
Let's go. 



URL shortener


1. verify url is safe and url
2. write restful api to retrieve url based on shortened url and respond with redirect
3. noSQL database takes shortened url returns url to redirect to

UI

1. Validates that field is url
2. button to submit to get shortened url
3. checks if shortend url already exists for that address - if yes, return shortened url if no generate and add to nosql db
4. bonus - add button to copy newly returned shortened url

Dev setup
Visual Studio 2019
C#.NET
chocolately (optional)

choco install redis-64


Limitations
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