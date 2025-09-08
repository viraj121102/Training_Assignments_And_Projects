# Bookstore Application - ASP.NET Core MVC with ADO.NET

This is a comprehensive bookstore management application built with ASP.NET Core 8.0 MVC, demonstrating all aspects of ADO.NET as required by the assignment.

## 🎯 Assignment Requirements Implemented

### ✅ User Story 1: Database Connectivity and Basic CRUD Operations
- **SqlConnection** for database connectivity
- **SqlCommand** for executing SQL statements  
- **SqlDataReader** for reading data (connected architecture)
- Complete CRUD operations: Create, Read, Update, Delete books

### ✅ User Story 2: SQL Injection Prevention
- **Parameterized queries** used throughout the application
- Input validation and sanitization
- Demonstrates secure vs insecure query practices

### ✅ User Story 3: Stored Procedures Implementation
- Stored procedures for all CRUD operations
- Proper parameter handling
- Exception handling for stored procedure calls

### ✅ User Story 4: DataSet and DataTable Usage
- **DataSet** operations for disconnected architecture
- **DataTable** manipulation and updates
- **SqlDataAdapter** for DataSet operations

### ✅ User Story 5: SqlDataReader and SqlDataAdapter
- **SqlDataReader** for efficient forward-only data access
- **SqlDataAdapter** for disconnected data operations
- Performance comparison between connected and disconnected approaches

## 🏗️ Architecture & Design

### Project Structure
```
BookstoreApp/
├── Controllers/           # MVC Controllers
├── Models/               # Data models
├── Views/                # Razor views
├── Data/                 # Data access layer
├── wwwroot/              # Static files
└── Database/             # SQL scripts
```

### Key Components

**Data Access Layer (`Data/`)**
- `IBookRepository` - Interface defining data operations
- `BookRepository` - Implementation using pure ADO.NET

**Models (`Models/`)**
- `Book` - Main entity with validation attributes
- `ErrorViewModel` - Error handling model

**Controllers (`Controllers/`)**
- `HomeController` - Main application pages
- `BooksController` - Book management operations

## 🔧 Setup Instructions

### Prerequisites
- Visual Studio 2022
- .NET 8.0 SDK
- SQL Server or SQL Server Express

### Database Setup
1. Create a database named `BookstoreDB`
2. Run the SQL scripts to create tables and stored procedures
3. Update connection string in `appsettings.json`

### Running the Application
1. Open the solution in Visual Studio 2022
2. Update the connection string if needed
3. Build and run the application
4. The application will be available at `https://localhost:5001`

## 📊 Database Schema

### Books Table
```sql
CREATE TABLE Books (
    Id int IDENTITY(1,1) PRIMARY KEY,
    Title nvarchar(200) NOT NULL,
    Author nvarchar(100) NOT NULL,
    Description nvarchar(1000) NULL,
    Price decimal(10,2) NOT NULL,
    Category nvarchar(50) NOT NULL,
    Stock int NOT NULL DEFAULT 0,
    CreatedDate datetime2 NOT NULL DEFAULT GETDATE(),
    UpdatedDate datetime2 NULL
)
```

### Stored Procedures
- `sp_AddBook` - Insert new book
- `sp_UpdateBook` - Update existing book  
- `sp_DeleteBook` - Delete book by ID
- `sp_GetBookById` - Get single book
- `sp_GetAllBooks` - Get all books

## 🚀 Features

### Core Functionality
- ✅ Add, edit, view, delete books
- ✅ Search books with SQL injection protection
- ✅ Responsive design with Bootstrap 5
- ✅ Form validation and error handling

### ADO.NET Demonstrations
- ✅ Connected architecture examples
- ✅ Disconnected architecture examples  
- ✅ DataSet vs DataTable comparisons
- ✅ Performance considerations
- ✅ Security best practices

### User Interface
- Clean, modern Bootstrap design
- Responsive layout for mobile devices
- Success/error message notifications
- Search functionality
- Data demonstration links

## 🔒 Security Features

- **Parameterized Queries**: All database queries use parameters
- **Input Validation**: Server-side and client-side validation
- **Error Handling**: Proper exception handling and logging
- **SQL Injection Protection**: Demonstrated and implemented

## 📚 Learning Outcomes

This project demonstrates:
1. **ADO.NET Fundamentals**: Connection, Command, DataReader
2. **Architecture Patterns**: Connected vs Disconnected
3. **Security Practices**: SQL injection prevention
4. **Error Handling**: Try-catch blocks and logging
5. **Best Practices**: Repository pattern, dependency injection
6. **Modern Web Development**: ASP.NET Core MVC, Bootstrap

## 🛠️ Technologies Used

- **Backend**: ASP.NET Core 8.0 MVC
- **Data Access**: ADO.NET (System.Data.SqlClient)
- **Database**: SQL Server / SQL Server Express
- **Frontend**: Bootstrap 5, jQuery
- **Validation**: Data Annotations, jQuery Validation
- **IDE**: Visual Studio 2022

## 📖 Additional Resources

- [ADO.NET Documentation](https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/)
- [ASP.NET Core MVC](https://docs.microsoft.com/en-us/aspnet/core/mvc/)
- [SQL Server Documentation](https://docs.microsoft.com/en-us/sql/sql-server/)

## 👨‍💻 Developer Notes

This application was built specifically to fulfill the Wipro NGA .NET Cohort assignment requirements while following modern development practices and security standards.
