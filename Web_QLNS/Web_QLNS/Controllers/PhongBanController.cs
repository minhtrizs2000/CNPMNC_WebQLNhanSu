using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_QLNS.Models;

namespace Web_QLNS.Controllers
{
    public class PhongBanController : Controller
    {
        private readonly QLNSContext database;
        public PhongBanController(QLNSContext db)
        {
            database = db;
        }

        // GET: PhongBanController
        public ActionResult Index()
        {
            var model = new ViewModelNV();
            model.ListPhongBan = database.PhongBans.ToArray();            
            return View(model);
        }

        // GET: PhongBanController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PhongBanController/Create
        public ActionResult Create()
        {
            var model = new PhongBan();

            return View(model);
        }

        // POST: PhongBanController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PhongBan phongBan)
        {
            if (ModelState.IsValid)
            {
                database.Add(phongBan);
                database.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(phongBan);
        }

        // GET: PhongBanController/Edit/5
        public ActionResult Edit(int id)
        {
            var model = new PhongBan();
            model = database.PhongBans.Where(x => x.Idpb == id).FirstOrDefault();
            return View(model);
        }

        // POST: PhongBanController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PhongBan phongBan)
        {
            var model = phongBan;            
            if (ModelState.IsValid)
            {
                database.Update(model);
                database.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: PhongBanController/Delete/5
        public ActionResult Delete(int id)
        {
            var model = new PhongBan();           
            model = database.PhongBans.Where(x => x.Idpb == id).FirstOrDefault();
            return View(model);
        }

        // POST: PhongBanController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, PhongBan phongBan)
        {
            phongBan = database.PhongBans.Where(x => x.Idpb == id).FirstOrDefault();
            database.Remove(phongBan);
            database.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
