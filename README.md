# InternalBookingApp

An Internal Resource Booking System built with ASP.NET Core MVC, Entity Framework Core, and SQL Server. This application allows users to manage resources and schedule bookings with proper conflict detection logic.

## 🚀 Features

- Full CRUD operations for Resources, Users, and Bookings
- Booking conflict prevention logic
- Clean and responsive UI using Razor Pages
- Entity Framework Core for data access
- SQL Server or SQLite for database storage
- Follows OOP principles and clean architecture
- Extensible service layer for business logic

## 📁 Project Structure

InternalBookingApp/
├── Controllers/
│ ├── BookingsController.cs
│ ├── ResourcesController.cs
│ └── UsersController.cs
├── Models/
│ ├── Booking.cs
│ ├── Resource.cs
│ └── User.cs
├── Data/
│ └── ApplicationDbContext.cs
├── Services/
│ └── BookingService.cs
├── Views/
│ ├── Bookings/
│ ├── Resources/
│ ├── Users/
│ └── Shared/
├── wwwroot/
├── appsettings.json
├── Startup.cs
├── Program.cs
└── README.md

markdown
Copy
Edit

## 🛠️ Getting Started

### Prerequisites

- [.NET 6 SDK](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- Visual Studio 2022 / VS Code

### Setup

1. Clone the repository:
   ```bash
   git clone https://github.com/Katlego-Ram2/InternalBookingApp.git
   cd InternalBookingApp
