using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShopProjectDomainModels;

namespace WebShopProjectRepositories
{
    public interface IProductRepository
    {
        void InsertProduct(Product p);
        void UpdateProductDetails(Product p);
        void UpdateProductNumberInStock(int pid, int value);
        void DeleteProduct(int pid);
        List<Product> GetProducts();
        List<Product> GetProductsById(int ProductId);
    }
    public class ProductRepository :IProductRepository
    {
        WebShopDatabaseDbContext db;
        public ProductRepository()
        {
            db = new WebShopDatabaseDbContext();
        }
        public void InsertProduct (Product p)
        {
            db.Product.Add(p);
            db.SaveChanges();
        }

        public void UpdateProductDetails (Product p)
        {
            Product pr = db.Product.Where(temp => temp.ProductId == p.ProductId).SingleOrDefault();
            if (pr != null)
            {
                pr.ProductName = p.ProductName;
                pr.ProductRelease = p.ProductRelease;

                db.SaveChanges();
            }
        }

        public void UpdateProductNumberInStock(int pid, int value)
        {
            Product pr = db.Product.Where(temp => temp.ProductId == pid).FirstOrDefault();
            if (pr != null)
            {
                db.Product.Add(pr);
                db.SaveChanges();

            }
        }
        public void DeleteProduct(int pid)
        {
            Product pr = db.Product.Where(temp => temp.ProductId == pid).FirstOrDefault();
            if (pr != null)
            {
                db.Product.Remove(pr);
                db.SaveChanges();
            }
        }

        public List<Product> GetProducts()
        {
            List<Product> p = db.Product.ToList();
            return p;
        }

        public List<Product> GetProductsById(int ProductId)
        {
            List<Product> p = db.Product.Where(temp=>temp.ProductId == ProductId).ToList();
            return p;
        }
       
    }
}
