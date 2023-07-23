using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using VechileFleetManagementSystem.Models;

namespace VechileFleetManagementSystem.Controllers
{
    public class fleet_finesController : fleet_LanguageController
    {
        private ahmedEntities db = new ahmedEntities();


        private List<int> GetUserTree()
        {
            List<int> AllSubUsers = new List<int>();
            int CurrUser = Convert.ToInt32(HttpContext.Session["Id"]);
            AllSubUsers.Add(CurrUser);

            // Get 1st Line SubUsers
            foreach (users us in db.users.Where(d => d.parentID.Value == CurrUser))
            {
                if (us != null)
                    AllSubUsers.Add(us.id);
            }
            // Get 2nd Line SubUsers
            foreach (users us in db.users.Where(d => AllSubUsers.Contains(d.parentID.Value)))
            {
                if (us != null)
                    AllSubUsers.Add(us.id);
            }
            // Get 3rd Line SubUsers
            foreach (users us in db.users.Where(d => AllSubUsers.Contains(d.parentID.Value)))
            {
                if (us != null)
                    AllSubUsers.Add(us.id);
            }
            // Get 4th Line SubUsers
            foreach (users us in db.users.Where(d => AllSubUsers.Contains(d.parentID.Value)))
            {
                if (us != null)
                    AllSubUsers.Add(us.id);
            }
            // Get 5th Line SubUsers
            foreach (users us in db.users.Where(d => AllSubUsers.Contains(d.parentID.Value)))
            {
                if (us != null)
                    AllSubUsers.Add(us.id);
            }
            // Get 6th Line SubUsers
            foreach (users us in db.users.Where(d => AllSubUsers.Contains(d.parentID.Value)))
            {
                if (us != null)
                    AllSubUsers.Add(us.id);
            }
            // Get 7th Line SubUsers
            foreach (users us in db.users.Where(d => AllSubUsers.Contains(d.parentID.Value)))
            {
                if (us != null)
                    AllSubUsers.Add(us.id);
            }
            // Get 8th Line SubUsers
            foreach (users us in db.users.Where(d => AllSubUsers.Contains(d.parentID.Value)))
            {
                if (us != null)
                    AllSubUsers.Add(us.id);
            }
            // Get 10th Line SubUsers
            foreach (users us in db.users.Where(d => AllSubUsers.Contains(d.parentID.Value)))
            {
                if (us != null)
                    AllSubUsers.Add(us.id);
            }
            return AllSubUsers.Distinct().ToList();
        }

