# Mathesio
 Internet discussion demo app


Design patterns used:
Singleton for logger (dependency injection would be too cumbersome for bigger app)
Lazy initialization for logger instance (creating instance only when it is truly needed)
Dependency injection of InternetDiscussionContext and InternetDiscussionRepository (creation and disposing is managed by dependency injection container)

Architectural patterns:
Repository for data access layer
DTO so API don't have to reflect DB schema, performance improvement - for list of topics TopicLookupDTO loads only titles and not huge texts in description
MVC for loose coupling between frontend and backend ("view in model is basically return value of microservice")

P.s.
I was thinking where I could use Factory, but decided that for the sake of navigation using different URIs would be better then creating controllers from Factory.