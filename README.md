# User Management API

## Overview

The User Management API is an ASP.NET Core Web API developed for TechHive Solutions to support internal HR and IT operations. The API provides secure and reliable user management capabilities through a RESTful interface that supports Create, Read, Update, and Delete (CRUD) operations.

The project was developed with assistance from Microsoft Copilot to accelerate development, improve code quality, enhance reliability, and implement middleware-based security and monitoring.

## Features

### User Management
- Retrieve all users
- Retrieve a user by ID
- Create new users
- Update existing users
- Delete users

### Data Validation
- Required field validation
- Email format validation
- String length validation
- Duplicate email prevention

### Error Handling
- Consistent HTTP status codes
- Standardized JSON error responses
- Graceful handling of missing records
- Centralized exception management

### Security
- Token-based authentication
- Authorization header validation
- Unauthorized request protection

### Monitoring and Auditing
- Request logging
- Response logging
- Status code tracking
- Audit-friendly request tracing

---

## Technology Stack

- ASP.NET Core Web API
- C#
- Swagger / OpenAPI
- Microsoft Copilot
- Git & GitHub

---

## API Endpoints

| Method | Endpoint | Description |
|----------|----------|----------|
| GET | `/api/users` | Retrieve all users |
| GET | `/api/users/{id}` | Retrieve a specific user |
| POST | `/api/users` | Create a new user |
| PUT | `/api/users/{id}` | Update an existing user |
| DELETE | `/api/users/{id}` | Delete a user |

---

## Authentication

Protected endpoints require an Authorization header.

Example:

```http
Authorization: Bearer TechHiveSecureToken123
```

Requests with missing or invalid tokens receive:

```http
401 Unauthorized
```

---

## Middleware Pipeline

The application uses custom middleware configured in the following order:

1. Error Handling Middleware
2. Authentication Middleware
3. Logging Middleware

This configuration ensures that:

- Exceptions are handled consistently.
- Requests are authenticated before processing.
- All activity is logged for auditing purposes.

---

## Error Response Example

```json
{
  "error": "Internal server error."
}
```

---

## Testing

The API has been tested using Swagger and HTTP request files covering:

- Successful CRUD operations
- Invalid user input
- Invalid email addresses
- Duplicate email creation
- Missing required fields
- Unauthorized requests
- Missing records
- Exception handling scenarios

---

# Change Log

## Activity 1 – Initial API Development

### Implemented
- ASP.NET Core Web API project setup
- Swagger/OpenAPI integration
- User model creation
- CRUD endpoints for user management
- RESTful routing conventions
- Appropriate HTTP response codes

### Copilot Contributions
- Generated project scaffolding
- Assisted with model creation
- Generated CRUD controller methods
- Recommended API best practices
- Generated testing payloads and examples

### Outcome
A functional User Management API capable of performing basic CRUD operations and testing through Swagger and Postman.

---

## Activity 2 – Debugging and Reliability Enhancements

### Issues Identified
- Missing validation on user input
- Invalid email acceptance
- Empty values accepted for required fields
- Duplicate email creation
- Limited handling of non-existent resources
- Potential for unhandled exceptions

### Enhancements Implemented
- Added Data Annotation validation attributes
- Added duplicate email checks
- Improved HTTP 404 responses
- Added error handling logic
- Improved API response consistency

### Copilot Contributions
- Identified validation gaps
- Suggested model validation attributes
- Generated exception handling code
- Recommended edge-case testing scenarios
- Improved endpoint reliability

### Outcome
A more robust API with improved data integrity, reliability, and error handling.

---

## Activity 3 – Middleware Integration and Security

### Implemented Middleware

#### Logging Middleware
Captures:
- HTTP method
- Request path
- Response status code

#### Error Handling Middleware
Provides:
- Centralized exception handling
- Consistent JSON error responses
- Improved application stability

#### Authentication Middleware
Provides:
- Token validation
- Unauthorized request blocking
- Protected API endpoints

### Copilot Contributions
- Generated middleware templates
- Suggested logging implementation patterns
- Assisted with authentication logic
- Generated centralized error handling
- Recommended middleware pipeline ordering

### Outcome
The API now includes centralized logging, standardized error handling, and token-based authentication, improving maintainability, observability, reliability, and security.

---

## Microsoft Copilot Contribution Summary

Throughout the project lifecycle, Microsoft Copilot assisted with:

- Project scaffolding
- Model generation
- CRUD endpoint development
- Validation implementation
- Error handling improvements
- Middleware development
- Authentication logic
- Testing scenarios
- Code quality recommendations
- Debugging support

This collaboration accelerated development while helping ensure adherence to ASP.NET Core and REST API best practices.