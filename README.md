# Cashless Registrations

Microservice developed using ASP.NET Core and Entity Framework Core (In Memory)

## Features
- Save Customer Card data and generate Token for cashless registration. 
- Validate customer card and token data

## Technologies, Architecture and Patterns
- ASP.NET Core
- Entity Framework Core (In-Memory)
- Clean Architecture with Core, Infrastructure, Application and API layers. 
- Repository Pattern for data access
- Unit Testing using xUnit and Moq
- Error Handling using Exception Handler on ErrorController

## Layers responsibilities
- Core: contains the Domain Services, Entities and Repositories' interfaces. Entity classes use private sets on their properties for immutability reinforcement.
- Infrastructure: contains the Repositories implementations and DbContext class
- Application: contains the Application services (responsible for use cases), and View Models and Input Models.
- API: contains the Controllers, and dependency injection, Swagger, In-Memory DbContext and ErrorHandling configurations

