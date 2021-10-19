using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreBackend.Models
{
    public class Coupon
    {
        public int couponId { get; set; }
        public string name { get; set; }
        public int percentage { get; set; }
        public bool status { get; set; }
    }
}