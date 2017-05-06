using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WorldAttractions.DAL.EF;
using WorldAttractions.DAL.Models.Information;
using WorldAttractions.DAL.Models.Showplace;

namespace WorldAttractions.Controllers
{
    public class MonumentsController : Controller
    {
        UnitOfWork unit = new UnitOfWork();
        // GET: Monuments
        public ActionResult Index()
        {
            return View(unit.Monuments.GetAll());
        }
        // GET: Monuments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Monument monument = unit.Monuments.GetById(id);
            if (monument == null)
            {
                return HttpNotFound();
            }
            return View(monument);
        }
        // GET: Monuments/Create
        public ActionResult Create()
        {
            ViewBag.Cities = new SelectList(unit.Cities.GetAll(), "Id", "Name");
            return View();
        }
        // POST: Monuments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Moderator")]
        public ActionResult Create(Monument monument, IEnumerable<HttpPostedFileBase> uploads)
        {



            if (ModelState.IsValid)
            {
                if (uploads != null)
                {
                    foreach (var file in uploads)
                    {
                        if (file != null)
                        {
                            // получаем имя файла
                            string fileName = System.IO.Path.GetFileName(file.FileName);
                            // сохраняем файл в папку Files в проекте
                            try
                            {
                                file.SaveAs(Server.MapPath("~/Files/" + fileName));
                                unit.Pictures.Create(new Picture("/Images/" + fileName, monument));

                            }
                            catch
                            {
                                unit.Pictures.Create(new Picture("/Images/" + fileName, monument));

                            }

                        }
                    }
                }
                monument.City = unit.Cities.GetById(monument.IdCity);
                unit.Monuments.Create(monument);
                unit.Save();
                return RedirectToAction("Index");
            }

            return View(monument);
        }

        // GET: Monuments/Edit/5
        [Authorize(Roles = "Admin,Moderator")]
        public ActionResult Edit(int? id)
        {
            ViewBag.Cities = new SelectList(unit.Cities.GetAll(), "Id", "Name");

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Monument monument = unit.Monuments.GetById(id);//db.Monuments.Find(id);
            if (monument == null)
            {
                return HttpNotFound();
            }
            return View(monument);
        }

        // POST: Monuments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Moderator")]
        public ActionResult Edit(Monument monument)
        {

            if (ModelState.IsValid)
            {
                
                
                
                monument.City = unit.Cities.GetById(monument.IdCity);
                unit.Cities.Update(monument.City);
                unit.Monuments.Update(monument);
         
                unit.Save();
                return RedirectToAction("Index");
            }
            return View(monument);
        }
        // GET: Monuments/Delete/5
        [Authorize(Roles = "Admin,Moderator")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Monument monument = unit.Monuments.GetById(id);
            if (monument == null)
            {
                return HttpNotFound();
            }
            return View(monument);
        }

        // POST: Monuments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Moderator")]
        public ActionResult DeleteConfirmed(int id)
        {
            Monument monument = unit.Monuments.GetById(id);

            monument.Pictures.Clear();
            unit.Monuments.Delete(monument.Id);
            foreach (var pict in unit.Pictures.GetAll())
            {
                if (pict.MonumentID == null)
                {
                    unit.Pictures.Delete(pict.Id);
                }
            }
            unit.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                unit.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
