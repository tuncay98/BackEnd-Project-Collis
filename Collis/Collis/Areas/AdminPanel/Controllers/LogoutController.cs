using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Collis.Areas.AdminPanel.Controllers
{
    public class LogoutController : Controller
    {
        // GET: AdminPanel/Logout
        public ActionResult Index()
        {
            Session["Logged"] = null;
            return RedirectToAction("Index", "Manage");

        }
    }
}