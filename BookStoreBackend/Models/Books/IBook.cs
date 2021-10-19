using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStoreBackend.Models;

namespace BookStoreBackend.Models
{
    interface IBook
    {
        List<Book> GetAllBook();
        int CountBook();
        int AddBook(Book book );
        int DeleteBook(int Id);
        int UpdateBook(int Id, Book book);
    }
}
