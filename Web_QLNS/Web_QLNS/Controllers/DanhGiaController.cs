using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_QLNS.Models;
using X.PagedList;

namespace Web_QLNS.Controllers
{
    public class DanhGiaController : Controller
    {
        private readonly QLNSContext database;
        private readonly IWebHostEnvironment hostEnvironment;

        public DanhGiaController(QLNSContext db, IWebHostEnvironment hostEnvironment)
        {
            database = db;
            this.hostEnvironment = hostEnvironment;
        }

        // GET: DanhGiaController
        public ActionResult Index()
        {
            var model = new ViewModelDG();
            model.ListloaiKyLuat = database.LoaiKyLuats.ToArray();
            model.ListLoaikhenThuong = database.LoaiKhenThuongs.ToArray();
            return View(model);
        }

        // GET: DanhGiaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DanhGiaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DanhGiaController/Create
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

        // GET: DanhGiaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DanhGiaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: DanhGiaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DanhGiaController/Delete/5
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
    public class ViewModelDG
    {
        //Create Model to use Multiple Model in View        
        public NhanVien nhanVien { get; set; }
        public KyLuat kyLuat { get; set; }
        public Models.LoaiKyLuat loaiKyLuat { get; set; }
        public KhenThuong khenThuong { get; set; }
        public LoaiKhenThuong LoaikhenThuong { get; set; }
        public TaiKhoan taiKhoan { get; set; }

        public NhanVien[] ListNhanVien { get; set; }
        public KyLuat[] ListkyLuat { get; set; }
        public IPagedList<KyLuat> ListKyLuats { get; set; }
        public Models.LoaiKyLuat[] ListloaiKyLuat { get; set; }
        public KhenThuong[] ListkhenThuong { get; set; }
        public IPagedList<KhenThuong> ListKhenThuongs { get; set; }
        public LoaiKhenThuong[] ListLoaikhenThuong { get; set; }
    }
}
