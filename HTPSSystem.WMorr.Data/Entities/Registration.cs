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
        [Required(ErrorMessage = "Product ID is required")]
        public int ProductID { get; set; }
        [Required(ErrorMessage = "Customer ID is required")]
        public int CustomerID { get; set; }
        [Required(ErrorMessage = "Serial number is required")]
        [StringLength(10, ErrorMessage = "Serial number is limited to 10 characters.")]
        public string SerialNumber { get; set; }
        [Required(ErrorMessage = "Date of purchase is required")]
        public DateTime DateOfPurchase { get; set; }
        [Required(ErrorMessage = "Purchased from is required")]
        [StringLength(50, ErrorMessage = "Purchased from is limited to 50 characters.")]
        public string PurchasedFrom { get; set; }
        [Required(ErrorMessage = "Purchase province is required")]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "Purchase province must be exactly 2 characters.")]
        public string PurchaseProvince { get; set; }
    }
}
