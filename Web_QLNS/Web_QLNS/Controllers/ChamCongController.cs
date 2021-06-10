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
    public class ChamCongController : Controller
    {
        private readonly QLNSContext database;
        private readonly IWebHostEnvironment hostEnvironment;

        public ChamCongController(QLNSContext db, IWebHostEnvironment hostEnvironment)
        {
            database = db;
            this.hostEnvironment = hostEnvironment;
        }

        // GET: ChamCongController
        public ActionResult Index(int id)
        {
            var model = new ViewModelCC();
            model.ListChamCong = database.ChamCongs.ToArray();
            model.ListNhanVien = database.NhanViens.ToArray();
            model.nhanVien = database.NhanViens.Where(x => x.Idnv == id).FirstOrDefault();

            return View(model);
        }

        // GET: ChamCongController/Details/5
        public ActionResult Details(int id)
        {
            var model = new ViewModelCC();
            model.nhanVien = database.NhanViens.Where(x => x.Idnv == id).FirstOrDefault();
            model.ListChamCong = database.ChamCongs.ToArray();
            model.taiKhoan = database.TaiKhoans.Where(x => x.Idnv == id).FirstOrDefault();

            HttpContext.Session.SetString("IDNV", model.nhanVien.Idnv.ToString());
            return View(model);
        }

        // GET: ChamCongController/Create
        public ActionResult Create()
        {
            var model = new ViewModelCC();            
            model.ListNhanVien = database.NhanViens.ToArray();
            return View(model);
        }

        // POST: ChamCongController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ChamCong chamCong, KyLuat kyLuat)
        {
            var model = new ViewModelCC();
            model.ListNhanVien = database.NhanViens.ToArray();
            model.ListloaiKyLuat = database.LoaiKyLuats.ToArray();
            if (ModelState.IsValid)
            {
                chamCong.Idnv = int.Parse(HttpContext.Session.GetString("IDNV"));
                chamCong.Ngay = DateTime.Now;
                chamCong.TrangThai = true;
                database.Add(chamCong);
                await database.SaveChangesAsync();

                if(chamCong.Ngay.Hour > 7 || chamCong.Ngay.Hour == 7 && chamCong.Ngay.Minute >= 1)
                {
                    kyLuat.Idnv = int.Parse(HttpContext.Session.GetString("IDNV"));
                    kyLuat.IdloaiKl = 2;
                    kyLuat.Ngay = DateTime.Now;

                    database.Add(kyLuat);
                    await database.SaveChangesAsync();
                }

                return RedirectToAction("Index","ChamCong");
            }
            return View(model);
        }

        // GET: ChamCongController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ChamCongController/Edit/5
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

        // GET: ChamCongController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ChamCongController/Delete/5
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
    public class ViewModelCC
    {               
        //Create Model to use Multiple Model in View        
        public NhanVien nhanVien { get; set; }
        public ChamCong chamCong { get; set; }
        public KyLuat kyLuat { get; set; }
        public Models.LoaiKyLuat loaiKyLuat { get; set; }
        public KhenThuong khenThuong { get; set; }
        public LoaiKhenThuong LoaikhenThuong { get; set; }
        public NhanVien[] ListNhanVien { get; set; }
        public ChamCong[] ListChamCong { get; set; }
        public KyLuat[] ListkyLuat { get; set; }
        public Models.LoaiKyLuat[] ListloaiKyLuat { get; set; }
        public KhenThuong[] ListkhenThuong { get; set; }
        public LoaiKhenThuong[] ListLoaikhenThuong { get; set; }
        public TaiKhoan taiKhoan { get; set; }
        
        //public IPagedList<NhanVien> ListNhanViens { get; set; }  
    }
}
