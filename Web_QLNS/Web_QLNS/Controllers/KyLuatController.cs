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
    public class KyLuatController : Controller
    {
        private readonly QLNSContext database;
        private readonly IWebHostEnvironment hostEnvironment;

        public KyLuatController(QLNSContext db, IWebHostEnvironment hostEnvironment)
        {
            database = db;
            this.hostEnvironment = hostEnvironment;
        }

        // GET: KyLuatController
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            //A ViewBag property provides the view with the current sort order, because this must be included in 
            //  the paging links in order to keep the sort order the same while paging
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            ViewBag.Role = TempData["Role"];

            var ModelList = new List<KyLuat>();

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
                var modelv = from s in context.KyLuats
                             select s;
                //Search and match data, if search string is not null or empty
                if (!String.IsNullOrEmpty(searchString))
                {
                    modelv = modelv.Where(s => s.Idkl.ToString().Contains(searchString)
                                           || s.IdnvNavigation.TenNv.Contains(searchString)
                                           || s.IdloaiKlNavigation.TenKl.Contains(searchString)
                                           || s.Ngay.Value.Month.ToString().Contains(searchString));
                }
                switch (sortOrder)
                {
                    case "name_desc":
                        ModelList = modelv.OrderByDescending(s => s.Idkl).ToList();
                        break;

                    default:
                        ModelList = modelv.OrderBy(s => s.Idkl).ToList();
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
            model.ListKyLuats = ModelList.ToPagedList(pageNumber, pageSize);
            model.ListloaiKyLuat = database.LoaiKyLuats.ToArray();
            return View(model);
        }

        //// GET: KyLuatController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: KyLuatController/Create
        public ActionResult Create()
        {
            var model = new ViewModelDG();
            model.ListNhanVien = database.NhanViens.ToArray();
            model.ListloaiKyLuat = database.LoaiKyLuats.ToArray();
            return View(model);
        }

        // POST: KyLuatController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(KyLuat kyLuat)
        {
            var model = new ViewModelDG();
            model.ListNhanVien = database.NhanViens.ToArray();
            model.ListloaiKyLuat = database.LoaiKyLuats.ToArray();
            if (ModelState.IsValid)
            {
                database.Add(kyLuat);
                await database.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: KyLuatController/Edit/5
        public ActionResult Edit(int id)
        {
            var model = new ViewModelDG();
            model.ListNhanVien = database.NhanViens.ToArray();
            model.ListloaiKyLuat = database.LoaiKyLuats.ToArray();
            model.kyLuat = database.KyLuats.Where(x => x.Idkl == id).FirstOrDefault();
            return View(model);
        }

        // POST: KyLuatController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, KyLuat kyLuat)
        {
            var model = new ViewModelDG();
            model.ListNhanVien = database.NhanViens.ToArray();
            model.ListloaiKyLuat = database.LoaiKyLuats.ToArray();
            model.kyLuat = database.KyLuats.Where(x => x.Idkl == id).FirstOrDefault();
            if (ModelState.IsValid)
            {
                model.kyLuat.Idnv = kyLuat.Idnv;
                model.kyLuat.IdloaiKl = kyLuat.IdloaiKl;
                model.kyLuat.Ngay = kyLuat.Ngay;

                database.Update(model.kyLuat);
                await database.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: KyLuatController/Delete/5
        public ActionResult Delete(int id)
        {
            var model = new ViewModelDG();
            model.ListNhanVien = database.NhanViens.ToArray();
            model.ListloaiKyLuat = database.LoaiKyLuats.ToArray();
            model.kyLuat = database.KyLuats.Where(x => x.Idkl == id).FirstOrDefault();
            return View(model);
        }

        // POST: KyLuatController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, KyLuat kyLuat)
        {
            kyLuat = database.KyLuats.Where(x => x.Idkl == id).FirstOrDefault();
            database.Remove(kyLuat);
            database.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
