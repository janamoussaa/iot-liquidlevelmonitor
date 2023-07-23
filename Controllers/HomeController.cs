using Newtonsoft.Json;
using UETV.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Http.Cors;

namespace UETV.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class HomeController : Controller
    {
      
        public  ActionResult Index()
        {
            ViewBag.Title = "Home Page";
      
            return View();
        }
        public ActionResult RoleChain()
        {
            ViewBag.Title = "Rule Chain Page Iframe";

            return View();
        }
    }
}
