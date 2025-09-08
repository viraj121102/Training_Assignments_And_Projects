using LibModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryRepository.ILibrary
{
    public interface IBook
    {
        string AddBook(Book book);
        List<Book> GetBooks();
        string UpdateBook(Book book);
        string DeleteBook(int id);
    }
}
