using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UETV.Models;
namespace UETV.Controllers
{
    
    public class acc_ultrasonic_guiController : Controller
    {
        iotEntities db = new iotEntities();
        // GET: acc_ultrasonic_gui
        public ActionResult Index()
        {
            return View(db.acc_sensors.ToList());
        }

       
  
    }
}
