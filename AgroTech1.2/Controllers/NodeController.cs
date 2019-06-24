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
    public class NodeController : Controller
    {
        private AgroTechEntities db = new AgroTechEntities();

        // GET: Node
        public ActionResult Index()
        {
            return View(db.tblATNodes.ToList());
        }

        // GET: Node/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblATNode tblATNode = db.tblATNodes.Find(id);
            if (tblATNode == null)
            {
                return HttpNotFound();
            }
            return View(tblATNode);
        }

        // GET: Node/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Node/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "node_id,node_name,node_type")] tblATNode tblATNode)
        {
            if (ModelState.IsValid)
            {
                db.tblATNodes.Add(tblATNode);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblATNode);
        }

        // GET: Node/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblATNode tblATNode = db.tblATNodes.Find(id);
            if (tblATNode == null)
            {
                return HttpNotFound();
            }
            return View(tblATNode);
        }

        // POST: Node/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "node_id,node_name,node_type")] tblATNode tblATNode)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblATNode).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblATNode);
        }

        // GET: Node/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblATNode tblATNode = db.tblATNodes.Find(id);
            if (tblATNode == null)
            {
                return HttpNotFound();
            }
            return View(tblATNode);
        }

        // POST: Node/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            tblATNode tblATNode = db.tblATNodes.Find(id);
            db.tblATNodes.Remove(tblATNode);
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
