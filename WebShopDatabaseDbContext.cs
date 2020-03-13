using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace WebShopProjectDomainModels
{
    public class WebShopDatabaseDbContext :DbContext
    {
        

        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<SoldProduct> SoldProducts { get; set; }

        
    }
}
