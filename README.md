
# 🏪 Retail Store Management API

A .NET 8 + MSSQL RESTful Web API for managing a simple retail store system including Products, Customers, and Purchases.

## 🚀 Features

- Create, Read, Update, Delete (CRUD) for:
  - Products
  - Customers
  - Purchases
- Relational model with `PurchaseItems` between `Purchases` and `Products`
- Auto-generated Swagger UI
- Dockerized with SQL Server 2022
- Repository + Service Layers using Dependency Injection
- AutoMapper & DTOs
- Unit tests with xUnit + Moq
- Postman collection for testing endpoints

## 🧱 Tech Stack

- .NET 8
- Entity Framework Core
- SQL Server 2022
- Docker
- AutoMapper
- Swagger (Swashbuckle)
- xUnit + Moq

## 📦 Setup Instructions

### Prerequisites

- Docker Desktop
- .NET 8 SDK

### Run with Docker

```bash
docker-compose up --build
```

- API: [http://localhost:5000/swagger](http://localhost:5000/swagger)
- SQL Server: localhost:1433 (User: `sa`, Password: `Your_password123`)

### Run Tests

```bash
dotnet test
```

## 📬 API Endpoints (Swagger)

### 🔹 Customers

- `GET /api/Customer`
- `GET /api/Customer/{id}`
- `POST /api/Customer`
- `PUT /api/Customer/{id}`
- `DELETE /api/Customer/{id}`

### 🔹 Products

- `GET /api/Product`
- `GET /api/Product/{id}`
- `POST /api/Product`
- `PUT /api/Product/{id}`
- `DELETE /api/Product/{id}`

### 🔹 Purchases

- `GET /api/Purchase`
- `POST /api/Purchase`

## 📁 Postman Collection

The Postman collection is available in the `postman` folder:
```
postman/
└── RetailStoreManagement.postman_collection.json
```


