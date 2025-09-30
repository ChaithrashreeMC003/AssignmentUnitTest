# Survey System

A **Survey System** built with **ASP.NET Core Web API** and **Entity Framework Core**.
This project demonstrates clean architecture principles, authentication & authorization, logging, and best practices for scalable web APIs.

---

✨ **Features**

* ✅ User Authentication with **JWT**
* ✅ Secure Password Hashing with **BCrypt**
* ✅ Role-based Authorization (**Admin & User**)
* ✅ Full CRUD for **Surveys**
* ✅ Full CRUD for **Questions & Options**
* ✅ Multiple Question Types: **Checkbox, Radio, Rating, Text**
* ✅ Users can **submit survey responses**
* ✅ API **Versioning** support
* ✅ **Global Exception Handling**
* ✅ **Serilog Logging**
* ✅ **Custom Logging**
* ✅ **Swagger/OpenAPI Documentation**

---

🛠️ **Tech Stack**

* **ASP.NET Core 7/8** (Web API)
* **Entity Framework Core 7/8** (Database ORM)
* **SQL Server** (Database)
* **ASP.NET Core Identity** (User & Role Management)
* **JWT Bearer Authentication**
* **BCrypt.Net** (Password Hashing)
* **AutoMapper** (DTO ↔ Entity mapping)
* **Serilog** (Logging)
* **Custom Logging**
* **Swagger / Swashbuckle** (API Documentation)

---

📦 **Dependencies**

This project uses the following **NuGet packages**:

* `AutoMapper` + `AutoMapper.Extensions.Microsoft.DependencyInjection` → DTO to Entity mapping
* `BCrypt.Net-Next` → Password hashing for user authentication
* `Microsoft.AspNetCore.Authentication.JwtBearer` → JWT-based authentication
* `Microsoft.AspNetCore.Identity.EntityFrameworkCore` → Identity with EF Core (users, roles, claims)
* `Microsoft.EntityFrameworkCore`, `Design`, `SqlServer`, `Tools` → EF Core with SQL Server support and migrations
* `Microsoft.Extensions.Configuration.*` → Strongly-typed config using *appsettings.json*
* `Microsoft.AspNetCore.JsonPatch` → Support for PATCH endpoints
* `Microsoft.IdentityModel.Tokens` → Token signing and validation

---

🚀 **Getting Started**

### 📌 Prerequisites

Make sure you have installed:

* **.NET 7/8 SDK**
* **SQL Server**
* **Git**

### 📥 Clone the Repository

```bash
git clone https://github.com/<your-username>/SurveySystem.git
cd SurveySystem
```

### ⚙️ Setup

1. Update **appsettings.json** with your SQL Server connection string.
2. Run database migrations:

   ```bash
   dotnet ef database update
   ```
3. Build and run the project:

   ```bash
   dotnet run
   ```

### 🌐 API Documentation

Once the project is running, open [http://localhost:5000/swagger](http://localhost:5000/swagger) to view the Swagger UI and explore API endpoints.

---

🔑 **Authentication & Authorization**

* Uses **JWT Bearer Authentication** for securing endpoints.
* Users have roles: **Admin** and **User**.
* Admins can manage surveys, questions, and options.
* Users can participate in surveys and submit responses.

---

📝 **Project Structure (Clean Architecture)**

```
SurveySystem/
│── Application/        # Business logic, DTOs, services, interfaces
│── Domain/             # Core entities and enums
│── Infrastructure/     # EF Core DbContext, repositories, migrations
│── WebAPI/             # API controllers, middlewares, logging, startup
│── Tests/              # Unit & Integration tests
```

---

📊 **Logging**

* Integrated with **Serilog** for structured logging.
* Custom logging middleware for additional request/response tracking.

---

🛡️ **Global Exception Handling**

* Centralized middleware for catching and formatting exceptions.
* Consistent error responses across the API.

---

📖 **API Versioning**

* Supports multiple API versions using `Microsoft.AspNetCore.Mvc.Versioning`.

---

📜 **License**

This project is licensed under the MIT License.
You are free to use, modify, and distribute it for personal or commercial use.

---
