# 📦 Project Name: GameStore And Score Api

Brief description of the API.  
Example: *REST API developed in .NET 8 for user management and authentication.*

---

## 🚀 Technologies

- .NET 8
- ASP.NET Core Web API
- Entity Framework Core (optional)
- SQL Server / PostgreSQL / SQLite (In process)
- Swagger 
- JWT Authentication (in working)

---

## 📂 Project Structure

```bash
src/
│
├── Api/
│   ├── Controllers/
│   ├── Filters/
│   ├── Models/
│   ├── Repositories/
│   └── Program.cs
│
├── Application/
│   ├── DTOs/
│   └── Services/
│
├── Domain/
│   ├── Entities/
│   └── Exceptions/
│
└──Infrastructure/
    ├── Persintence/
    └── Repositories/

```

---

## ⚙️ Configuration

### Prerequisites

- .NET SDK 8.0 or higher
- Visual Studio 2022 or VS Code
- Configured database (in process)

---

### Environment Variables

Example configuration in `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=MyDb;Trusted_Connection=True;"
  },
  "Jwt": {
    "Key": "SECRET_KEY",
    "Issuer": "MyApi",
    "Audience": "MyApiUsers"
  }
}
```

---

## ▶️ Running the Project

### From the command line

```bash
dotnet restore
dotnet build
dotnet run
```

The API will be available at:

```
https://localhost:7282
http://localhost:7282
```

---

## 📖 API Documentation (Swagger)

Swagger is enabled by default.

```
https://localhost:7282/swagger/index.html
```

From there you can:
- View available endpoints
- Test requests
- Review request and response models

---

## 🔐 Authentication (if applicable)

The API uses **JWT Bearer Token** authentication.

### Basic flow:
1. Login → receive token
2. Send token in request headers:

```
Authorization: Bearer {token}
```

---

## 📌 Main Endpoints

Example:

| Method | Endpoint        | Description        |
|--------|-----------------|--------------------|
| GET    | /api/User/{id}  | Get user by Id     |
| POST   | /api/user       | Create a user      |
| PATCH  | /api/user/{id}  | update user        |

---

## 🧪 Testing

Run unit tests:

```bash
dotnet test
```

---

## 📦 Publishing

```bash
dotnet publish -c Release
```

The output will be generated at:

```
bin/Release/net8.0/publish
```

---

## 🛠 Best Practices

- Use DTOs for input/output
- Global error handling
- Validation with DataAnnotations or FluentValidation
- Layered architecture

---

## 📄 License

This project is licensed under the **MIT License** (or applicable license).

---

## ✍️ Author

- Name : Jaime Rios
- Email : jaimearios1986@gmail.com
- GitHub : https://github.com/JaimeRios 
- LinkedIn: https://www.linkedin.com/in/jaime-alberto-rios-palacio/
