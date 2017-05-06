using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WorldAttractions.DAL.Models.Information;

namespace WorldAttractions.Controllers
{
    public class DistrictsController : Controller
    {
        UnitOfWork unit = new UnitOfWork();
        // GET: Districts
       public ActionResult Index(int Id)
       {
            var District = unit.Districts.GetById(Id);
            return View(District);
        }
    }
}