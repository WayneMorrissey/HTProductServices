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
    [Table("Product")]
    public class Product
    {
        DateTime? discontinuedDate;

        [Key]
        public int PublicID { get; set; }
        public string Name { get; set; }
        public string ModelNumber { get; set; }
        public bool Discontinued { get; set; }
        public DateTime? DiscontinuedDate
        {
            get { return discontinuedDate; }
            set { discontinuedDate = string.IsNullOrEmpty(value.ToString()) ? null : value; }
        }
    }
}
