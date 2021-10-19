using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreBackend.Models.User
{
    interface Iuser
    {
        int CountUser();
        List<User> GetUsers();

        int UpdateUser(int id ,User user);
    }
}