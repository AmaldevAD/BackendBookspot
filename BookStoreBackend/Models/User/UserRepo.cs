using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace BookStoreBackend.Models.User
{
    public class UserRepo : Iuser
    {

        SqlConnection conn;
        SqlCommand comm;
        public UserRepo()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
            conn = new SqlConnection(connectionString);
            comm = new SqlCommand();
        }

        public int CountUser()
        {
            comm.Connection = conn;
            comm.CommandText = "select COUNT(*) from [user]";
            conn.Open();
            SqlDataReader dr = comm.ExecuteReader();
            int rows = 0;
            if (dr.Read())
            {
                rows = dr.GetInt32(0);
            }
            conn.Close();
            return rows;
        }

        public List<User> GetUsers()
        {
            List<User> users = new List<User>();
            comm.Connection = conn;
            comm.CommandText = "select * from [user] ";
            conn.Open();
            SqlDataReader dr = comm.ExecuteReader();
            while (dr.Read())
            {
                User user = new User();
                user.userID = Convert.ToInt32( dr["userId"]);
                user.name = dr["userName"].ToString();
                user.email = dr["userEmail"].ToString();
                user.password = "";
                user.phone = dr["userPhone"].ToString();
                user.address = dr["userAddress"].ToString();
                user.status = Convert.ToInt32(dr["userStatus"]);


                users.Add(user);
            }
            conn.Close();

            return users;
        }


        public int UpdateUser(int id, User user)
        {
            comm.Connection = conn;
            comm.CommandText = "update user set userName = '" + user.name + "', userEmail = '" + user.email + "', userPhone = '" + user.phone + "', userStatus = " + Convert.ToInt32(user.status) + " order by userStatus  ";
            conn.Open();
            int rows = comm.ExecuteNonQuery();
            conn.Close();
            return rows;
        }
    }
}