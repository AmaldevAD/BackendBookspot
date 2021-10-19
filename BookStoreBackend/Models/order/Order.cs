using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreBackend.Models
{
    public class Order
    {
        public int orderId { get; set; }
        public int UserId { get; set; }
        public int bookId { get; set; }
        public string orderPlacedAt  {get; set; }
}
}