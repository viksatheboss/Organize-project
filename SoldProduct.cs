using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebShopProjectDomainModels
{
    public class SoldProduct
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SoldProductId { get; set; }
        public string SoldProductName { get; set; }
        public DateTime SoldProductDateAndTime { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int CategoryId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public virtual Category Category { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
    }
}
