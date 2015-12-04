using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GoogleCharts_with_MVC4.Repo;

namespace GoogleCharts_with_MVC4.Controllers
{
    public class DisplaychartsController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Piechart()
        {
            mydataservice objMD = new mydataservice();

            var chartsdata = objMD.GetChartData(); // calling method Listdata

            return Json(chartsdata, JsonRequestBehavior.AllowGet); // returning list from here.
        }
    }
}
