using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using bookbackendtest.Models;

namespace bookbackendtest.Controllers
{
    public class categoriesController : ApiController
    {
        private Icategories repository;

        public categoriesController()
        {
            this.repository = new categoriesRepo();
        }
        public HttpResponseMessage Post(Categories category)
        {
            int rows = repository.AddCategory(category);
            if (rows <= 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Oops !!! Something went wrong");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Created, "Record inserted succesfully " + category.categoryName);
            }
        }
        public IHttpActionResult Get()
        {
            var data = repository.GetAllCategories();
            return Ok(data);
        }
    }
}
