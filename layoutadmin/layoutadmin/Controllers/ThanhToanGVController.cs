using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace layoutadmin.Controllers
{
    public class ThanhToanGVController : Controller
    {
        // GET: ThanhToanGV
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            return View();
        }
    }
}