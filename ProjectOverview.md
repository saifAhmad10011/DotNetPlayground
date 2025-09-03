# DotNetPlayground Project Overview

This document explains the flow and structure of your DotNetPlayground solution, focusing on authentication and JWT usage.

## 1. Solution Structure
- **DotNetPlayground/playground/**: Main ASP.NET Core Web API project
- **DotNetPlayground/TokenDemo/**: Console app for generating JWT tokens
- **DotNetPlayground/playground/Services/**: Contains service classes (AuthTestService, JwtTokenGenerator, etc.)
- **DotNetPlayground/playground/Controllers/**: Contains API controllers (AuthTestController, etc.)
- **DotNetPlayground/playground/Requests/**: Contains REST Client `.http` files for API testing

## 2. JWT Token Generation (TokenDemo)
- Run `TokenDemo` to generate a JWT token for a user and role (e.g., 'testuser', 'Admin').
- The token is signed using a symmetric key (must match the API's key).
- Output: JWT token string for use in API requests.

## 3. Web API Startup (playground)
- The API is started with `dotnet run --project playground.csproj`.
- In `Program.cs`, services and authentication are configured:
  - Controllers and Swagger are added.
  - `IAuthTestService` and its implementation are registered.
  - JWT authentication is set up with the same signing key as TokenDemo.
  - Authorization is enabled.

## 4. AuthTestService & Controller
- **AuthTestService**: Provides three methods for different endpoint types:
  - `GetPublicMessage()`: No authentication required.
  - `GetProtectedMessage()`: Requires authentication.
  - `GetAdminMessage()`: Requires 'Admin' role.
- **AuthTestController**: Exposes three endpoints:
  - `/api/AuthTest/public`: Public, no token needed.
  - `/api/AuthTest/protected`: Requires valid JWT token.
  - `/api/AuthTest/admin`: Requires JWT token with 'Admin' role.

## 5. Testing Endpoints
- Use the VS Code REST Client (`authtest-jwt.http`) to send requests:
  - Public endpoint: No Authorization header needed.
  - Protected/Admin endpoints: Add `Authorization: Bearer <your-jwt-token>` header.
- The API validates the token and role before returning a response.

## 6. Common Issues & Solutions
- **401 Unauthorized**: Token missing, expired, or key mismatch.
- **Invalid Token Signature**: Ensure both TokenDemo and API use the same signing key.
- **No 'Send Request' Link**: Install VS Code REST Client extension.

## 7. Step-by-Step Flow
1. Start the API (`dotnet run --project playground.csproj`).
2. Generate a JWT token using TokenDemo.
3. Use the token in REST Client requests to test protected/admin endpoints.
4. API validates the token and returns the appropriate message.

---

This document summarizes the authentication flow and usage in DotNetPlayground project.
