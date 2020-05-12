using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JoinPlan.DAL;
using JoinPlan.Models;

namespace JoinPlan.Controllers
{
    public class CMSController : Controller
    {
        private JoinPlanContext db = new JoinPlanContext();

        // GET: CMS
        public ActionResult Index()
        {
            return View(db.CMS.ToList());
        }

        // GET: CMS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CMS cMS = db.CMS.Find(id);
            if (cMS == null)
            {
                return HttpNotFound();
            }
            return View(cMS);
        }

        // GET: CMS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CMS/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CmsID,Name,Value,Type")] CMS cMS)
        {
            if (ModelState.IsValid)
            {
                db.CMS.Add(cMS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cMS);
        }

        // GET: CMS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CMS cMS = db.CMS.Find(id);
            if (cMS == null)
            {
                return HttpNotFound();
            }
            return View(cMS);
        }

        // POST: CMS/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CmsID,Name,Value,Type")] CMS cMS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cMS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cMS);
        }

        // GET: CMS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CMS cMS = db.CMS.Find(id);
            if (cMS == null)
            {
                return HttpNotFound();
            }
            return View(cMS);
        }

        // POST: CMS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CMS cMS = db.CMS.Find(id);
            db.CMS.Remove(cMS);
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
