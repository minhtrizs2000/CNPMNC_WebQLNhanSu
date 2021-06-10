using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_QLNS.Models;

namespace Web_QLNS.Controllers
{
    public class LoaiKyLuatController : Controller
    {
        private readonly QLNSContext database;
        private readonly IWebHostEnvironment hostEnvironment;

        public LoaiKyLuatController(QLNSContext db, IWebHostEnvironment hostEnvironment)
        {
            database = db;
            this.hostEnvironment = hostEnvironment;
        }

        //// GET: LoaiKyLuatController
        //public ActionResult Index()
        //{            
        //    return View();
        //}

        //// GET: LoaiKyLuatController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: LoaiKyLuatController/Create
        public ActionResult Create()
        {
            var model = new LoaiKyLuat();

            return View(model);
        }

        // POST: LoaiKyLuatController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LoaiKyLuat loaiKyLuat)
        {
            if (ModelState.IsValid)
            {
                database.Add(loaiKyLuat);
                database.SaveChanges();
                return RedirectToAction("Index","DanhGia");
            }
            return View(loaiKyLuat);
        }

        // GET: LoaiKyLuatController/Edit/5
        public ActionResult Edit(int id)
        {
            var model = new LoaiKyLuat();
            model = database.LoaiKyLuats.Where(x => x.IdloaiKl == id).FirstOrDefault();
            return View(model);
        }

        // POST: LoaiKyLuatController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LoaiKyLuat loaiKyLuat)
        {
            var model = loaiKyLuat;
            if (ModelState.IsValid)
            {
                database.Update(model);
                database.SaveChanges();
                return RedirectToAction("Index","DanhGia");
            }
            return View(model);
        }

        // GET: LoaiKyLuatController/Delete/5
        public ActionResult Delete(int id)
        {
            var model = new LoaiKyLuat();
            model = database.LoaiKyLuats.Where(x => x.IdloaiKl == id).FirstOrDefault();
            return View(model);
        }

        // POST: LoaiKyLuatController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, LoaiKyLuat loaiKyLuat)
        {
            loaiKyLuat = database.LoaiKyLuats.Where(x => x.IdloaiKl == id).FirstOrDefault();
            database.Remove(loaiKyLuat);
            database.SaveChanges();
            return RedirectToAction("Index","DanhGia");
        }
    }
}
