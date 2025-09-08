using LibModels;
using LibraryRepository.ILibrary;
using LibraryRepository.Library;
using Microsoft.AspNetCore.Mvc;

namespace RepoStyleDemoMVC.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBook _db;

        public BooksController(IBook db)
        {
               _db = db;
        }

        [HttpPost]
        public IActionResult Create()
        {
            Book b = new Book()
            {
                AuthorId = 1,
                Description = "A book about C#",
                Type = "Programming",

            };
            ViewBag.message = _db.AddBook(b);
            return View();
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_db.GetBooks());
        }
    }
}
