using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using bookbackendtest.Models;
using System.Data.SqlClient;
using System.Configuration;

namespace bookbackendtest.Models
{
    public class categoriesRepo : Icategories
    {
        SqlConnection conn;
        SqlCommand comm;
        public categoriesRepo()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
            conn = new SqlConnection(connectionString);
            comm = new SqlCommand();
        }
        public int AddCategory(Categories category)
        {
            comm.Connection = conn;
            int status;
            
            if (Convert.ToBoolean(category.status))
                status = 1;
            else
                status = 0;
            comm.CommandText = "insert into categories(catName,catDescription,catImage,catStatus,catPosition,catCreatedAt) values ('" + category.categoryName + "','" + category.description + "','" + category.image + "'," + status + "," + Convert.ToInt32(category.position) + ",'" + category.createdAt + "')";
            conn.Open();
            int rows = Convert.ToInt32(comm.ExecuteNonQuery());
            conn.Close();
            return rows;


        }

        public int DeleteCategory(int Id)
        {
            throw new NotImplementedException();
        }

        public List<Categories> GetAllCategories()
        {
            List<Categories> categories = new List<Categories>();
            comm.Connection = conn;
            comm.CommandText = "select * from categories order by catPosition";
            conn.Open();
            SqlDataReader dr = comm.ExecuteReader();
            while (dr.Read())
            {
                Categories category = new Categories();
                category.categoryId = dr.GetInt32(0);
                category.categoryName = dr.GetString(1);
                category.description = dr.GetString(2);
                category.image = dr.GetString(3);
                category.status = Convert.ToBoolean(dr.GetBoolean(4));
                category.position = dr.GetInt32(5);
               //category.createdAt = dr.GetSqlDateTime(6);
                //dr.Get;

                categories.Add(category);
            }
            return categories;




        }

        public int UpdateCategory(int Id, Categories category)
        {
            throw new NotImplementedException();
        }
    }
}