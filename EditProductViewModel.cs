using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebShopProjectViewModels
{
    public class EditProductViewModel
    {
        [Required]
        public int ProductId { get; set; }

        [Required]
        public string ProductName { get; set; }
        
        [Required]
        public DateTime ReleaseDate { get; set; }
        
        [Required]
        public int CategoryId { get; set; }
    }
}