        public ActionResult Index(string sortOrder, string currentFilter, int? fils, string filBy, string searchString, int? page)
        {
            string parent = HttpContext.Session["Parent"].ToString();
            ViewBag.parent = HttpContext.Session["Parent"].ToString();

            ViewBag.vechSortParm = String.IsNullOrEmpty(sortOrder) ? "vech_desc" : "";
            ViewBag.drvSortParm = String.IsNullOrEmpty(sortOrder) ? "drv_desc" : "";
            ViewBag.resSortParm = String.IsNullOrEmpty(sortOrder) ? "res_desc" : "";
            ViewBag.costSortParm = String.IsNullOrEmpty(sortOrder) ? "cost_desc" : "";
            ViewBag.curSortParm = String.IsNullOrEmpty(sortOrder) ? "cur_desc" : "";
            ViewBag.paidSortParm = String.IsNullOrEmpty(sortOrder) ? "paid_desc" : "";
            ViewBag.timeSortParm = String.IsNullOrEmpty(sortOrder) ? "ftime_desc" : "";
            ViewBag.CurrentSort = sortOrder;
            List<int> AllSubUser = GetUserTree();
            List<string> AllSub_User = AllSubUser.ConvertAll<string>(delegate (int i) { return i.ToString(); });
            ViewBag.AllSub_User = AllSub_User;
            var Fines = db.fleet_fines.Where(f=> AllSub_User.Contains(f.parent)).AsQueryable();

            if (!String.IsNullOrEmpty(filBy) && fils != null)
            {
                if (filBy == "vech")
                    Fines = Fines.Where(c => c.VechileId == fils).AsQueryable();
                else if(filBy=="drv")
                    Fines = Fines.Where(c => c.DriverId == fils).AsQueryable();
                page = page ?? 1;
            }
            else
            {
                searchString = currentFilter;
            }
            switch (sortOrder)
            {
                case "vech_desc":
                    Fines = Fines.OrderByDescending(s => s.VechileId);
                    break;
                case "drv_desc":
                    Fines = Fines.OrderByDescending(s => s.DriverId);
                    break;
                case "res_desc":
                    Fines = Fines.OrderByDescending(s => s.Reson);
                    break;
                case "cost_desc":
                    Fines = Fines.OrderByDescending(s => s.Cost);
                    break;
                case "cur_desc":
                    Fines = Fines.OrderByDescending(s => s.CurrencyId);
                    break;
                case "paid_desc":
                    Fines = Fines.OrderByDescending(s => s.IsPaid);
                    break;
                case "ftime_desc":
                    Fines = Fines.OrderByDescending(s => s.FineTime);
                    break;
                default:
                    Fines = Fines.OrderByDescending(s => s.VechileId);
                    break;
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(Fines.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult Details(long? id)
        {
            List<int> AllSubUser = GetUserTree();
            List<string> AllSub_User = AllSubUser.ConvertAll<string>(delegate (int i) { return i.ToString(); });
            string parent = HttpContext.Session["Parent"].ToString();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fleet_fines fleet_fines = db.fleet_fines.Where(f=>f.id==id).FirstOrDefault();
            if (fleet_fines == null || !AllSub_User.Contains(fleet_fines.parent))
            {
                return HttpNotFound();
            }
            return View(fleet_fines);
        }

        public ActionResult Create()
        {
            List<int> AllSubUser = GetUserTree();
            List<string> AllSub_User = AllSubUser.ConvertAll<string>(delegate (int i) { return i.ToString(); });
            string parent = HttpContext.Session["Parent"].ToString();

            ViewBag.VechileId = new SelectList(db.device.Where(d=> AllSubUser.Contains(d.parent)), "id", "name");
            ViewBag.CurrencyId = new SelectList(db.fleet_currency.Where(c=>c.IsActive==true && c.IsDeleted==false && AllSub_User.Contains(c.parent)),"Id","name");
            ViewBag.DriverId = new SelectList(db.driver.Where(d=> AllSub_User.Contains(d.user)),"id","name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Reson,FineTime,VechileId,DriverId,Cost,CurrencyId,IsActive,IsDeleted,IsPaid")] fleet_fines fleet_fines)
        {
            List<int> AllSubUser = GetUserTree();
            List<string> AllSub_User = AllSubUser.ConvertAll<string>(delegate (int i) { return i.ToString(); });
            string parent = HttpContext.Session["Parent"].ToString();
            string tz= HttpContext.Session["Time_Zone"].ToString();
            string Id = HttpContext.Session["Id"].ToString();

            if (ModelState.IsValid)
            {
                fleet_fines.CreationTime = DateTime.Now.AddHours(Convert.ToDouble(tz));
                fleet_fines.CreatorId =Convert.ToInt32(Id);
                fleet_fines.parent = parent;
                db.fleet_fines.Add(fleet_fines);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.VechileId = new SelectList(db.device.Where(d => AllSubUser.Contains(d.parent)), "id", "name");
            ViewBag.CurrencyId = new SelectList(db.fleet_currency.Where(c => c.IsActive == true && c.IsDeleted == false && AllSub_User.Contains(c.parent)), "Id", "name");
            ViewBag.DriverId = new SelectList(db.driver.Where(d => AllSub_User.Contains(d.user)), "id", "name");
            return View(fleet_fines);
        }

        public ActionResult Edit(long? id)
        {
            List<int> AllSubUser = GetUserTree();
            List<string> AllSub_User = AllSubUser.ConvertAll<string>(delegate (int i) { return i.ToString(); });
            string parent = HttpContext.Session["Parent"].ToString();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fleet_fines fleet_fines = db.fleet_fines.Where(f=>f.id==id).FirstOrDefault();
            if (fleet_fines == null || !AllSub_User.Contains(fleet_fines.parent))
            {
                return HttpNotFound();
            }
            if (fleet_fines.DriverId != null && db.driver.Where(d=>d.id==fleet_fines.DriverId).FirstOrDefault()==null)
            {
                return RedirectToAction("Index");
            }
            ViewBag.VechileId = new SelectList(db.device.Where(d=> AllSubUser.Contains(d.parent)), "id", "name",fleet_fines.VechileId);
            ViewBag.CurrencyId = new SelectList(db.fleet_currency.Where(c => c.IsActive == true && c.IsDeleted == false && AllSub_User.Contains(c.parent)), "Id", "name",fleet_fines.CurrencyId);
            ViewBag.DriverId = new SelectList(db.driver.Where(d=> AllSub_User.Contains(d.user)), "id", "name",fleet_fines.DriverId);
            return View(fleet_fines);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Reson,FineTime,VechileId,DriverId,Cost,CurrencyId,CreatorId,CreationTime,IsActive,IsDeleted,IsPaid,parent")] fleet_fines fleet_fines)
        {
            List<int> AllSubUser = GetUserTree();
            List<string> AllSub_User = AllSubUser.ConvertAll<string>(delegate (int i) { return i.ToString(); });
            string parent = HttpContext.Session["Parent"].ToString();
            string Id = HttpContext.Session["Id"].ToString();

            string tz = HttpContext.Session["Time_Zone"].ToString();

            if (ModelState.IsValid)
            {
                fleet_fines.ModifierId =Convert.ToInt32(Id);
                fleet_fines.ModificationTime = DateTime.Now.AddHours(Convert.ToDouble(tz));
                db.Entry(fleet_fines).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.VechileId = new SelectList(db.device.Where(d => AllSubUser.Contains(d.parent)), "id", "name", fleet_fines.VechileId);
            ViewBag.CurrencyId = new SelectList(db.fleet_currency.Where(c => c.IsActive == true && c.IsDeleted == false && AllSub_User.Contains(c.parent)), "Id", "name", fleet_fines.CurrencyId);
            ViewBag.DriverId = new SelectList(db.driver.Where(d => AllSub_User.Contains(d.user)), "id", "name", fleet_fines.DriverId);
            return View(fleet_fines);
        }
        /*
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fleet_fines fleet_fines = db.fleet_fines.Find(id);
            if (fleet_fines == null)
            {
                return HttpNotFound();
            }
            return View(fleet_fines);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            fleet_fines fleet_fines = db.fleet_fines.Find(id);
            db.fleet_fines.Remove(fleet_fines);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        */
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
