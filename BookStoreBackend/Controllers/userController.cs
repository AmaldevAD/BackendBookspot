using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using BookStoreBackend.Models.User;

namespace BookStoreBackend.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class userController : ApiController
    {
        private Iuser repository;

        public userController()
        {
            this.repository = new UserRepo();
        }


        [HttpGet]
        [Route("users/getCount")]
        public IHttpActionResult Get()
        {
            var data = repository.CountUser();
            return Ok(data);
        }


        [HttpGet]
        [Route("users/getUsers")]
        public IHttpActionResult GetUsers()
        {
            var data = repository.GetUsers();
            return Ok(data);
        }

    }
}
