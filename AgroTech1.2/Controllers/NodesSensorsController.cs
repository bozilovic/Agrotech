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
    public class NodesSensorsController : Controller
    {
        private AgroTechEntities db = new AgroTechEntities();

        // GET: NodesSensors
        public ActionResult Index()
        {
            return View(db.viATNodesSensors.ToList());
        }


    }
}
