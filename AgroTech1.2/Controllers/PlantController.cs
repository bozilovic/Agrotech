using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AgroTech1._2.Models;

namespace AgroTech1._2.Controllers
{
    public class PlantController : Controller
    {
        private AgroTechEntities db = new AgroTechEntities();

        // GET: Plant
        public ActionResult Index()
        {
            var tblATPlants = db.tblATPlants.Include(t => t.tblATNode);
            return View(tblATPlants.ToList());
        }

        // GET: Plant/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblATPlant tblATPlant = db.tblATPlants.Find(id);
            if (tblATPlant == null)
            {
                return HttpNotFound();
            }
            return View(tblATPlant);
        }

        // GET: Plant/Create
        public ActionResult Create()
        {
            ViewBag.node_id = new SelectList(db.tblATNodes, "node_id", "node_name");
            return View();
        }

        // POST: Plant/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "plant_id,plant_name,node_id,details")] tblATPlant tblATPlant, HttpPostedFileBase img)
        {

            String FileExt = Path.GetExtension(img.FileName).ToUpper();
            if (FileExt == ".JPG" || FileExt == ".JPEG" || FileExt == ".PNG")
            {

                byte[] bytes;

                using (BinaryReader br = new BinaryReader(img.InputStream))
                {
                    bytes = br.ReadBytes(img.ContentLength);
                }

                tblATPlant.img = bytes;

                if (ModelState.IsValid)
                {

                    db.tblATPlants.Add(tblATPlant);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.node_id = new SelectList(db.tblATNodes, "node_id", "node_name", tblATPlant.node_id);
                return View(tblATPlant);
            }

            else
            {
                ViewBag.FileStatus = "Invalid file format.";
                ViewBag.node_id = new SelectList(db.tblATNodes, "node_id", "node_name");
                return View();
            }
        }

        // GET: Plant/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblATPlant tblATPlant = db.tblATPlants.Find(id);
            if (tblATPlant == null)
            {
                return HttpNotFound();
            }
            ViewBag.node_id = new SelectList(db.tblATNodes, "node_id", "node_name", tblATPlant.node_id);
            return View(tblATPlant);
        }

        // POST: Plant/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "plant_id,plant_name,node_id,img,details")] tblATPlant tblATPlant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblATPlant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.node_id = new SelectList(db.tblATNodes, "node_id", "node_name", tblATPlant.node_id);
            return View(tblATPlant);
        }

        // GET: Plant/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblATPlant tblATPlant = db.tblATPlants.Find(id);
            if (tblATPlant == null)
            {
                return HttpNotFound();
            }
            return View(tblATPlant);
        }

        // POST: Plant/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            tblATPlant tblATPlant = db.tblATPlants.Find(id);
            db.tblATPlants.Remove(tblATPlant);
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
