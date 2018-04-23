using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region AdditionalNamespaces
using HTPSSystem.WMorr.Data.Entities;
using HTPSSystem.WMorr.DAL;
using System.Data.SqlClient;
using System.ComponentModel;
#endregion

namespace HTPSSystem.WMorr.BLL
{
    [DataObject]
    public class RegistrationController
    {
        public List<Registration> Registration_List()
        {
            using (var context = new HTPSContext())
            {
                return context.Registrations.ToList();
            }
        }

        public Registration Registration_Get(int registrationid)
        {
            using (var context = new HTPSContext())
            {
                return context.Registrations.Find(registrationid);
            }
        }

        public List<Registration> Registration_GetByProduct(int productid)
        {
            using (var context = new HTPSContext())
            {
                return context.Database.SqlQuery<Registration>("Registration_GetByProduct @ProductID", new SqlParameter("ProductID", productid)).ToList();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Registration> Registration_GetByModelNumber(string modelnumber)
        {
            using (var context = new HTPSContext())
            {
                return context.Database.SqlQuery<Registration>("Registration_GetByModelNumber @ModelNumber", new SqlParameter("ModelNumber", modelnumber)).ToList();
            }
        }
    }
}
