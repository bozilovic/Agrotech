using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AgroTech1._2.Models;

namespace AgroTech1._2.Controllers
{
    public class ViATAllNodesDatasController : Controller
    {
        private AgroTechEntities db = new AgroTechEntities();

        // GET: viATAllNodesDatas
        public ActionResult Index()
        {
            return View(db.viATAllNodesDatas.ToList());
        }

        // GET: viATAllNodesDatas/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            viATAllNodesData viATAllNodesData = db.viATAllNodesDatas.Find(id);
            if (viATAllNodesData == null)
            {
                return HttpNotFound();
            }
            return View(viATAllNodesData);
        }

        // GET: viATAllNodesDatas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: viATAllNodesDatas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "node,sensor,avg_value,measuring_unit,Start_time,End_time,id")] viATAllNodesData viATAllNodesData)
        {
            if (ModelState.IsValid)
            {
                db.viATAllNodesDatas.Add(viATAllNodesData);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(viATAllNodesData);
        }

        // GET: viATAllNodesDatas/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            viATAllNodesData viATAllNodesData = db.viATAllNodesDatas.Find(id);
            if (viATAllNodesData == null)
            {
                return HttpNotFound();
            }
            return View(viATAllNodesData);
        }

        // POST: viATAllNodesDatas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "node,sensor,avg_value,measuring_unit,Start_time,End_time,id")] viATAllNodesData viATAllNodesData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(viATAllNodesData).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(viATAllNodesData);
        }

        // GET: viATAllNodesDatas/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            viATAllNodesData viATAllNodesData = db.viATAllNodesDatas.Find(id);
            if (viATAllNodesData == null)
            {
                return HttpNotFound();
            }
            return View(viATAllNodesData);
        }

        // POST: viATAllNodesDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            viATAllNodesData viATAllNodesData = db.viATAllNodesDatas.Find(id);
            db.viATAllNodesDatas.Remove(viATAllNodesData);
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
