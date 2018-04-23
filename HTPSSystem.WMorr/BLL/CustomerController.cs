using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region
using System.ComponentModel;
using HTPSSystem.WMorr.Data.Entities;
using HTPSSystem.WMorr.DAL;
#endregion

namespace HTPSSystem.WMorr.BLL
{
    [DataObject]
    public class CustomerController
    {
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Customer> Customer_List()
        {
            using (var context = new HTPSContext())
            {
                return context.Customers.ToList();
            }
        }
    }
}
