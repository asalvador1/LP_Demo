using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Web;
using System.Web.Mvc;
using System.Collections;

namespace PruebaMvcExt.Controllers
{
    public class HomeController : BaseController
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Main()
        {
            return View();
        }

        public JsonResult List(int limit, int start, string dir, string sort)
        {
           
           
           List<SelectListItem> tempColl = new List<SelectListItem>();
            Random r = new Random(1);
            for (int i = 1; i <= 100; i++)
            {
               var value = r.Next(1000);
                //var value = i;
                tempColl.Add(new SelectListItem{ Text = "Elemento " + value.ToString(), Value = value.ToString()});
            }
            int count = tempColl.Count;
           if (!String.IsNullOrEmpty(sort))
                tempColl = tempColl.AsQueryable().OrderBy(sort + " " + dir).ToList();
            tempColl = tempColl.Skip(start).Take(limit).ToList() ;

           ViewData["total"] = count;
           Hashtable result = new Hashtable();
           result["Total"] = count;
           result["Rows"] = tempColl;
            return this.Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}
