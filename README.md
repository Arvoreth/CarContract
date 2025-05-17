# Sample Implementation of EF Core, API & SignalR
This project is a simplified practice implementation inspired by the *Application Integration and Security* exam. It demonstrates key concepts using three core entities: `Car`, `Customer`, and `Contract`.

Note that in the original exam, these parts were implemented as **three separate projects**. For simplicity and clarity, I’ve combined them into one project here. 
It focuses on structure, core logic, and integrating EF Core, Web APIs, and SignalR in one place. 


### Task #1 - Entity Framework Core
---
- Models defined for all 3 entities (Car, Customer, Contract)
- DbContext created with DbSet<> properties and migrations applied
- Data seeding into DB of mock data
- Example query
  

### Task #2 - API
---
- Endpoints table including URI, Route, and Response format
- Fully implemented Controllers for all entities
- Controller registration and MapControllers() setup in Program.cs



### Task #3 - SignalR
---
- GameHub created to manage SignalR communication
- IGameHubClient interface defined
- Services and MapHub added in Program.cs
- index.html contains the SignalR frontend setup with connection string
