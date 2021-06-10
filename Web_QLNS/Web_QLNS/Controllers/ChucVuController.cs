using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_QLNS.Models;

namespace Web_QLNS.Controllers
{
    public class ChucVuController : Controller
    {
        private readonly QLNSContext database;
        public ChucVuController(QLNSContext db)
        {
            database = db;
        }

        // GET: ChucVuController
        public ActionResult Index()
        {
            var model = new ViewModelNV();
            model.ListChucVu = database.ChucVus.ToArray();
            return View(model);
        }

        // GET: ChucVuController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ChucVuController/Create
        public ActionResult Create()
        {
            var model = new ChucVu();

            return View(model);
        }

        // POST: ChucVuController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ChucVu chucVu)
        {
            if (ModelState.IsValid)
            {
                database.Add(chucVu);
                database.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(chucVu);
        }

        // GET: ChucVuController/Edit/5
        public ActionResult Edit(int id)
        {
            var model = new ChucVu();
            model = database.ChucVus.Where(x => x.Idcv == id).FirstOrDefault();
            return View(model);
        }

        // POST: ChucVuController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ChucVu chucVu)
        {
            var model = chucVu;            
            if (ModelState.IsValid)
            {
                database.Update(model);
                database.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: ChucVuController/Delete/5
        public ActionResult Delete(int id)
        {
            var model = new ChucVu();
            model = database.ChucVus.Where(x => x.Idcv == id).FirstOrDefault();
            return View(model);
        }

        // POST: ChucVuController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ChucVu chucVu)
        {
            chucVu = database.ChucVus.Where(x => x.Idcv == id).FirstOrDefault();
            database.Remove(chucVu);
            database.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
