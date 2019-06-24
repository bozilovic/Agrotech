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
    public class SensorController : Controller
    {
        private AgroTechEntities db = new AgroTechEntities();

        // GET: Sensor
        public ActionResult Index()
        {
            return View(db.tblATSensors.ToList());
        }

        // GET: Sensor/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblATSensor tblATSensor = db.tblATSensors.Find(id);
            if (tblATSensor == null)
            {
                return HttpNotFound();
            }
            return View(tblATSensor);
        }

        // GET: Sensor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sensor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "sensor_id,sensor_type,measuring_unit")] tblATSensor tblATSensor)
        {
            if (ModelState.IsValid)
            {
                db.tblATSensors.Add(tblATSensor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblATSensor);
        }

        // GET: Sensor/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblATSensor tblATSensor = db.tblATSensors.Find(id);
            if (tblATSensor == null)
            {
                return HttpNotFound();
            }
            return View(tblATSensor);
        }

        // POST: Sensor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "sensor_id,sensor_type,measuring_unit")] tblATSensor tblATSensor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblATSensor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblATSensor);
        }

        // GET: Sensor/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblATSensor tblATSensor = db.tblATSensors.Find(id);
            if (tblATSensor == null)
            {
                return HttpNotFound();
            }
            return View(tblATSensor);
        }

        // POST: Sensor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            tblATSensor tblATSensor = db.tblATSensors.Find(id);
            db.tblATSensors.Remove(tblATSensor);
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
