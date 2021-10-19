using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BookStoreBackend.Models;

namespace BookStoreBackend.Controllers
{
    public class CouponController : ApiController
    {
        private ICoupon repository;
        public CouponController()
        {
            this.repository = new CouponRepos();
        }
        public HttpResponseMessage Post(Coupon coupon)
        {
            int rows = repository.AddCoupon(coupon);
            if (rows <= 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Oops !!! Something went wrong");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Created, "Record inserted succesfully " + coupon.name);
            }
        }
        public HttpResponseMessage Delete(int Id)
        {
            int rows = repository.DeleteCoupon(Id);
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
            var data = repository.GetAllCoupon();
            return Ok(data);
        }
        public HttpResponseMessage Put(int id, Coupon coupon)
        {
            int rows = repository.UpdateCoupon(id, coupon);
            if (rows <= 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Oops !!! Something went wrong");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Created, "Record Updated succesfully" + coupon.name);
            }
        }
       
    }
}
