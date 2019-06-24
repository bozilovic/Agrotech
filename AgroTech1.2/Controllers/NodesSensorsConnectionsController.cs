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
    public class NodesSensorsConnectionsController : Controller
    {
        private AgroTechEntities db = new AgroTechEntities();

        // GET: NodesSensorsConnections
        public ActionResult Index()
        {
            var tblATNodesSensorsConnections = db.tblATNodesSensorsConnections.Include(t => t.tblATNode).Include(t => t.tblATSensor);
            return View(tblATNodesSensorsConnections.ToList());
        }

        // GET: NodesSensorsConnections/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblATNodesSensorsConnection tblATNodesSensorsConnection = db.tblATNodesSensorsConnections.Find(id);
            if (tblATNodesSensorsConnection == null)
            {
                return HttpNotFound();
            }
            return View(tblATNodesSensorsConnection);
        }

        // GET: NodesSensorsConnections/Create
        public ActionResult Create()
        {
            ViewBag.node_id = new SelectList(db.tblATNodes, "node_id", "node_name");
            ViewBag.sensor_id = new SelectList(db.tblATSensors, "sensor_id", "sensor_type");
            return View();
        }

        // POST: NodesSensorsConnections/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,node_id,sensor_id")] tblATNodesSensorsConnection tblATNodesSensorsConnection)
        {
            if (ModelState.IsValid)
            {
                db.tblATNodesSensorsConnections.Add(tblATNodesSensorsConnection);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.node_id = new SelectList(db.tblATNodes, "node_id", "node_name", tblATNodesSensorsConnection.node_id);
            ViewBag.sensor_id = new SelectList(db.tblATSensors, "sensor_id", "sensor_type", tblATNodesSensorsConnection.sensor_id);
            return View(tblATNodesSensorsConnection);
        }

        // GET: NodesSensorsConnections/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblATNodesSensorsConnection tblATNodesSensorsConnection = db.tblATNodesSensorsConnections.Find(id);
            if (tblATNodesSensorsConnection == null)
            {
                return HttpNotFound();
            }
            ViewBag.node_id = new SelectList(db.tblATNodes, "node_id", "node_name", tblATNodesSensorsConnection.node_id);
            ViewBag.sensor_id = new SelectList(db.tblATSensors, "sensor_id", "sensor_type", tblATNodesSensorsConnection.sensor_id);
            return View(tblATNodesSensorsConnection);
        }

        // POST: NodesSensorsConnections/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,node_id,sensor_id")] tblATNodesSensorsConnection tblATNodesSensorsConnection)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblATNodesSensorsConnection).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.node_id = new SelectList(db.tblATNodes, "node_id", "node_name", tblATNodesSensorsConnection.node_id);
            ViewBag.sensor_id = new SelectList(db.tblATSensors, "sensor_id", "sensor_type", tblATNodesSensorsConnection.sensor_id);
            return View(tblATNodesSensorsConnection);
        }

        // GET: NodesSensorsConnections/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblATNodesSensorsConnection tblATNodesSensorsConnection = db.tblATNodesSensorsConnections.Find(id);
            if (tblATNodesSensorsConnection == null)
            {
                return HttpNotFound();
            }
            return View(tblATNodesSensorsConnection);
        }

        // POST: NodesSensorsConnections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            tblATNodesSensorsConnection tblATNodesSensorsConnection = db.tblATNodesSensorsConnections.Find(id);
            db.tblATNodesSensorsConnections.Remove(tblATNodesSensorsConnection);
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
