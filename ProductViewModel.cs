using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShopProjectViewModels
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int CategoryId { get; set; }
        public int NumberInStock { get; set; }


        public CategoryViewModel Category { get; set; }
        public virtual List<ProductViewModel> Product { get; set; }
    }
}
