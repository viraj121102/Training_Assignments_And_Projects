using Microsoft.AspNetCore.Mvc;
using BookstoreApp.Data;
using BookstoreApp.Models;
using System.Data;

namespace BookstoreApp.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly ILogger<BooksController> _logger;

        public BooksController(IBookRepository bookRepository, ILogger<BooksController> logger)
        {
            _bookRepository = bookRepository;
            _logger = logger;
        }

        // GET: Books
        public async Task<IActionResult> Index()
        {
            try
            {
                var books = await _bookRepository.GetAllBooksAsync();
                return View(books);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving books");
                TempData["Error"] = "Error retrieving books. Please try again.";
                return View(new List<Book>());
            }
        }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            try
            {
                var book = await _bookRepository.GetBookByIdAsync(id.Value);
                if (book == null) return NotFound();

                return View(book);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving book details for ID {BookId}", id);
                TempData["Error"] = "Error retrieving book details. Please try again.";
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Books/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Author,Description,Price,Category,Stock")] Book book)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var success = await _bookRepository.AddBookAsync(book);
                    if (success)
                    {
                        TempData["Success"] = "Book created successfully!";
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        TempData["Error"] = "Error creating book. Please try again.";
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error creating book");
                    TempData["Error"] = "Error creating book. Please try again.";
                }
            }
            return View(book);
        }

        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            try
            {
                var book = await _bookRepository.GetBookByIdAsync(id.Value);
                if (book == null) return NotFound();

                return View(book);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving book for editing, ID {BookId}", id);
                TempData["Error"] = "Error retrieving book. Please try again.";
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: Books/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Author,Description,Price,Category,Stock")] Book book)
        {
            if (id != book.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    book.UpdatedDate = DateTime.Now;
                    var success = await _bookRepository.UpdateBookAsync(book);
                    if (success)
                    {
                        TempData["Success"] = "Book updated successfully!";
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        TempData["Error"] = "Error updating book. Please try again.";
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error updating book ID {BookId}", id);
                    TempData["Error"] = "Error updating book. Please try again.";
                }
            }
            return View(book);
        }

        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            try
            {
                var book = await _bookRepository.GetBookByIdAsync(id.Value);
                if (book == null) return NotFound();

                return View(book);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving book for deletion, ID {BookId}", id);
                TempData["Error"] = "Error retrieving book. Please try again.";
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var success = await _bookRepository.DeleteBookAsync(id);
                if (success)
                {
                    TempData["Success"] = "Book deleted successfully!";
                }
                else
                {
                    TempData["Error"] = "Error deleting book. Please try again.";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting book ID {BookId}", id);
                TempData["Error"] = "Error deleting book. Please try again.";
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: Books/Search
        public async Task<IActionResult> Search(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return RedirectToAction(nameof(Index));
            }

            try
            {
                var books = await _bookRepository.SearchBooksAsync(searchTerm);
                ViewBag.SearchTerm = searchTerm;
                return View("Index", books);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error searching books with term: {SearchTerm}", searchTerm);
                TempData["Error"] = "Error searching books. Please try again.";
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: Books/DataSetDemo
        public IActionResult DataSetDemo()
        {
            try
            {
                var dataSet = _bookRepository.GetBooksAsDataSet();
                var books = new List<Book>();

                if (dataSet.Tables.Contains("Books") && dataSet.Tables["Books"].Rows.Count > 0)
                {
                    foreach (DataRow row in dataSet.Tables["Books"].Rows)
                    {
                        books.Add(new Book
                        {
                            Id = Convert.ToInt32(row["Id"]),
                            Title = row["Title"].ToString() ?? "",
                            Author = row["Author"].ToString() ?? "",
                            Description = row["Description"] == DBNull.Value ? null : row["Description"].ToString(),
                            Price = Convert.ToDecimal(row["Price"]),
                            Category = row["Category"].ToString() ?? "",
                            Stock = Convert.ToInt32(row["Stock"]),
                            CreatedDate = Convert.ToDateTime(row["CreatedDate"]),
                            UpdatedDate = row["UpdatedDate"] == DBNull.Value ? null : Convert.ToDateTime(row["UpdatedDate"])
                        });
                    }
                }

                ViewBag.DemoType = "DataSet";
                return View("Index", books);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in DataSet demo");
                TempData["Error"] = "Error demonstrating DataSet functionality.";
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: Books/DataTableDemo  
        public IActionResult DataTableDemo()
        {
            try
            {
                var dataTable = _bookRepository.GetBooksAsDataTable();
                var books = new List<Book>();

                foreach (DataRow row in dataTable.Rows)
                {
                    books.Add(new Book
                    {
                        Id = Convert.ToInt32(row["Id"]),
                        Title = row["Title"].ToString() ?? "",
                        Author = row["Author"].ToString() ?? "",
                        Description = row["Description"] == DBNull.Value ? null : row["Description"].ToString(),
                        Price = Convert.ToDecimal(row["Price"]),
                        Category = row["Category"].ToString() ?? "",
                        Stock = Convert.ToInt32(row["Stock"]),
                        CreatedDate = Convert.ToDateTime(row["CreatedDate"]),
                        UpdatedDate = row["UpdatedDate"] == DBNull.Value ? null : Convert.ToDateTime(row["UpdatedDate"])
                    });
                }

                ViewBag.DemoType = "DataTable";
                return View("Index", books);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in DataTable demo");
                TempData["Error"] = "Error demonstrating DataTable functionality.";
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
