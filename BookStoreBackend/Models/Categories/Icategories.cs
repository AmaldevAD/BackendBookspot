using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bookbackendtest.Models
{
    interface Icategories
    {
        List<Categories> GetAllCategories();

        int AddCategory(Categories category);

        int UpdateCategory(int Id, Categories category);
        int DeleteCategory(int Id);
    }
}
