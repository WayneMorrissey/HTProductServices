using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using HTPSSystem.WMorr.Data.Entities;
using HTPSSystem.WMorr.DAL;
#endregion

namespace HTPSSystem.WMorr.BLL
{
    public class ProductController
    {
        public List<Product> Product_List()
        {
            using (var context = new HTPSContext())
            {
                return context.Products.ToList();
            }
        }

        // Returns a single product instance based on the productid
        public Product Product_Find(int productid)
        {
            using (var context = new HTPSContext())
            {
                return context.Products.Find(productid);
            }
        }

        public int Product_Add(Product prod)
        {
            using (var context = new HTPSContext())
            {
                context.Products.Add(prod);

                context.SaveChanges();

                return prod.ProductID;
            }
        }
    }
}
