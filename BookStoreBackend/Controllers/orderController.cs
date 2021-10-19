using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BookStoreBackend.Models.order;
using System.Web.Http.Cors;


namespace BookStoreBackend.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class orderController : ApiController
    {
        private Iorder repository;

        public orderController()
        {
            this.repository = new OrderRepo();
        }

        
        [HttpGet]
        [Route("orders/getOrders")]
        public IHttpActionResult Get()
        {
            var data = repository.GetOrdersOrders();
            return Ok(data);
        }










    }
}
