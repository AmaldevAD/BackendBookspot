using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreBackend.Models
{
    interface ICoupon
    {
        List<Coupon> GetAllCoupon();
        int AddCoupon(Coupon coupon);
        int DeleteCoupon(int Id);
        int UpdateCoupon(int Id,Coupon coupon);
    }
}
