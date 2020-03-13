using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebShopProjectViewModels
{
    public class NewProductViewModel
    {
        public string ProductName { get; set; }
        public DateTime ProductRelease { get; set; }
        public int CategoryId { get; set; }
    }
}
