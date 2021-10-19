using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using BookStoreBackend.Models;

using System.Configuration;


namespace BookStoreBackend.Models
{
    public class CouponRepos : ICoupon
    {
        SqlConnection conn;
        SqlCommand comm;
        public CouponRepos()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["mydb"].ConnectionString);
            comm = new SqlCommand();
        }
        public int AddCoupon(Coupon coupon)
        {
            int status = 0;
            if (Convert.ToBoolean(coupon.status))
                status = 1;
            else
                status = 0;
            comm.CommandText = "insert into coupon( couponName , couponPercentage, couponStatus ) values ('" + coupon.name + "'," + Convert.ToInt32(coupon.percentage) + "," + status + ")";
            comm.Connection = conn;
            conn.Open();
            int rows = comm.ExecuteNonQuery();
            conn.Close();
            return rows;
        }

        public int DeleteCoupon(int Id)
        {
            comm.CommandText = "delete from coupon where couponId ="+ Id +"";
            comm.Connection = conn;
            conn.Open();
            int rows = comm.ExecuteNonQuery();
            conn.Close();
            return rows;
        }

        public int UpdateCoupon(int Id, Coupon coupon)
        { int status = 0;
            if (Convert.ToBoolean(coupon.status))
            { status = 0;
                comm.CommandText = "update coupon set couponStatus = " + status + "";
            }
            else
            { status = 1;
                comm.CommandText = "update coupon set couponStatus = " + status+ "";
            }
            comm.Connection = conn;
            conn.Open();
            int rows = comm.ExecuteNonQuery();
            conn.Close();
            return rows;
        }


        public List<Coupon> GetAllCoupon()
        {
            List<Coupon> coupons = new List<Coupon>();
            comm.CommandText = "select * from coupon";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader dr = comm.ExecuteReader();
            while (dr.Read())
            {
                Coupon coupon = new Coupon();
                coupon.couponId = dr.GetInt32(0);
                coupon.name = dr.GetString(1);
                coupon.percentage = dr.GetInt32(2);
                coupon.status = dr.GetBoolean(3);
                coupons.Add(coupon);
            }
            conn.Close();
            return coupons;
        }
    }
}
