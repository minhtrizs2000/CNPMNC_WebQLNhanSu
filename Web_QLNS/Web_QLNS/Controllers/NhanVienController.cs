using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using Web_QLNS.Models;
using Microsoft.AspNetCore.Hosting;
using ReflectionIT.Mvc.Paging;
using X.PagedList;

namespace Web_QLNS.Controllers
{
    public class NhanVienController : Controller
    {
        private readonly QLNSContext database;
        private readonly IWebHostEnvironment hostEnvironment;

        public NhanVienController(QLNSContext db, IWebHostEnvironment hostEnvironment)
        {
            database = db;
            this.hostEnvironment = hostEnvironment;
        }

        // GET: NhanVienController
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            //A ViewBag property provides the view with the current sort order, because this must be included in 
            //  the paging links in order to keep the sort order the same while paging
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            ViewBag.Role = TempData["Role"];

            var ModelList = new List<NhanVien>();

            //ViewBag.CurrentFilter, provides the view with the current filter string.
            //he search string is changed when a value is entered in the text box and the submit button is pressed. In that case, the searchString parameter is not null.
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;


            using (var context = new QLNSContext())
            {
                var modelv = from s in context.NhanViens
                             select s;
                //Search and match data, if search string is not null or empty
                if (!String.IsNullOrEmpty(searchString))
                {
                    modelv = modelv.Where(s => s.Idnv.ToString().Contains(searchString)                                           
                                           || s.TenNv.Contains(searchString)
                                           || s.IdpbNavigation.TenPb.Contains(searchString)
                                           || s.IdcvNavigation.TenCv.Contains(searchString));
                }
                switch (sortOrder)
                {
                    case "name_desc":
                        ModelList = modelv.OrderByDescending(s => s.Idnv).ToList();
                        break;

                    default:
                        ModelList = modelv.OrderBy(s => s.Idnv).ToList();
                        break;
                }

            }
            //indicates the size of list
            int pageSize = 10;
            //set page to one is there is no value, ??  is called the null-coalescing operator.
            int pageNumber = (page ?? 1);
            //return the Model data with paged

            var model = new ViewModelNV();
            model.ListNhanViens = ModelList.ToPagedList(pageNumber, pageSize);
            model.ListPhongBan = database.PhongBans.ToArray();
            model.ListChucVu = database.ChucVus.ToArray();
            model.ListHopDongLaoDong = database.HopDongLaoDongs.ToArray();
            return View(model);
        }

        // GET: NhanVienController/Details/5
        public ActionResult Details(int id)
        {
            var model = new ViewModelNV();
            model.ListPhongBan = database.PhongBans.ToArray();
            model.ListChucVu = database.ChucVus.ToArray();
            model.ListHopDongLaoDong = database.HopDongLaoDongs.ToArray();
            model.nhanVien = database.NhanViens.Where(x => x.Idnv == id).FirstOrDefault();
            return View(model);
        }

        // GET: NhanVienController/Create
        public ActionResult Create()
        {
            var model = new ViewModelNV();
            model.ListPhongBan = database.PhongBans.ToArray();
            model.ListChucVu = database.ChucVus.ToArray();
            //model.ListHopDongLaoDong = database.HopDongLaoDongs.ToArray();
            return View(model);
        }

