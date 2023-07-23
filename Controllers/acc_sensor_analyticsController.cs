using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UETV.Models;

namespace UETV.Controllers
{
    public  class Prdections{
        public string name { get; set; }
        public string minValue { get; set; }
        public string maxValue { get; set; }
        public string averageValue { get; set; }
        public string numberOfReadings { get; set; }
    }
    public class acc_sensor_analyticsController : Controller
    {
        private iotEntities db = new iotEntities();
        public ActionResult Index( DateTime? dFrom, DateTime? dTo)
        {
            var readings = db.acc_sensor_analytics.OrderByDescending(v=>v.creationTime).ToList();

            if (dFrom!=null && dTo != null)
                readings = readings.Where(v => v.creationTime > dFrom && v.creationTime < dTo).OrderByDescending(c=>c.id).ToList();
            return View(readings.ToList());
        }
        public ActionResult Predictions(DateTime? dFrom, DateTime? dTo)
        {
            List<Prdections> predects = new List<Prdections>();
            var sensors = db.acc_sensors.ToList();
            List<acc_sensor_analytics> readings = new List<acc_sensor_analytics>();

            if (dFrom == null && dTo == null)
                readings = db.acc_sensor_analytics.ToList();
            else if (dFrom != null && dTo != null)
                readings = readings.Where(v => v.creationTime > dFrom && v.creationTime < dTo).OrderByDescending(c => c.id).ToList();
            readings = readings.Count() > 0 ? readings : new List<acc_sensor_analytics>();
            foreach (acc_sensors sen in sensors) {
                Prdections obj = new Prdections();
                obj.averageValue = readings.Where(c => c.sensor_id == sen.id).Count() == 0 ? "No Result Could be predicted" :
                    readings.Where(c => c.sensor_id == sen.id).Average(c => c.value) > 0 ?
                    readings.Where(c => c.sensor_id == sen.id).Average(c => c.value).ToString() : "0";

                obj.minValue = readings.Where(c => c.sensor_id == sen.id).Count()==0?"No Result Could be predicted":
                    readings.Where(c => c.sensor_id == sen.id).Min(c => c.value) > 0 ?
                    readings.Where(c => c.sensor_id == sen.id).Min(c => c.value).ToString(): "0";
                obj.maxValue = readings.Where(c => c.sensor_id == sen.id).Count()==0? "No Result Could be predicted"
                    : readings.Where(c => c.sensor_id == sen.id).Max(c => c.value)>0?
                     readings.Where(c => c.sensor_id == sen.id).Max(c => c.value).ToString(): "0";
                obj.numberOfReadings = readings.Where(c => c.sensor_id == sen.id).Count().ToString();

                obj.name = sen.name;
                predects.Add(obj);
            }
            
            return View(predects.ToList());
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
