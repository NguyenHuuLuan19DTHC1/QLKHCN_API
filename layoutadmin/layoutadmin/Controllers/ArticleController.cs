using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace layoutadmin.Controllers
{
    public class ArticleController : Controller
    {
        // GET: Article
        public ActionResult GV_Page()
        {
            return View();
        }

        public ActionResult DeTai()
        {
            return View();
        }

        public ActionResult ThongTin()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
    }
}