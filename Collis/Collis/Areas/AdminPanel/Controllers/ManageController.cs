using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Helpers;
using Collis.Models;

namespace Collis.Areas.AdminPanel.Controllers
{
    public class ManageController : Controller
    {
        CollisEntities db = new CollisEntities();
        // GET: AdminPanel/Manage
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string Email, string Password)
        {
            Login log = db.Logins.Find(1);
           if(Crypto.VerifyHashedPassword(log.Password, Password) && Email==log.Email)
            {
                Session["Logged"] = true;
                return RedirectToAction("Index", "Dashboard");
            }

            Session["Wrong"] = true;
            return View();
        }


    }
}