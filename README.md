# Internet discussion demo app

**How to use**

Profile IIS Express launches project on URL http://localhost:54189.
The database is deleted and recreated on each start with dummy data from InternetDiscussionContext.
Logger output is shown on the console window.
The sequence of example REST calls for the Postman app is added to this solution 
https://github.com/MartinMatko/Mathesio/blob/master/Matthesio.postman_collection.json.

----------

**Implemented functionality**

Entities in applications are author, the topic of discussion and reply to the given topic.
I implemented only creating and retrieving of author and topic because it's enough for demonstrating architecture and design patterns I would use for the whole app.
User is able to:

 - List all authors http://localhost:54189/api/authors
 - Retrieve info about one author http://localhost:54189/api/authors/1
 - List all topics (lookups) for the author http://localhost:54189/api/authors/1/topics
 - Retrieve complete info about one topic of the author http://localhost:54189/api/authors/1/topics/1
 - Create a new author http://localhost:54189/api/authors
 - Create a new topic for the author http://localhost:54189/api/authors/1/topics

----------
**Project structure**


 1. DbContexts (a bridge between domain entities and the database)
 2. Entities (domain entities Author, Topic)
 3. Services (Repository for DAL)
 3. Models (DTO)
 4. Profiles (mapping entities and DTOs)
 5. Controllers (CRUD operations on entities)
 6. Tools (Logger)

----------
**Design patterns**


 1. Singleton for logger (dependency injection would be too cumbersome for the bigger app)
 2. Lazy initialization for logger instance (creating instance only when it is truly needed)
 3. Dependency injection of InternetDiscussionContext and InternetDiscussionRepository (creating and disposing is managed by dependency injection container of .NET core)

----------
**Architectural patterns**

 1. Repository for data access layer
 2. DTO so API doesn't have to reflect DB schema, performance improvement - for list of topics TopicLookupDTO loads only titles and not huge texts in the description
 3. MVC for loose coupling between frontend and backend ("view in the model basically returns the value of microservice")
