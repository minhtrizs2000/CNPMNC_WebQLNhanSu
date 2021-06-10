using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using ReflectionIT.Mvc.Paging;
using X.PagedList;
using System.Threading.Tasks;
using Web_QLNS.Models;

namespace Web_QLNS.Controllers
{
    public class KhenThuongController : Controller
    {
        private readonly QLNSContext database;
        private readonly IWebHostEnvironment hostEnvironment;

        public KhenThuongController(QLNSContext db, IWebHostEnvironment hostEnvironment)
        {
            database = db;
            this.hostEnvironment = hostEnvironment;
        }

        // GET: KhenThuongController
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            //A ViewBag property provides the view with the current sort order, because this must be included in 
            //  the paging links in order to keep the sort order the same while paging
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            ViewBag.Role = TempData["Role"];

            var ModelList = new List<KhenThuong>();

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
                var modelv = from s in context.KhenThuongs
                             select s;
                //Search and match data, if search string is not null or empty
                if (!String.IsNullOrEmpty(searchString))
                {
                    modelv = modelv.Where(s => s.Idkt.ToString().Contains(searchString)
                                           || s.IdnvNavigation.TenNv.Contains(searchString)
                                           || s.IdloaiKtNavigation.TenKt.Contains(searchString)
                                           || s.Ngay.Value.Month.ToString().Contains(searchString));
                }
                switch (sortOrder)
                {
                    case "name_desc":
                        ModelList = modelv.OrderByDescending(s => s.Idkt).ToList();
                        break;

                    default:
                        ModelList = modelv.OrderBy(s => s.Idkt).ToList();
                        break;
                }

            }
            //indicates the size of list
            int pageSize = 5;
            //set page to one is there is no value, ??  is called the null-coalescing operator.
            int pageNumber = (page ?? 1);
            //return the Model data with paged

            var model = new ViewModelDG();
            model.ListNhanVien = database.NhanViens.ToArray();
            model.ListKhenThuongs = ModelList.ToPagedList(pageNumber, pageSize);
            model.ListLoaikhenThuong = database.LoaiKhenThuongs.ToArray();
            return View(model);
        }

        //// GET: KhenThuongController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: KhenThuongController/Create
        public ActionResult Create()
        {
            var model = new ViewModelDG();
            model.ListNhanVien = database.NhanViens.ToArray();
            model.ListLoaikhenThuong = database.LoaiKhenThuongs.ToArray();
            return View(model);
        }

        // POST: KhenThuongController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(KhenThuong khenThuong)
        {
            var model = new ViewModelDG();
            model.ListNhanVien = database.NhanViens.ToArray();
            model.ListLoaikhenThuong = database.LoaiKhenThuongs.ToArray();
            if (ModelState.IsValid)
            {
                database.Add(khenThuong);
                await database.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: KhenThuongController/Edit/5
        public ActionResult Edit(int id)
        {
            var model = new ViewModelDG();
            model.ListNhanVien = database.NhanViens.ToArray();
            model.ListLoaikhenThuong = database.LoaiKhenThuongs.ToArray();
            model.khenThuong = database.KhenThuongs.Where(x => x.Idkt == id).FirstOrDefault();
            return View(model);
        }

        // POST: KhenThuongController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, KhenThuong khenThuong)
        {
            var model = new ViewModelDG();
            model.ListNhanVien = database.NhanViens.ToArray();
            model.ListLoaikhenThuong = database.LoaiKhenThuongs.ToArray();
            model.khenThuong = database.KhenThuongs.Where(x => x.Idkt == id).FirstOrDefault();
            if (ModelState.IsValid)
            {
                model.khenThuong.Idnv = khenThuong.Idnv;
                model.khenThuong.IdloaiKt = khenThuong.IdloaiKt;
                model.khenThuong.Ngay = khenThuong.Ngay;

                database.Update(model.khenThuong);
                await database.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: KhenThuongController/Delete/5
        public ActionResult Delete(int id)
        {
            var model = new ViewModelDG();
            model.ListNhanVien = database.NhanViens.ToArray();
            model.ListLoaikhenThuong = database.LoaiKhenThuongs.ToArray();
            model.khenThuong = database.KhenThuongs.Where(x => x.Idkt == id).FirstOrDefault();
            return View(model);
        }

        // POST: KhenThuongController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, KhenThuong khenThuong)
        {
            khenThuong = database.KhenThuongs.Where(x => x.Idkt == id).FirstOrDefault();
            database.Remove(khenThuong);
            database.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
