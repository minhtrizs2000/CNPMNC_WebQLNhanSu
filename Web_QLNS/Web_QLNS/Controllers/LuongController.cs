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
    public class LuongController : Controller
    {
        private readonly QLNSContext database;
        private readonly IWebHostEnvironment hostEnvironment;

        public LuongController(QLNSContext db, IWebHostEnvironment hostEnvironment)
        {
            database = db;
            this.hostEnvironment = hostEnvironment;
        }

        // GET: LuongController
        public ActionResult Index()
        {
            var model = new ViewModelBL();
            model.ListNhanVien = database.NhanViens.ToArray();
            model.ListHopDongLaoDong = database.HopDongLaoDongs.ToArray();
            return View(model);
        }

        // GET: LuongController/Details/5
        public ActionResult Details(int id)
        {
            var model = new ViewModelBL();
            model.ListNhanVien = database.NhanViens.ToArray();
            model.ListPhongBan = database.PhongBans.ToArray();
            model.ListChucVu = database.ChucVus.ToArray();
            model.ListkyLuat = database.KyLuats.ToArray();
            model.ListloaiKyLuat = database.LoaiKyLuats.ToArray();
            model.ListkhenThuong = database.KhenThuongs.ToArray();
            model.ListLoaikhenThuong = database.LoaiKhenThuongs.ToArray();
            model.ListChamCong = database.ChamCongs.ToArray();
            model.ListHopDongLaoDong = database.HopDongLaoDongs.ToArray();
            model.nhanVien = database.NhanViens.Where(x => x.Idnv == id).FirstOrDefault();
            model.taiKhoan = database.TaiKhoans.Where(x => x.Idnv == id).FirstOrDefault();

            HttpContext.Session.SetString("IDNV", model.nhanVien.Idnv.ToString());
            return View(model);
        }

        public ActionResult DetailsQuanLy(int id)
        {
            var model = new ViewModelBL();
            model.ListNhanVien = database.NhanViens.ToArray();
            model.ListPhongBan = database.PhongBans.ToArray();
            model.ListChucVu = database.ChucVus.ToArray();
            model.ListkyLuat = database.KyLuats.ToArray();
            model.ListloaiKyLuat = database.LoaiKyLuats.ToArray();
            model.ListkhenThuong = database.KhenThuongs.ToArray();
            model.ListLoaikhenThuong = database.LoaiKhenThuongs.ToArray();
            model.ListChamCong = database.ChamCongs.ToArray();
            model.ListHopDongLaoDong = database.HopDongLaoDongs.ToArray();
            model.nhanVien = database.NhanViens.Where(x => x.Idnv == id).FirstOrDefault();
            model.taiKhoan = database.TaiKhoans.Where(x => x.Idnv == id).FirstOrDefault();

            HttpContext.Session.SetString("IDNV", model.nhanVien.Idnv.ToString());
            return View(model);
        }

        public ActionResult DetailsPhat(int id, int th)
        {
            var model = new ViewModelDG();
            model.ListNhanVien = database.NhanViens.ToArray();
            model.ListkyLuat = database.KyLuats.Where(x => x.Ngay.Value.Month == th && x.Idnv == id).ToArray();
            model.ListloaiKyLuat = database.LoaiKyLuats.ToArray();
            model.ListNhanVien = database.NhanViens.ToArray();
            model.nhanVien = database.NhanViens.Where(x => x.Idnv == id).FirstOrDefault();
            model.taiKhoan = database.TaiKhoans.Where(x => x.Idnv == id).FirstOrDefault();

            HttpContext.Session.SetString("IDNV", model.nhanVien.Idnv.ToString());
            return View(model);
        }

        public ActionResult DetailsThuong(int id, int th)
        {
            var model = new ViewModelDG();
            model.ListNhanVien = database.NhanViens.ToArray();
            model.ListkhenThuong = database.KhenThuongs.Where(x => x.Ngay.Value.Month == th && x.Idnv == id).ToArray();
            model.ListLoaikhenThuong = database.LoaiKhenThuongs.ToArray();
            model.ListNhanVien = database.NhanViens.ToArray();
            model.nhanVien = database.NhanViens.Where(x => x.Idnv == id).FirstOrDefault();
            model.taiKhoan = database.TaiKhoans.Where(x => x.Idnv == id).FirstOrDefault();

            HttpContext.Session.SetString("IDNV", model.nhanVien.Idnv.ToString());
            return View(model);
        }
        public ActionResult DetailsPhatQuanLy(int id, int th)
        {
            var model = new ViewModelDG();
            model.ListNhanVien = database.NhanViens.ToArray();
            model.ListkyLuat = database.KyLuats.Where(x => x.Ngay.Value.Month == th && x.Idnv == id).ToArray();
            model.ListloaiKyLuat = database.LoaiKyLuats.ToArray();
            model.ListNhanVien = database.NhanViens.ToArray();
            model.nhanVien = database.NhanViens.Where(x => x.Idnv == id).FirstOrDefault();
            model.taiKhoan = database.TaiKhoans.Where(x => x.Idnv == id).FirstOrDefault();

            HttpContext.Session.SetString("IDNV", model.nhanVien.Idnv.ToString());
            return View(model);
        }

        public ActionResult DetailsThuongQuanLy(int id, int th)
        {
            var model = new ViewModelDG();
            model.ListNhanVien = database.NhanViens.ToArray();
            model.ListkhenThuong = database.KhenThuongs.Where(x => x.Ngay.Value.Month == th && x.Idnv == id).ToArray();
            model.ListLoaikhenThuong = database.LoaiKhenThuongs.ToArray();
            model.ListNhanVien = database.NhanViens.ToArray();
            model.nhanVien = database.NhanViens.Where(x => x.Idnv == id).FirstOrDefault();
            model.taiKhoan = database.TaiKhoans.Where(x => x.Idnv == id).FirstOrDefault();

            HttpContext.Session.SetString("IDNV", model.nhanVien.Idnv.ToString());
            return View(model);
        }

        //// GET: LuongController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: LuongController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: LuongController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: LuongController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: LuongController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: LuongController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
    public class ViewModelBL
    {
        //Create Model to use Multiple Model in View
        public PhongBan phongBan { get; set; }
        public ChucVu chuVu { get; set; }
        public NhanVien nhanVien { get; set; }
        public HopDongLaoDong hopDongLaoDong { get; set; }
        public ChamCong chamCong { get; set; }
        public KyLuat kyLuat { get; set; }
        public Models.LoaiKyLuat loaiKyLuat { get; set; }
        public KhenThuong khenThuong { get; set; }
        public LoaiKhenThuong LoaikhenThuong { get; set; }

        public NhanVien[] ListNhanVien { get; set; }
        public PhongBan[] ListPhongBan { get; set; }
        public ChucVu[] ListChucVu { get; set; }
        public HopDongLaoDong[] ListHopDongLaoDong { get; set; }
        public ChamCong[] ListChamCong { get; set; }
        public KyLuat[] ListkyLuat { get; set; }
        public Models.LoaiKyLuat[] ListloaiKyLuat { get; set; }
        public KhenThuong[] ListkhenThuong { get; set; }
        public LoaiKhenThuong[] ListLoaikhenThuong { get; set; }
        public TaiKhoan taiKhoan { get; set; }
    }
}
