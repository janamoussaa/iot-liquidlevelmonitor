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
    public class acc_sensorsController : Controller
    {
        private iotEntities db = new iotEntities();

        // GET: acc_sensors
        public ActionResult Index()
        {
            return View(db.acc_sensors.ToList());
        }

        // GET: acc_sensors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            acc_sensors acc_sensors = db.acc_sensors.Find(id);
            if (acc_sensors == null)
            {
                return HttpNotFound();
            }
            return View(acc_sensors);
        }

        // GET: acc_sensors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: acc_sensors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "name,min_value,max_value")] acc_sensors acc_sensors)
        {
            if (ModelState.IsValid)
            {
                db.acc_sensors.Add(acc_sensors);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(acc_sensors);
        }

        // GET: acc_sensors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            acc_sensors acc_sensors = db.acc_sensors.Find(id);
            if (acc_sensors == null)
            {
                return HttpNotFound();
            }
            return View(acc_sensors);
        }

        // POST: acc_sensors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,min_value,max_value")] acc_sensors acc_sensors)
        {
            if (ModelState.IsValid)
            {
                db.Entry(acc_sensors).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(acc_sensors);
        }

        // GET: acc_sensors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            acc_sensors acc_sensors = db.acc_sensors.Find(id);
            if (acc_sensors == null)
            {
                return HttpNotFound();
            }
            return View(acc_sensors);
        }

        // POST: acc_sensors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            acc_sensors acc_sensors = db.acc_sensors.Find(id);
            db.acc_sensors.Remove(acc_sensors);
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
