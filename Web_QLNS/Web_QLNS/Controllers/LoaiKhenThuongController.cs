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
    public class LoaiKhenThuongController : Controller
    {
        private readonly QLNSContext database;
        private readonly IWebHostEnvironment hostEnvironment;

        public LoaiKhenThuongController(QLNSContext db, IWebHostEnvironment hostEnvironment)
        {
            database = db;
            this.hostEnvironment = hostEnvironment;
        }

        //// GET: LoaiKhenThuongController
        //public ActionResult Index()
        //{
        //    return View();
        //}

        //// GET: LoaiKhenThuongController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: LoaiKhenThuongController/Create
        public ActionResult Create()
        {
            var model = new LoaiKhenThuong();

            return View(model);
        }

        // POST: LoaiKhenThuongController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LoaiKhenThuong loaiKhenThuong)
        {
            if (ModelState.IsValid)
            {
                database.Add(loaiKhenThuong);
                database.SaveChanges();
                return RedirectToAction("Index", "DanhGia");
            }
            return View(loaiKhenThuong);
        }

        // GET: LoaiKhenThuongController/Edit/5
        public ActionResult Edit(int id)
        {
            var model = new LoaiKhenThuong();
            model = database.LoaiKhenThuongs.Where(x => x.IdloaiKt == id).FirstOrDefault();
            return View(model);
        }

        // POST: LoaiKhenThuongController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LoaiKhenThuong loaiKhenThuong)
        {
            var model = loaiKhenThuong;
            if (ModelState.IsValid)
            {
                database.Update(model);
                database.SaveChanges();
                return RedirectToAction("Index", "DanhGia");
            }
            return View(model);
        }

        // GET: LoaiKhenThuongController/Delete/5
        public ActionResult Delete(int id)
        {
            var model = new LoaiKhenThuong();
            model = database.LoaiKhenThuongs.Where(x => x.IdloaiKt == id).FirstOrDefault();
            return View(model);
        }

        // POST: LoaiKhenThuongController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, LoaiKhenThuong loaiKhenThuong)
        {
            loaiKhenThuong = database.LoaiKhenThuongs.Where(x => x.IdloaiKt == id).FirstOrDefault();
            database.Remove(loaiKhenThuong);
            database.SaveChanges();
            return RedirectToAction("Index", "DanhGia");
        }
    }
}
