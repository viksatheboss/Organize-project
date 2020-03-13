using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebShopProjectViewModels
{
    public class EditSoldProductViewModel
    {
        public int SoldProductId { get; set; }
        public string SoldProductName { get; set; }
        public DateTime SoldProductDateAndTime { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }

        public virtual ProductViewModel Product { get; set; }
    }
}
