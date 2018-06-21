using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Collis.Models;
using Collis.Filter;

namespace Collis.Areas.AdminPanel.Controllers
{
    [Auth]
    public class ProtofiliosController : Controller
    {
        private CollisEntities db = new CollisEntities();

        // GET: AdminPanel/Protofilios
        public ActionResult Index()
        {
            return View(db.Protofilios.ToList());
        }

        // GET: AdminPanel/Protofilios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Protofilio protofilio = db.Protofilios.Find(id);
            if (protofilio == null)
            {
                return HttpNotFound();
            }
            return View(protofilio);
        }

        // GET: AdminPanel/Protofilios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminPanel/Protofilios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Category")] Protofilio protofilio, HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                string filename = DateTime.Now.ToString("yyyyMMddHHmmss") + Image.FileName;
                var myfile = System.IO.Path.Combine(Server.MapPath("~/Upload"), filename);
                Image.SaveAs(myfile);
                protofilio.Image = "Upload/"+filename;
                db.Protofilios.Add(protofilio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(protofilio);
        }

        // GET: AdminPanel/Protofilios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Protofilio protofilio = db.Protofilios.Find(id);
            if (protofilio == null)
            {
                return HttpNotFound();
            }
            return View(protofilio);
        }

        // POST: AdminPanel/Protofilios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Image,Title,Category")] Protofilio protofilio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(protofilio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(protofilio);
        }

        // GET: AdminPanel/Protofilios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Protofilio protofilio = db.Protofilios.Find(id);
            if (protofilio == null)
            {
                return HttpNotFound();
            }
            return View(protofilio);
        }

        // POST: AdminPanel/Protofilios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Protofilio protofilio = db.Protofilios.Find(id);
            db.Protofilios.Remove(protofilio);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
