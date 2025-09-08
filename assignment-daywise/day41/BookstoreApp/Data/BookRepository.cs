using BookstoreApp.Models;
using System.Data;
using System.Data.SqlClient;

namespace BookstoreApp.Data
{
    public class BookRepository : IBookRepository
    {
        private readonly string _connectionString;

        public BookRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection") 
                ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        }

        // Connected Architecture - Using SqlDataReader
        public async Task<List<Book>> GetAllBooksAsync()
        {
            var books = new List<Book>();

            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand("SELECT * FROM Books ORDER BY Title", connection);

            await connection.OpenAsync();
            using var reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                books.Add(MapReaderToBook(reader));
            }

            return books;
        }

        public async Task<Book?> GetBookByIdAsync(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand("SELECT * FROM Books WHERE Id = @Id", connection);

            command.Parameters.AddWithValue("@Id", id);

            await connection.OpenAsync();
            using var reader = await command.ExecuteReaderAsync();

            if (await reader.ReadAsync())
            {
                return MapReaderToBook(reader);
            }

            return null;
        }

        // Disconnected Architecture - Using DataSet
        public DataSet GetBooksAsDataSet()
        {
            using var connection = new SqlConnection(_connectionString);
            using var adapter = new SqlDataAdapter("SELECT * FROM Books", connection);

            var dataSet = new DataSet();
            adapter.Fill(dataSet, "Books");

            return dataSet;
        }

        // Disconnected Architecture - Using DataTable
        public DataTable GetBooksAsDataTable()
        {
            using var connection = new SqlConnection(_connectionString);
            using var adapter = new SqlDataAdapter("SELECT * FROM Books", connection);

            var dataTable = new DataTable();
            adapter.Fill(dataTable);

            return dataTable;
        }

        // CRUD Operations with Stored Procedures
        public async Task<bool> AddBookAsync(Book book)
        {
            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand("sp_AddBook", connection);

            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Title", book.Title);
            command.Parameters.AddWithValue("@Author", book.Author);
            command.Parameters.AddWithValue("@Description", book.Description ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Price", book.Price);
            command.Parameters.AddWithValue("@Category", book.Category);
            command.Parameters.AddWithValue("@Stock", book.Stock);

            await connection.OpenAsync();
            var result = await command.ExecuteNonQueryAsync();

            return result > 0;
        }

        public async Task<bool> UpdateBookAsync(Book book)
        {
            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand("sp_UpdateBook", connection);

            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id", book.Id);
            command.Parameters.AddWithValue("@Title", book.Title);
            command.Parameters.AddWithValue("@Author", book.Author);
            command.Parameters.AddWithValue("@Description", book.Description ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Price", book.Price);
            command.Parameters.AddWithValue("@Category", book.Category);
            command.Parameters.AddWithValue("@Stock", book.Stock);

            await connection.OpenAsync();
            var result = await command.ExecuteNonQueryAsync();

            return result > 0;
        }

        public async Task<bool> DeleteBookAsync(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand("sp_DeleteBook", connection);

            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id", id);

            await connection.OpenAsync();
            var result = await command.ExecuteNonQueryAsync();

            return result > 0;
        }

        // Parameterized queries for SQL injection prevention
        public async Task<List<Book>> SearchBooksAsync(string searchTerm)
        {
            var books = new List<Book>();

            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand(
                "SELECT * FROM Books WHERE Title LIKE @SearchTerm OR Author LIKE @SearchTerm OR Category LIKE @SearchTerm", 
                connection);

            // Using parameterized query to prevent SQL injection
            command.Parameters.AddWithValue("@SearchTerm", $"%{searchTerm}%");

            await connection.OpenAsync();
            using var reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                books.Add(MapReaderToBook(reader));
            }

            return books;
        }

        // DataSet operations
        public async Task<bool> UpdateBooksFromDataSetAsync(DataSet dataSet)
        {
            try
            {
                using var connection = new SqlConnection(_connectionString);
                using var adapter = new SqlDataAdapter("SELECT * FROM Books", connection);

                // Configure the adapter for updates
                var commandBuilder = new SqlCommandBuilder(adapter);
                adapter.UpdateCommand = commandBuilder.GetUpdateCommand();
                adapter.InsertCommand = commandBuilder.GetInsertCommand();
                adapter.DeleteCommand = commandBuilder.GetDeleteCommand();

                await connection.OpenAsync();
                var result = adapter.Update(dataSet, "Books");

                return result >= 0;
            }
            catch
            {
                return false;
            }
        }

        private Book MapReaderToBook(SqlDataReader reader)
        {
            return new Book
            {
                Id = reader.GetInt32("Id"),
                Title = reader.GetString("Title"),
                Author = reader.GetString("Author"),
                Description = reader.IsDBNull("Description") ? null : reader.GetString("Description"),
                Price = reader.GetDecimal("Price"),
                Category = reader.GetString("Category"),
                Stock = reader.GetInt32("Stock"),
                CreatedDate = reader.GetDateTime("CreatedDate"),
                UpdatedDate = reader.IsDBNull("UpdatedDate") ? null : reader.GetDateTime("UpdatedDate")
            };
        }
    }
}
