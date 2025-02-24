# Identity Service with CQRS and DDD 🚀

[![GitHub stars](https://img.shields.io/github/stars/Pavan8374/cqrs-ddd.svg)](https://github.com/Pavan8374/cqrs-ddd/stargazers)
[![License](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE)

A robust Identity Service implementation using CQRS (Command Query Responsibility Segregation) and DDD (Domain-Driven Design) patterns in .NET. This project demonstrates clean architecture principles with a focus on maintainability and scalability.

## ⭐ Star this Repository!
If you find this implementation helpful, please consider giving it a star! It helps others discover this pattern and implementation.

## 🏗️ Architecture Overview

The solution follows a clean architecture approach with these key layers:

```
src/
├── Identity.Api/            # API Controllers and configuration
├── Identity.Application/    # Application logic, commands, and queries
├── Identity.Domain/         # Domain models and business logic
└── Identity.Infrastructure/  # External concerns and implementations
```

### Project Structure Details

#### 🎯 Identity.Domain
Core business logic and domain models:
- `Aggregates/` - Domain aggregates
- `Common/` - Base classes and shared components:
  - `AggregateRoot.cs` - Base for aggregate roots
  - `DomainEvent.cs` - Domain event definitions
  - `DomainException.cs` - Custom domain exceptions
  - `Entity.cs` - Base entity class
  - `Enumeration.cs` - Smart enum implementation
  - `Result.cs` - Operation result wrapper
  - `ValueObject.cs` - Value object base class
- `Entities/` - Domain entities
- `Events/` - Domain events
- `ValueObjects/` - Value objects for domain models

#### 📋 Identity.Application
CQRS implementation and application logic:
- `Commands/` - Command handlers organized by feature
  ```
  Commands/
  ├── Users/
  │   ├── CreateUser/
  │   │   ├── CreateUserCommand.cs
  │   │   └── CreateUserCommandHandler.cs
  │   └── UpdateUser/
  │       ├── UpdateUserCommand.cs
  │       └── UpdateUserCommandHandler.cs
  ```
- `Queries/` - Query handlers for data retrieval
- `DomainEventHandlers/` - Handlers for domain events
- `Common/` - Shared behaviors and interfaces

#### 🔧 Identity.Infrastructure
Implementation details and external concerns:
- `Configurations/` - System configurations
- `Context/` - Database context
- `Data/` - Data access implementation
- `Extensions/` - Infrastructure extensions
- `Migrations/` - Database migrations
- `Repositories/` - Repository implementations
- `Services/` - External service implementations

## 🚀 Key Features

- **CQRS Pattern**: Separate command and query responsibilities
- **DDD Implementation**: Rich domain model with business rules
- **Smart Enums**: Using Enumeration pattern for type-safe enums
- **Domain Events**: Event-driven architecture support
- **Clean Architecture**: Clear separation of concerns
- **Value Objects**: Immutable value objects for domain concepts

## 🛠️ Technical Stack

- .NET 7.0+
- Entity Framework Core
- MediatR for CQRS
- FluentValidation
- AutoMapper

## 📥 Getting Started

1. Clone the repository:
```bash
git clone https://github.com/Pavan8374/cqrs-ddd.git
```

2. Navigate to the project directory:
```bash
cd cqrs-ddd
```

3. Build the solution:
```bash
dotnet build
```

4. Run the application:
```bash
dotnet run --project src/Identity.Api/Identity.Api.csproj
```

## 🌟 Best Practices Implemented

1. **Domain-Driven Design**
   - Rich domain models
   - Encapsulated business rules
   - Value objects for immutable concepts

2. **CQRS Pattern**
   - Separated command and query models
   - Feature-based command/query organization
   - MediatR for command/query handling

3. **Clean Architecture**
   - Clear dependency direction
   - Domain layer independence
   - Separation of concerns

## 🤝 Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

1. Fork the repository
2. Create your feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## 📜 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 👨‍💻 Author

**Pavan**
- GitHub: [@Pavan8374](https://github.com/Pavan8374)

---

⭐️ If you found this implementation helpful, please star this repository! It helps others discover this pattern and implementation.
