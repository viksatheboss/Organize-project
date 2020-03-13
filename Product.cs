using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebShopProjectDomainModels
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public DateTime ProductRelease { get; set; }
        public int CategoryId { get; set; }
        public int NumberInStock { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

       
        
    }
}
