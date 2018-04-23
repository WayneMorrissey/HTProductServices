using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using HTPSSystem.WMorr.Data.Entities;
using HTPSSystem.WMorr.DAL;
using System.ComponentModel;
#endregion

namespace HTPSSystem.WMorr.BLL
{
    [DataObject]
    public class ProductController
    {
        [DataObjectMethod(DataObjectMethodType.Select, false)]
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

        // method for adding a product
        public int Product_Add(Product prod)
        {
            using (var context = new HTPSContext())
            {
                context.Products.Add(prod);

                context.SaveChanges();

                return prod.ProductID;
            }
        }

        // method for updating a product
        public int Product_Update(Product prod)
        {
            using(var context = new HTPSContext())
            {
                context.Entry(prod).State = System.Data.Entity.EntityState.Modified;

                return context.SaveChanges();
            }
        }

        public int Product_Delete(Product prod)
        {
            using(var context = new HTPSContext())
            {
                prod.Discontinued = true;
                prod.DiscontinuedDate = DateTime.Today;
                context.Entry(prod).State = System.Data.Entity.EntityState.Modified;

                return context.SaveChanges();
            }
        }
    }
}
