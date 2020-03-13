using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShopProjectDomainModels;
using WebShopProjectViewModels;
using WebShopProjectRepositories;
using AutoMapper;
using AutoMapper.Configuration;

namespace WebShopProjectServiceLayer
{
    public interface IProductService
    {
        void InsertProduct(NewProductViewModel pvm);
        void UpdateProductDetails(EditProductViewModel pvm);
        void UpdateProductNumberInStock(int pid, int value);
        void DeleteProduct(int pid);
        List<ProductViewModel> GetProducts();
        ProductViewModel GetProductsById(int ProductId);

    }
    public class ProductService : IProductService
    {
        IProductRepository pr;

        public ProductService()
        {
            pr = new ProductRepository();
        }

        public void InsertProduct(NewProductViewModel pvm)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<NewProductViewModel, Product>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            Product p = mapper.Map<NewProductViewModel, Product>(pvm);
            pr.InsertProduct(p);


        }

        public void UpdateProductDetails (EditProductViewModel pvm)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<EditProductViewModel, Product>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            Product p = mapper.Map<EditProductViewModel, Product>(pvm);
            pr.UpdateProductDetails(p);
        }

        public void UpdateProductNumberInStock(int pid, int value)
        {
            pr.UpdateProductNumberInStock(pid, value);
        }
        public void DeleteProduct(int pid)
        {
            pr.DeleteProduct(pid);
        }

        public List<ProductViewModel> GetProducts()
        {
            List<Product> p = pr.GetProducts();
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<Product, ProductViewModel>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            List<ProductViewModel> pvm = mapper.Map<List<Product>, List<ProductViewModel>>(p);
            return pvm;
        }

        public ProductViewModel GetProductsById(int ProductId)
        {
            Product p = pr.GetProductsById(ProductId).FirstOrDefault();
            ProductViewModel pvm = null;
            if (p != null)
            {
                var config = new MapperConfiguration(cfg => { cfg.CreateMap<Product, ProductViewModel>(); cfg.IgnoreUnmapped(); });
                IMapper mapper = config.CreateMapper();
                 pvm = mapper.Map<Product, ProductViewModel>(p);
            }
            
            return pvm;
        }

        
    }
}
