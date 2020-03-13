using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShopProjectDomainModels;

namespace WebShopProjectRepositories
{
    public interface ISoldProductsRepository
    {
        void InsertSoldProduct(SoldProduct sp);
        void UpdateSoldProduct(SoldProduct sp);
        void DeleteSoldProduct(int spid);
        List<SoldProduct> GetSoldProducts();
        List<SoldProduct> GetSoldProductsById(int SoldProductId);
    }
    public class SoldProductsRepository : ISoldProductsRepository
    {
        WebShopDatabaseDbContext db;
        IProductRepository pr;

        public SoldProductsRepository()
        {
            db = new WebShopDatabaseDbContext();
            pr = new ProductRepository();
        }

        public void InsertSoldProduct(SoldProduct sp)
        {
            db.SoldProducts.Add(sp);
            db.SaveChanges();
            pr.UpdateProductNumberInStock(sp.ProductId,1);
        }

        public void UpdateSoldProduct(SoldProduct sp)
        {
            SoldProduct spr = db.SoldProducts.Where(temp => temp.SoldProductId == sp.SoldProductId).FirstOrDefault();
            if (spr != null)
            {
                spr.SoldProductName = sp.SoldProductName;
                db.SaveChanges();
            }
        }

        public void DeleteSoldProduct(int spid)
        {
            SoldProduct sp = db.SoldProducts.Where(temp => temp.SoldProductId == spid).FirstOrDefault();
            if (sp != null)
            {
                db.SoldProducts.Remove(sp);
                db.SaveChanges();
            }
        }

        public List<SoldProduct> GetSoldProducts()
        {
            List<SoldProduct> sp = db.SoldProducts.ToList();
            return sp;
        }

        public List<SoldProduct> GetSoldProductsById(int SoldProductId)
        {
            List<SoldProduct> sp = db.SoldProducts.Where(temp =>temp.SoldProductId == SoldProductId).ToList();
            return sp;
        }
    }
}
