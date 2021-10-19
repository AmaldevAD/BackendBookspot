using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreBackend.Models.order
{
    interface Iorder
    {
        List<Order> GetOrdersOrders();
        int UpdateOrders(Order order);




    }
}