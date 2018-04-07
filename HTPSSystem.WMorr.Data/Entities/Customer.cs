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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
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
