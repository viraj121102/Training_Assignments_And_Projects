-- Bookstore Application Database Setup Script
-- Run this script to create the database, tables, and stored procedures

-- Create Database (uncomment if needed)
-- CREATE DATABASE BookstoreDB;
-- GO
-- USE BookstoreDB;
-- GO

-- Create Books table
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Books' AND xtype='U')
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
);
GO

-- Insert sample data
IF NOT EXISTS (SELECT * FROM Books)
BEGIN
    INSERT INTO Books (Title, Author, Description, Price, Category, Stock) VALUES
    ('The Great Gatsby', 'F. Scott Fitzgerald', 'A classic American novel set in the Jazz Age', 12.99, 'Fiction', 25),
    ('To Kill a Mockingbird', 'Harper Lee', 'A gripping tale of racial injustice and childhood innocence', 14.50, 'Fiction', 30),
    ('1984', 'George Orwell', 'A dystopian social science fiction novel', 13.25, 'Science Fiction', 20),
    ('Clean Code', 'Robert C. Martin', 'A handbook of agile software craftsmanship', 45.00, 'Technology', 15),
    ('The Lean Startup', 'Eric Ries', 'How constant innovation creates radically successful businesses', 16.99, 'Business', 18);
END
GO

-- Stored Procedure: Add Book
CREATE OR ALTER PROCEDURE sp_AddBook
    @Title NVARCHAR(200),
    @Author NVARCHAR(100),
    @Description NVARCHAR(1000) = NULL,
    @Price DECIMAL(10,2),
    @Category NVARCHAR(50),
    @Stock INT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        INSERT INTO Books (Title, Author, Description, Price, Category, Stock)
        VALUES (@Title, @Author, @Description, @Price, @Category, @Stock);

        SELECT SCOPE_IDENTITY() AS NewBookId;
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END
GO

-- Stored Procedure: Update Book
CREATE OR ALTER PROCEDURE sp_UpdateBook
    @Id INT,
    @Title NVARCHAR(200),
    @Author NVARCHAR(100),
    @Description NVARCHAR(1000) = NULL,
    @Price DECIMAL(10,2),
    @Category NVARCHAR(50),
    @Stock INT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        UPDATE Books 
        SET 
            Title = @Title,
            Author = @Author,
            Description = @Description,
            Price = @Price,
            Category = @Category,
            Stock = @Stock,
            UpdatedDate = GETDATE()
        WHERE Id = @Id;

        SELECT @@ROWCOUNT as RowsAffected;
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END
GO

-- Stored Procedure: Delete Book
CREATE OR ALTER PROCEDURE sp_DeleteBook
    @Id INT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        DELETE FROM Books WHERE Id = @Id;
        SELECT @@ROWCOUNT as RowsAffected;
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END
GO

-- Stored Procedure: Get Book by ID
CREATE OR ALTER PROCEDURE sp_GetBookById
    @Id INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT Id, Title, Author, Description, Price, Category, Stock, CreatedDate, UpdatedDate
    FROM Books 
    WHERE Id = @Id;
END
GO

-- Stored Procedure: Get All Books
CREATE OR ALTER PROCEDURE sp_GetAllBooks
AS
BEGIN
    SET NOCOUNT ON;

    SELECT Id, Title, Author, Description, Price, Category, Stock, CreatedDate, UpdatedDate
    FROM Books 
    ORDER BY Title;
END
GO

-- Stored Procedure: Search Books
CREATE OR ALTER PROCEDURE sp_SearchBooks
    @SearchTerm NVARCHAR(200)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT Id, Title, Author, Description, Price, Category, Stock, CreatedDate, UpdatedDate
    FROM Books 
    WHERE Title LIKE '%' + @SearchTerm + '%' 
       OR Author LIKE '%' + @SearchTerm + '%' 
       OR Category LIKE '%' + @SearchTerm + '%'
    ORDER BY Title;
END
GO

PRINT 'Database setup completed successfully!'
PRINT 'Tables created: Books'
PRINT 'Stored procedures created: sp_AddBook, sp_UpdateBook, sp_DeleteBook, sp_GetBookById, sp_GetAllBooks, sp_SearchBooks'
PRINT 'Sample data inserted into Books table'
