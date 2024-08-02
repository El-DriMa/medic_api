## MedicLab API
Welcome to the MedicLab API repository. This project provides the backend service for the MedicLab web application, built with .NET Core and hosted on Azure. The API supports various operations to manage users and their access within the system.

## Overview
The MedicLab API offers endpoints for user authentication, user management, and administrative tasks. The API documentation is available on Swagger Hub.

## Features
### Authentication:
- /api/login: Authenticates admin users.
- /api/logout: Logs out admin users.
### User Management:
- /api/users: Fetches a list of all users.
- /api/users/details/{id}: Retrieves details of a specific user.
- /apis/users/block/{id}: Blocks a user by ID.
- /api/register: Registers or adds a new user.
- /api/users/update : Updates user info.

## Access Documentation:
The API documentation is available at Swagger Hub.
- https://app.swaggerhub.com/apis-docs/AHODZIC649_1/medic_api/1.0

# Deployment
Hosting: The API and database are hosted on Azure.
