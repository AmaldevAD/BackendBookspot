using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BookStoreBackend.Models;

namespace BookStoreBackend.Controllers
{
    public class BookController : ApiController
    {
        private IBook repository;
        public BookController()
        {
            this.repository = new BookRepos();
        }
        public HttpResponseMessage Post(Book book)
        {
            int rows = repository.AddBook(book);
            if (rows <= 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Oops !!! Something went wrong");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Created, "Record inserted succesfully " + book.bookTitle);
            }
        }
        public HttpResponseMessage Delete(int Id)
        {
            int rows = repository.DeleteBook(Id);
            if (rows <= 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Oops !!! Something went wrong" + rows);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Record deleted succesfully ");
            }
        }
        public IHttpActionResult Get()
        {
            var data = repository.GetAllBook();
            return Ok(data);
        }
        public HttpResponseMessage Put(int id, Book book)
        {
            int rows = repository.UpdateBook(id, book);
            if (rows <= 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Oops !!! Something went wrong");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Created, "Record Updated succesfully" + book.bookTitle);
            }
        }
        [HttpGet]
        [Route("api/book/count")]
        public int GetCount()
        {
            int rows = repository.CountBook();
            return rows;

        }
    }
}
