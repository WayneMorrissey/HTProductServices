using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
#endregion

namespace HTPSSystem.WMorr.Data.Entities
{
    [Table("Registration")]
    public class Registration
    {
        [Key]
        public int RegistrationID { get; set; }
        public int ProductID { get; set; }
        public int CustomerID { get; set; }
        public string SerialNumber { get; set; }
        public DateTime DateOfPurchase { get; set; }
        public string PurchasedFrom { get; set; }
        public string PurchaseProvince { get; set; }
    }
}
