using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace BookStoreBackend.Models.order
{
    public class OrderRepo : Iorder
    {
        SqlConnection conn;
        SqlCommand comm;

        public OrderRepo()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
            conn = new SqlConnection(connectionString);
            comm = new SqlCommand();
        }


        public List<Order> GetOrdersOrders()
        {
            List<Order> orders = new List<Order>();
            comm.Connection = conn;
            comm.CommandText = "select * from orders";
            conn.Open();

            SqlDataReader dr = comm.ExecuteReader();
            while (dr.Read())
            {
                Order order = new Order();
                order.orderId = dr.GetInt32(0);
                order.UserId = dr.GetInt32(1);
                order.bookId = dr.GetInt32(2);
                order.orderPlacedAt =Convert.ToString( dr.GetDateTime(3));
                orders.Add(order);
            }

            return orders;
        }

        //pending
        public int UpdateOrders(Order order)
        {
            throw new NotImplementedException();
        }
    }
}