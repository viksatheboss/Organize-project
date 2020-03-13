using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebShopProjectViewModels
{
    public class SoldProductViewModel
    {
        public int SoldProductId { get; set; }
        public string SoldProductName { get; set; }
        public DateTime SoldProductDateAndTime { get; set; }
        public int CategoryId { get; set; }
        public int NumberInStock { get; set; }
        
    }
}
