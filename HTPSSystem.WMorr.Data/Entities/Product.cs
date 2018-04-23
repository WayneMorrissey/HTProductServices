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
        public int ProductID { get; set; }
        [Required(ErrorMessage = "A name is required")]
        [StringLength(50, ErrorMessage = "Name is limited to 50 characters.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "A model number is required")]
        [StringLength(15, ErrorMessage = "Model Number is limited to 50 characters.")]
        public string ModelNumber { get; set; }
        [Required(ErrorMessage = "Discontinued is required")]
        public bool Discontinued { get; set; }
        public DateTime? DiscontinuedDate
        {
            get { return discontinuedDate; }
            set { discontinuedDate = string.IsNullOrEmpty(value.ToString()) ? null : value; }
        }

        [NotMapped]
        public string DisplayName
        {
            get { return ModelNumber + " : " + Name; }
        }
    }
}
