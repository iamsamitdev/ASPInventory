using ASPInventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPInventory.Controllers
{
    
    [SessionCheck]
    public class BackendController : Controller
    {
        // GET: Backend
        public ActionResult Dashboard()
        {
            return View();
        }

        public ActionResult Product()
        {
            ASPInventoryDBEntities context = new ASPInventoryDBEntities();
            List<product> data = context.products.ToList();
            return View(data);
        }

        public ActionResult CreateProduct()
        {

            ASPInventoryDBEntities ctx = new ASPInventoryDBEntities();
            var getCategory = ctx.Categories.ToList();
            SelectList catlist = new SelectList(getCategory, "CategoryID", "CategoryName");

            ViewBag.catlistname = catlist;

            return View();
        }

        public ActionResult Logout()
        {
            // Remove Session
            Session.RemoveAll();
            return RedirectToAction("Login", "Frontend");
        }

    }
}