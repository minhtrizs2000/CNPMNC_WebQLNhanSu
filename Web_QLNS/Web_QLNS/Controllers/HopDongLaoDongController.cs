using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_QLNS.Models;

namespace Web_QLNS.Controllers
{
    public class HopDongLaoDongController : Controller
    {
        private readonly QLNSContext database;
        public HopDongLaoDongController(QLNSContext db)
        {
            database = db;
        }

        // GET: HopDongLaoDongController
        public ActionResult Index()
        {
            var model = new ViewModelNV();
            model.ListNhanVien = database.NhanViens.ToArray();
            model.ListHopDongLaoDong = database.HopDongLaoDongs.ToArray();
            return View(model);
        }

        // GET: HopDongLaoDongController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HopDongLaoDongController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HopDongLaoDongController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HopDongLaoDongController/Edit/5
        public ActionResult Edit(int id)
        {
            var model = new ViewModelNV();
            model.ListNhanVien = database.NhanViens.ToArray();
            model.ListHopDongLaoDong = database.HopDongLaoDongs.ToArray();
            model.hopDongLaoDong = database.HopDongLaoDongs.Where(x => x.Idnv == id).FirstOrDefault();
            return View(model);
        }

        // POST: HopDongLaoDongController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(HopDongLaoDong hopDongLaoDong)
        {
            var model = new ViewModelNV();
            model.ListNhanVien = database.NhanViens.ToArray();            
            //model.hopDongLaoDong = database.HopDongLaoDongs.Where(x => x.Idnv == id).FirstOrDefault();
            if (ModelState.IsValid)
            {
                database.Update(hopDongLaoDong);
                database.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: HopDongLaoDongController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HopDongLaoDongController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
