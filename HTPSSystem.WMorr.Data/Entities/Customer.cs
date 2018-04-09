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
    [Table("Customer")]
    public class Customer
    {
        string contactNumber;

        [Key]
        public int CustomerID { get; set; }
        [Required(ErrorMessage = "A first name is required")]
        [StringLength(50, ErrorMessage = "First name is limited to 50 characters.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "A last name is required")]
        [StringLength(50, ErrorMessage = "Last name is limited to 50 characters.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "An email is required")]
        [StringLength(100, ErrorMessage = "Email is limited to 100 characters.")]
        public string Email { get; set; }
        [StringLength(12, ErrorMessage = "Contact number is limited to 12 characters.")]
        public string ContactNumber
        {
            get { return contactNumber; }
            set { contactNumber = string.IsNullOrEmpty(value) ? null : value; }
        }

        [NotMapped]
        public string FullName
        {
            get { return LastName + ", " + FirstName; }
        }
    }
}
