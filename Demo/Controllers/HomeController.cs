using Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Demo.Controllers
{
    public class HomeController : Controller
    {
        private SampleEntities db = new SampleEntities();

        public ActionResult Index()
        {
            var model = new PizzaTypeViewModel();

            model.PizzaTypesList = GetPizzaTypes();

            return View(model);
        }

        public IEnumerable<SelectListItem> GetPizzaTypes()
        {
            IEnumerable<SelectListItem> typeList = from type
                                                   in db.PizzaTypes
                                                   select new SelectListItem() { Text = type.Name, Value = type.Id.ToString() };

            return typeList;
        }

        public JsonResult GetPizza(string pizzaType)
        {
            List<PizzaData> aHeatmapDataPoints;

            if (!String.IsNullOrEmpty(pizzaType))
            {
                int pizzaTypeId = int.Parse(pizzaType);

                aHeatmapDataPoints = db.PizzaDatas.Where(f => f.pizzaTypeId == pizzaTypeId).ToList();
            }
            else
            {
                aHeatmapDataPoints = db.PizzaDatas.ToList();

            }

            if (aHeatmapDataPoints != null && aHeatmapDataPoints.Any())
            {
                return Json(new
                {
                    success = true,
                    data_points = aHeatmapDataPoints
                }, JsonRequestBehavior.AllowGet);

            }
            else
            {
                return Json(new
                {
                    success = false
                }, JsonRequestBehavior.AllowGet);
            }


        }
    }
}