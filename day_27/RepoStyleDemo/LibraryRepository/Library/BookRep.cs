using LibModels;
using LibraryRepository.ILibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryRepository.Library
{
    public class BookRep : IBook
    {
        private readonly LibraryContext _context;

        public BookRep(LibraryContext context)
        {
            _context = context;
        }

        public string AddBook(Book book)
        {
            //throw new NotImplementedException();
            try
            {
                _context.Books.Add(book);
                _context.SaveChanges();
                return "Book added successfully";
            }
            catch (Exception ex)
            {
                return $"Error adding book: {ex.Message}";
            }
        }

        public string DeleteBook(int id)
        {
            throw new NotImplementedException();
        }

        public List<Book> GetBooks()
        {
            //throw new NotImplementedException();
            return _context.Books.ToList();
        }

        public string UpdateBook(Book book)
        {
            throw new NotImplementedException();
        }
    }
}
