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
    public class NodeDatasController : Controller
    {
        private AgroTechEntities db = new AgroTechEntities();

        // GET: NodeDatas
        public ActionResult Index()
        {
            ViewBag.node = new SelectList(db.tblATNodes, "node_id", "node_name");
            ViewBag.sensor = new SelectList(db.tblATSensors, "sensor_id", "sensor_type");

            return View();
        }

        public ActionResult SingleSensor(string node, string sensor)
        {
            return View(db.SingleSensorData(node, sensor).ToList());
        }

    }
}
