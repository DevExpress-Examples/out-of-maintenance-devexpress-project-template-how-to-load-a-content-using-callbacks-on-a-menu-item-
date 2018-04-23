using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MenuExample.Models;

namespace MenuExample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
			// DXCOMMENT: Pass a data model for GridView
            return View();	
        }
		
		public ActionResult GridViewPartialView() 
		{
            // DXCOMMENT: Pass a data model for GridView in the PartialView method's second parameter
			return PartialView("GridViewPartialView", NorthwindDataProvider.GetCustomers());
        }
        public ActionResult CallbackPanelPartial(string view)
        {
            ViewData["view"] = view;   
            return PartialView();
        }
        public ActionResult GridViewCategoriesPartial() {

            return PartialView(NorthwindDataProvider.DB.Categories);
        }
        public ActionResult GridViewProductsPartial()
        {
            return PartialView(NorthwindDataProvider.DB.Products);
        }
	}
}