using System.Web.Mvc;

namespace layoutadmin.Controllers
{
    public class QuyDoiGVController : Controller
    {
        // GET: QuyDoiGV
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