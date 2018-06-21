using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Collis.Areas.AdminPanel.Controllers
{
    public class DashboardController : Controller
    {
        // GET: AdminPanel/Dashboard
        public ActionResult Index()
        {
            if (Session["Logged"] != null)
            {
                return View();
            }

            return RedirectToAction("Index", "Manage");
        }
    }
}