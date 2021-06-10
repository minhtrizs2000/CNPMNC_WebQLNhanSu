using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Web_QLNS.Models;

namespace Web_QLNS.Controllers
{
    public class LoginController : Controller
    {
        private readonly QLNSContext database;
        private readonly IWebHostEnvironment hostEnvironment;

        public LoginController(QLNSContext db, IWebHostEnvironment hostEnvironment)
        {
            database = db;
            this.hostEnvironment = hostEnvironment;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(TaiKhoan taiKhoan)
        {
            var modelNV = database.TaiKhoans.Where(x => x.Idnv == taiKhoan.Idnv && x.Pass == taiKhoan.Pass).FirstOrDefault();

            if (modelNV != null && modelNV.Type == true)
            {
                /*var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, taiKhoan.Idnv),
                    new Claim(ClaimTypes.Role, database.TaiKhoans.Where(x=>x.Idnv==modelNV.Idnv).FirstOrDefault().Type),
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                await HttpContext.SignInAsync(claimsPrincipal);

                HttpContext.Session.SetString("IDNV", taiKhoan.Idnv.ToString());*/

                HttpContext.Session.SetString("IDNV", taiKhoan.Idnv.ToString());
                return RedirectToAction("Index", "NhanVien");
            }
            else if (modelNV != null && modelNV.Type == false)
            {
                //var claims = new List<Claim>
                //{
                //    new Claim(ClaimTypes.Email, loginModel.Email),
                //    new Claim(ClaimTypes.Role, database.TypeAccs.Where(x=>x.Idtype==modelKH.Idtype).FirstOrDefault().Name),
                //};

                //var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                //var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                //await HttpContext.SignInAsync(claimsPrincipal);

                HttpContext.Session.SetString("IDNV", taiKhoan.Idnv.ToString());
                return RedirectToAction("Index", "User");
            }

            ViewBag.error = "Sai thông tin tài khoản";
            return View("Index");
        }
    }
}
