using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Collis.Models;

namespace Collis.Controllers
{
    public class HomeCollisController : Controller
    {
        CollisEntities db = new CollisEntities();
        // GET: HomeCollis
        public ActionResult Index()
        {
            BaseModels Bm = new BaseModels();

            Bm.hm = db.HomePages.ToList();
            Bm.ht = db.HomeSlideTexts.ToList();
            Bm.ss = db.SocialSites.ToList();
            Bm.about = db.Abouts.FirstOrDefault();
            Bm.services = db.Services.ToList();
            Bm.cou = db.Counters.ToList();
            Bm.pro = db.Protofilios.ToList();
            Bm.fil = db.Filters.ToList();
            Bm.testi = db.Testimonials.ToList();
            Bm.news = db.News.ToList();
            ViewBag.Contact = db.Contacts.Find(1);
            ViewBag.TaseTitle = db.PageTitles.Find(3);
            ViewBag.ProTitle = db.PageTitles.Find(2);
            ViewBag.NewsTitle = db.PageTitles.Find(4);
            ViewBag.ServiceTitle = db.PageTitles.FirstOrDefault();
            ViewBag.Logo1 = db.LogoNavBars.FirstOrDefault().LogoUrl;
            ViewBag.Logo2 = db.LogoNavBars.OrderByDescending(m => m.Id).FirstOrDefault().LogoUrl;
            return View(Bm);
        }
    }
}