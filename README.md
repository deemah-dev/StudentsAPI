# Student Management API 🎓

A robust **ASP.NET Core Web API** built as a learning project to demonstrate the transition from a traditional
**N-Tier architecture** to a more modern, testable, and decoupled design.

---

## 🚀 Architecture Overview

The project follows the **N-Tier Architecture** pattern with a strong focus on **Separation of Concerns (SoC)**:

- **StudentAPI (Presentation Layer)**  
  ASP.NET Core Web API controllers.

- **StudentAPI.BLL (Business Logic Layer)**  
  Contains services and business rules.

- **StudentAPI.DAL (Data Access Layer)**  
  Handles data persistence and repository patterns.

- **StudentAPI.Shared**  
  DTOs shared across all layers.

- **StudentAPI.Tests**  
  Unit tests using **xUnit** and **Moq**.

---

## ✨ Key Features & Concepts Applied

- **Dependency Injection (DI)**  
  Fully decoupled layers using interfaces to ensure high maintainability.

- **Repository Pattern**  
  Abstracted data access to make the system database-agnostic.

- **Unit Testing**  
  Comprehensive test suite for Business Logic using **xUnit** and **Moq**, ensuring reliability without database dependency.

- **DTO Pattern**  
  Data Transfer Objects are used to separate internal database entities from API responses.

- **Clean Code Practices**  
  Refactored from static classes to instance-based services to support modern software engineering standards.

---

## 🛠️ Tech Stack

- **Framework:** .NET 8 / ASP.NET Core  
- **Language:** C#  
- **API Documentation:** Swagger 
- **Testing:** xUnit, Moq  
- **Database:** Mocked / SQL Server 

---

## 📈 Future Roadmap (Clean Architecture Journey)

-  Implement AutoMapper for DTO mapping
-  Migrate to Clean Architecture (Domain-Centric)
-  Add FluentValidation for request validation
-  Implement CQRS with MediatR

## 📌 Notes
This project is intended as a learning and demonstration project, focusing on clean architecture principles, testability, and maintainable code design.

