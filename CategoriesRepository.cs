using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShopProjectDomainModels;

namespace WebShopProjectRepositories
{
    public interface ICategoriesRepository
    {
        void InsertCategory(Category c);
        void UpdateCategory(Category c);
        void DeleteCategory(int cid);
        List<Category> GetCategories();
        List<Category> GetCategoryByCategoryId(int CategoryId);
    }
    public class CategoriesRepository : ICategoriesRepository
    {
        WebShopDatabaseDbContext db;

        public CategoriesRepository()
        {
            db = new WebShopDatabaseDbContext();
        }

        public void InsertCategory (Category c)
        {
            db.Categories.Add(c);
            db.SaveChanges();
        }

        public void UpdateCategory (Category c)
        {
            Category ct = db.Categories.Where(temp => temp.CategoryId == c.CategoryId ).FirstOrDefault();
            if(ct != null)
            {
                ct.CategoryName = c.CategoryName;
                db.SaveChanges();

            }
        }

        public void DeleteCategory(int cid)
        {
            Category ct = db.Categories.Where(temp => temp.CategoryId == cid).FirstOrDefault();
            if (ct != null)
            {
                db.Categories.Remove(ct);
                db.SaveChanges();

            }
        }

        public List<Category> GetCategories()
        {
            List<Category> ct = db.Categories.ToList();
            return ct;
        }

        public List<Category> GetCategoryByCategoryId(int CategoryId)
        {
            List<Category> ct = db.Categories.Where(temp=>temp.CategoryId == CategoryId).ToList();
            return ct;
        }

        
    }
}
