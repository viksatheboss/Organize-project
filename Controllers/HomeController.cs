using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShopProjectServiceLayer;
using WebShopProjectViewModels;

namespace WebShopProject.Controllers
{
    public class HomeController : Controller
    {
        IProductService ps;

        public HomeController(IProductService ps)
        {
            this.ps = ps;
        }
        public ActionResult Index()
        {
            List<ProductViewModel> products = this.ps.GetProducts().Take(5).ToList();
            return View(products);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}