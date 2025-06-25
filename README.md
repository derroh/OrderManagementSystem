
# Order Management System (.NET 8 Web API)

A .NET 8 Web API project simulating an order management system with:

- Customer segment–based discounting
- Order status tracking with controlled state transitions
- Order analytics endpoint (average order value and fulfillment time)

---

## Features

### 1. Discount System
- Uses the **Strategy pattern** to apply different discount rules based on the customer segment.
- Example:
  - `VIP` customers get 10% off
  - `Regular` customers pay full price

### 2. Order Status Tracking
- Supports controlled transitions through `Pending → Processing → Shipped → Delivered`.
- Transitions are validated using a dictionary-based map.
- Endpoint: `PUT /orders/{id}/status`

### 3. Order Analytics
- Provides aggregate insights like:
  - **Average order value**
  - **Average fulfillment time** (DeliveredAt - CreatedAt)
- Endpoint: `GET /orders/analytics`

---

## Project Structure
```
/Controllers         → Web API endpoints
/Models              → Domain models and DTOs
/Services            → Discount strategies & helpers
/Data                → EF Core DbContext and repository
```

---

## Technologies Used
- .NET 8
- ASP.NET Core Web API
- Entity Framework Core (InMemory)
- Swagger/OpenAPI for documentation

---

## Testing (Recommended)
Unit and integration test setup is suggested using xUnit and WebApplicationFactory.

---

## Assumptions
- Customers are categorized as either `Regular` or `VIP`
- Orders start in `Pending` state and follow linear transitions
- Fulfillment time is calculated only for orders marked as `Delivered`
- No authentication or external integrations are assumed

---

## Running the API
```bash
# Restore and run
> dotnet restore
> dotnet run
```
Navigate to `https://localhost:{port}/swagger` for API testing.

---

