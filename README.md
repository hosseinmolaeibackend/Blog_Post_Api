# 📝 BlogPost API - Interview Task

This project is a **simple RESTful API for a blog application**, implemented using **ASP.NET Core** and **Entity Framework Core**. It was built as part of a **technical interview task** to demonstrate familiarity with modern .NET development practices, including:

- Clean API design
- CRUD operations
- Model validation
- Error handling
- Logging
- Unit testing

---

## 🚀 Features

- **Create a new blog post**
- **Retrieve all blog posts** (with optional pagination)
- **Retrieve a blog post by ID**
- **Update a blog post**
- **Delete a blog post**
- **Basic error handling**
- **Structured logging to file**
- **In-memory database for simplicity**

---

## 📦 Tech Stack

- [.NET 8](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- ASP.NET Core Web API
- Entity Framework Core (In-Memory Provider)
- Serilog (File logging)
- xUnit (Unit testing)

---

## 📬 API Endpoints

| Method | Route               | Description                |
|--------|---------------------|----------------------------|
| POST   | `/api/posts`        | Create a new post          |
| GET    | `/api/posts`        | Get all posts (paginated)  |
| GET    | `/api/posts/{id}`   | Get a specific post        |
| PUT    | `/api/posts/{id}`   | Update a post              |
| DELETE | `/api/posts/{id}`   | Delete a post              |

### 📄 Sample Request (POST)

```json
POST /api/posts
Content-Type: application/json

{
  "title": "First Post",
  "content": "This is a test blog post.",
  "author": "Jane Doe"
}
