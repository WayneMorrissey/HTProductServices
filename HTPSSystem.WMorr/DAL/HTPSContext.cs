using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using System.Data.Entity;
using HTPSSystem.WMorr.Data.Entities;
#endregion

namespace HTPSSystem.WMorr.DAL
{
    internal class HTPSContext:DbContext
    {
        public HTPSContext():base("HTPS_db")
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Registration> Registrations { get; set; }

    }
}
