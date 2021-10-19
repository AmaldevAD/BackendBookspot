using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreBackend.Models
{
    public class Book
    {
        public int bookId { get; set; }
        public int catId { get; set; }
        public string bookTitle { get; set; }
        public string bookAuthor { get; set; }
        public string bookDescription { get; set; }
        public string bookIsbn { get; set; }
        public int bookYear  { get; set; }
        public double bookPrice { get; set; }
        public int bookPosition { get; set; }
        public bool bookStatus { get; set; }
        public string bookImage { get; set; }
        public int bookQuantity { get; set; }
        public string bookAddedAt { get; set; }

    }
}