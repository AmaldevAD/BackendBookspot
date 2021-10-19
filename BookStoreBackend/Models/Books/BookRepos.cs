using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using BookStoreBackend.Models;

namespace BookStoreBackend.Models
{
    public class BookRepos : IBook
    {

        SqlConnection conn;
        SqlCommand comm;
        public BookRepos()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["mydb"].ConnectionString);
            comm = new SqlCommand();
        }

        public int AddBook(Book book)
        {
            comm.Connection = conn;
            int status;
            if (Convert.ToBoolean(book.bookStatus))
                status = 1;
            else
                status = 0;
            comm.CommandText = "insert into books(catId,bookTitle,bookAuthor,bookDescription,bookIsbn,bookYear,bookPrice,bookPosition,bookStatus,bookImage,bookQuantity, bookAddedAt) values (" + Convert.ToInt32(book.catId) + ",'" + book.bookTitle + "','" + book.bookAuthor + "','" + book.bookDescription + "','" + book.bookIsbn + "'," + Convert.ToInt32(book.bookYear) + "," + Convert.ToDouble(book.bookPrice) + "," + Convert.ToInt32(book.bookPosition) + "," + status + ",'" + book.bookImage + "'," + Convert.ToInt32(book.bookQuantity) + " , GetDate())";
            conn.Open();
            int rows = Convert.ToInt32(comm.ExecuteNonQuery());
            conn.Close();
            return rows;
        }

        public int DeleteBook(int Id)
        {
            comm.Connection = conn;
            comm.CommandText = "delete from books where bookId = " + Id + "";
            conn.Open();
            int rows = comm.ExecuteNonQuery();
            conn.Close();
            return rows;
        }

        public List<Book> GetAllBook()
        {
            List<Book> books = new List<Book>();
            comm.Connection = conn;
            comm.CommandText = "select * from books order by bookPosition";
            conn.Open();
            SqlDataReader dr = comm.ExecuteReader();
            while (dr.Read())
            {
                Book book = new Book();
                book.bookId = dr.GetInt32(0);
                book.catId = dr.GetInt32(1);
                book.bookTitle = dr.GetString(2);
                book.bookAuthor = dr.GetString(3);
                book.bookDescription = dr.GetString(4);
                book.bookIsbn = dr.GetString(5);
                book.bookYear = dr.GetInt32(6);
                book.bookPrice = Convert.ToDouble(dr.GetDecimal(7));
                book.bookPosition = dr.GetInt32(8);
                book.bookStatus = dr.GetBoolean(9);
                book.bookImage = dr.GetString(10);
                book.bookQuantity = dr.GetInt32(11);
                book.bookAddedAt = Convert.ToString(dr.GetDateTime(12));


                books.Add(book);
            }
            conn.Close();
            return books;

        }

        public int CountBook()
        {
            comm.Connection = conn;
            comm.CommandText = "select COUNT(*) from books";
            conn.Open();
            SqlDataReader dr = comm.ExecuteReader();
            int rows = 0;
            if (dr.Read())
            {
                rows = dr.GetInt32(0);
            }
            conn.Close();
            return rows;
        }
        
        public int UpdateBook(int Id, Book book)
        {
            comm.Connection = conn;
            int status;
            if (Convert.ToBoolean(book.bookStatus))
                status = 1;
            else
                status = 0;
            comm.CommandText = "update books set catId = '" + book.catId + "', bookDescription = '" + book.bookDescription + "',bookYear = " + Convert.ToInt32(book.bookYear) + ", bookPrice = " + Convert.ToDouble(book.bookPrice) + ", bookPosition = " + Convert.ToInt32(book.bookPosition) + ", bookStatus = " + status + ", bookImage ='" + book.bookImage + "', bookQuantity = " + Convert.ToInt32(book.bookQuantity) + "  where bookId = " + Id + "";
            conn.Open();
            int rows = comm.ExecuteNonQuery();
            conn.Close();
            return rows;
        }
    }
}