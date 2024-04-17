# API Project (Tutorial) Description

This project is being developed using .NET 8.0 with the primary objective of experimenting with and working on various design patterns, customized structures, and other related concepts, all of which are essential for creating robust APIs. The central entity in the project is the `Product`, which is accompanied by other entities that are related to it.

## Features and Tech Stack:

- **Onion Architecture**: Followed the principles of onion architecture, promoting modular and maintainable code.
- **Entity Framework Core**: Utilized for database operations, ensuring efficient data handling.
- **Repository Pattern**: Implemented both [`ReadRepository`](https://github.com/Cenny26/E-Commerce.API/blob/master/src/Infrastructure/ECommerce.Persistence/Repositories/ReadRepository.cs) and [`WriteRepository`](https://github.com/Cenny26/E-Commerce.API/blob/master/src/Infrastructure/ECommerce.Persistence/Repositories/WriteRepository.cs) to support CQRS and Mediator patterns, enhancing data manipulation capabilities.
- **Unit of Work Pattern**: Utilized the unit of work pattern for managing transactions, ensuring data integrity.
- **Redis for Caching**: Employed Redis for caching data, enhancing performance by reducing database loads.
- **JWT Authentication**: Integrated JWT for secure authentication and authorization processes, ensuring API security.
- **Base Structures**: Incorporated base structures such as `BaseHandler`, `BaseException`, and `BaseRule` for consistent and efficient code organization.
- **Custom Exception Handling**: Developed custom exception handlers for improved error management and user experience.
- **Validation Rules**: Defined validation rules for each entity and structure, ensuring data consistency and integrity.

## Contribution

Contributions are welcome! Feel free to open issues or pull requests for any enhancements, bug fixes, or suggestions.
