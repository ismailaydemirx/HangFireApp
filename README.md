## Hangfire Integration (Background Jobs for .NET)

**Hangfire** is a powerful library that allows you to perform background processing in .NET applications — no Windows Service or separate process required.

---

### ✅ Features

* Fire-and-Forget, Delayed, Recurring, and Continuation jobs
* Persistent storage (SQL Server, Redis, etc.)
* Dashboard UI to monitor jobs
* Retry mechanism with error handling
* Support for dependency injection & scoped services
* Scalable architecture with custom queues and multiple workers

---

### 🚀 Quick Setup

1. **Install via NuGet**

   ```bash
   dotnet add package Hangfire
   dotnet add package Hangfire.SqlServer
   ```

2. **Configure in `Program.cs`**

   ```csharp
   builder.Services.AddHangfire(x => x.UseSqlServerStorage("your_connection_string"));
   builder.Services.AddHangfireServer();
   app.UseHangfireDashboard("/hangfire");
   ```

3. **Enqueue a Job**

   ```csharp
   BackgroundJob.Enqueue(() => Console.WriteLine("Hello from background!"));
   ```

---

### 🔐 Securing the Dashboard

Use custom authorization filters:

```csharp
app.UseHangfireDashboard("/hangfire", new DashboardOptions {
    Authorization = new[] { new MyAuthorizationFilter() }
});
```

---

### 🌐 Dashboard URL

Access the dashboard at:

```
http://localhost:5000/hangfire
```

---

### 📦 Storage Support

* SQL Server
* Redis
* PostgreSQL
* MongoDB (via third-party)

---

### 📄 Resources

* [Official Docs](https://www.hangfire.io/)
* [Dashboard Monitoring UI](https://docs.hangfire.io/en/latest/tools/dashboard.html)

---
