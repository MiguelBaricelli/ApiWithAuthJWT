# ApiWithAuthJWT
This project is an API built with JWT authentication and authorization. (Project for study)


Throughout its development, I learned and applied several key concepts, including:  

- How to implement **JWT tokens** for authentication and authorization  
- Creating **hashed and encrypted passwords** for secure storage  
- Validating users with the **database**  
- Implementing **DTOs (Data Transfer Objects)** for cleaner data handling  
- Creating and running **migrations** to manage database structure  
- Generating and validating **JWT tokens** for secure access control
- Best coding practices
- Use of business rules / interfaces

This project was an opportunity to put into practice **security best practices** and **modern API development standards**.  

# 📌 API Documentation

## 🔑 Authentication & Authorization
This API uses **JWT (JSON Web Token)** for authentication and authorization.  
Every request to protected routes must include a valid token in the header:


## ⚙️ Setup & Installation
1. Clone the repository  
   ```bash
   git clone https://github.com/miguelbaricelli/ApiWithAuthJWT.git

 2. Install dependecies
     - dotnet restore


 3. Run database migrations
     - dotnet ef database update


4. Start the project
   - dotnet run


# Project Structure
- Controllers: Hadle API Requests
- DTOs: Data Transfer Objects for request/response
- Models: Database entities
- Migrations: Database schema management
- Services: Business logic and JWT handling
- Enum: Establishes your position
- Data: DataBase Connection

# EndPoints (Swegger)
- POST - /api/auth/register
- POST - /api/auth/login
- GET - /api/User
- (See more on swagger)

GET is necessary put bearer before token code!

#Technologies Used
  - .Net Core / C#
  - Entity Framework Core (migrations & database)
  - JWT (JSON Web Token)
  - Password hashing & encryption

# Possible improvements
  - Refresh tokens
  - Role-based authorization (Admin/User)