        // POST: NhanVienController/Create
        [HttpPost]        
        public async Task<ActionResult> Create(NhanVien nhanVien,HopDongLaoDong hopDongLaoDong, TaiKhoan taiKhoan)
        {
            var model = new ViewModelNV();
            model.ListPhongBan = database.PhongBans.ToArray();
            model.ListChucVu = database.ChucVus.ToArray();
            //model.ListHopDongLaoDong = database.HopDongLaoDongs.ToArray();
            if (ModelState.IsValid)
            {

                #region Save Image from wwwroot/img
                string wwwRootPath = hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(nhanVien.UploadHinh.FileName);

                string extension = Path.GetExtension(nhanVien.UploadHinh.FileName);

                nhanVien.HinhAnh = fileName += extension;

                string path = Path.Combine(wwwRootPath + "/img/", fileName);


                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await nhanVien.UploadHinh.CopyToAsync(fileStream);
                }
                #endregion

                nhanVien.TinhTrang = true;                
                database.Add(nhanVien);
                await database.SaveChangesAsync();

                hopDongLaoDong.Idnv = nhanVien.Idnv;
                database.Add(hopDongLaoDong);
                await database.SaveChangesAsync();

                taiKhoan.Idnv = nhanVien.Idnv;
                taiKhoan.Pass ="NV"+nhanVien.Idnv;
                database.Add(taiKhoan);
                await database.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: NhanVienController/Edit/5
        public ActionResult Edit(int id)
        {
            var model = new ViewModelNV();
            model.ListPhongBan = database.PhongBans.ToArray();
            model.ListChucVu = database.ChucVus.ToArray();
            model.ListHopDongLaoDong = database.HopDongLaoDongs.ToArray();
            model.nhanVien = database.NhanViens.Where(x => x.Idnv == id).FirstOrDefault();
            model.hopDongLaoDong = database.HopDongLaoDongs.Where(x => x.Idnv == id).FirstOrDefault();
            return View(model);
        }

        // POST: NhanVienController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, NhanVien nhanVien, HopDongLaoDong hopDongLaoDong)
        {
            var model = new ViewModelNV();
            model.ListPhongBan = database.PhongBans.ToArray();
            model.ListChucVu = database.ChucVus.ToArray();
            model.ListHopDongLaoDong = database.HopDongLaoDongs.ToArray();
            model.nhanVien = database.NhanViens.Where(x => x.Idnv == id).FirstOrDefault();
            model.hopDongLaoDong = database.HopDongLaoDongs.Where(x => x.Idnv == id).FirstOrDefault();
            if (nhanVien.TenNv != null && nhanVien.DienThoai.Length <= 12 && nhanVien.DiaChi !=null && nhanVien.Cmnd >= 100000000 && nhanVien.Cmnd<999999999 && nhanVien.NgaySinh.Value.Year<=(DateTime.Now.Year-18))
            {
                model.nhanVien.TenNv = nhanVien.TenNv;
                model.nhanVien.Idpb = nhanVien.Idpb;
                model.nhanVien.Idcv = nhanVien.Idcv;
                model.nhanVien.GioiTinh = nhanVien.GioiTinh;
                model.nhanVien.Cmnd = nhanVien.Cmnd;
                model.nhanVien.DiaChi = nhanVien.DiaChi;
                model.nhanVien.DienThoai = nhanVien.DienThoai;
                model.nhanVien.Email = nhanVien.Email;
                model.nhanVien.TinhTrang = nhanVien.TinhTrang;
                model.nhanVien.NgaySinh = nhanVien.NgaySinh;

                model.hopDongLaoDong.NgayKy = hopDongLaoDong.NgayKy;
                model.hopDongLaoDong.LuongCb = hopDongLaoDong.LuongCb;

                #region Save Image from wwwroot/img
                string wwwRootPath = hostEnvironment.WebRootPath;
                string fileName;
                string extension;
                if (nhanVien.UploadHinh != null)
                {
                    fileName = Path.GetFileNameWithoutExtension(nhanVien.UploadHinh.FileName);
                    extension = Path.GetExtension(nhanVien.UploadHinh.FileName);
                    model.nhanVien.HinhAnh = fileName += extension;
                    string path = Path.Combine(wwwRootPath + "/img/", fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await nhanVien.UploadHinh.CopyToAsync(fileStream);
                    }
                }                    
                #endregion

                //string wwwRootPath = hostEnvironment.WebRootPath;
                //string fileName1;
                //string extension1;
                //if (nhanVien.UploadHinh != null)
                //{
                //    fileName1 = Path.GetFileNameWithoutExtension(nhanVien.UploadHinh.FileName);
                //    extension1 = Path.GetExtension(nhanVien.UploadHinh.FileName);
                //    model.nhanVien.HinhAnh = "/img/" + fileName1 + extension1;
                //    string path1 = Path.Combine(wwwRootPath + "/img/", fileName1);
                //    using (var fileStream = new FileStream(path1, FileMode.Create))
                //    {
                //        await nhanVien.UploadHinh.CopyToAsync(fileStream);
                //    }
                //}
                database.Update(model.nhanVien);
                database.Update(model.hopDongLaoDong);
                await database.SaveChangesAsync();
                return RedirectToAction("Index", "NhanVien");
            }
            return View(model);
        }

        // GET: NhanVienController/Delete/5
        public ActionResult Delete(int id)
        {
            var model = new ViewModelNV();
            model.ListChucVu = database.ChucVus.ToArray();
            model.ListPhongBan = database.PhongBans.ToArray();
            model.ListHopDongLaoDong = database.HopDongLaoDongs.ToArray();
            model.nhanVien = database.NhanViens.Where(x => x.Idnv == id).FirstOrDefault();
            return View(model);
        }

        // POST: NhanVienController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, NhanVien nhanVien)
        {
            nhanVien = database.NhanViens.Where(x => x.Idnv == id).FirstOrDefault();
            database.Remove(nhanVien);
            database.SaveChanges();
            return RedirectToAction("Index");
        }
    }
    public class ViewModelNV
    {
        //Create Model to use Multiple Model in View
        public PhongBan phongBan { get; set; }
        public ChucVu chuVu { get; set; }
        public NhanVien nhanVien { get; set; }      
        public HopDongLaoDong hopDongLaoDong { get; set; }
        public NhanVien[] ListNhanVien { get; set; }
        public IPagedList<NhanVien> ListNhanViens { get; set; }
        public PhongBan[] ListPhongBan { get; set; }
        public ChucVu[] ListChucVu { get; set; }
        public HopDongLaoDong[] ListHopDongLaoDong { get; set; }
    }
}
