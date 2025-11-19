# ASP.NET Core Authentication Demo

Tutorial that shows how to implement an Bearer Authentication with JWT token.

## Repo Structure

The repo provides multiple branches:

- `00-new-project`
  - Contains a new web project. No authentication.
- `01-authentication-with-jwt`
  - JWT Authentication is added. New endpoint, token generation and its validation.
- `02-add-use-cases`
  - Further improve the architecture by creating separate components for presentation, use cases and token management logic.
  - Note: For a small project like this demo, this separation is an overengineering, but consider using this separation in real projects.

### Suggestion

Compare branches between them to easier see what code was added/changed.
