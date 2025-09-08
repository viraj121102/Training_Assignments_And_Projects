using BookstoreApp.Models;
using System.Data;

namespace BookstoreApp.Data
{
    public interface IBookRepository
    {
        // Connected Architecture - Using SqlDataReader
        Task<List<Book>> GetAllBooksAsync();
        Task<Book?> GetBookByIdAsync(int id);

        // Disconnected Architecture - Using DataSet and DataTable
        DataSet GetBooksAsDataSet();
        DataTable GetBooksAsDataTable();

        // CRUD Operations with Stored Procedures
        Task<bool> AddBookAsync(Book book);
        Task<bool> UpdateBookAsync(Book book);
        Task<bool> DeleteBookAsync(int id);

        // Parameterized queries for SQL injection prevention
        Task<List<Book>> SearchBooksAsync(string searchTerm);

        // Dataset operations
        Task<bool> UpdateBooksFromDataSetAsync(DataSet dataSet);
    }
}
