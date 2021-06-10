using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_QLNS.Models;

namespace Web_QLNS.Controllers
{
    public class UserController : Controller
    {
        private readonly QLNSContext database;
        private readonly IWebHostEnvironment hostEnvironment;

        public UserController(QLNSContext db, IWebHostEnvironment hostEnvironment)
        {
            database = db;
            this.hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            var model = new ViewModelCC();
            model.ListChamCong = database.ChamCongs.ToArray();
            model.ListNhanVien = database.NhanViens.ToArray();
            return View(model);
        }

        [HttpGet]

        ///////////////////////////
        public async Task<ActionResult> ChamCong(ChamCong chamCong, KyLuat kyLuat)
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

                if (chamCong.Ngay.Hour > 7 || chamCong.Ngay.Hour == 7 && chamCong.Ngay.Minute >= 1)
                {
                    kyLuat.Idnv = int.Parse(HttpContext.Session.GetString("IDNV"));
                    kyLuat.IdloaiKl = 2;
                    kyLuat.Ngay = DateTime.Now;

                    database.Add(kyLuat);
                    await database.SaveChangesAsync();
                }

                //return RedirectToAction("Index","User");
            }
            return RedirectToAction("Index");
        }
        ///////////////////////////

        //public async Task<ActionResult> ChamCong()
        //{
        //    //ID kỷ luật tạo ntn
        //    //lây id ra i
        //    //int idnv = int.Parse(HttpContext.Session.GetString("IDNV"));

        //    ChamCong chamCong = new ChamCong
        //    {
        //        Idnv = int.Parse(HttpContext.Session.GetString("IDNV")),
        //        Ngay = DateTime.Now,
        //        TrangThai = true,
        //    };
        //    database.Add(chamCong);
        //    await database.SaveChangesAsync();

        //    if (chamCong.Ngay.Hour > 7 || chamCong.Ngay.Hour==7 && chamCong.Ngay.Minute>=1/*Parse("7:00:00 SA")*/)
        //    {
        //        KyLuat kyLuat = new KyLuat
        //        {
        //            Idnv = int.Parse(HttpContext.Session.GetString("IDNV")),
        //            IdloaiKl = 2,
        //            Ngay = DateTime.Now,

        //        };
        //        database.Add(kyLuat);
        //        await database.SaveChangesAsync();
        //    }

        //    //chỗ nay là xong cái kỉ luật với cái chấm công r
        //    //m muốn làm gì sau cái này thì ghi ở dưới này

        //    return View("Index","User"); // cái này m muốn redirect đi đau thì sửa lại nha
        //}


    }// chỗ này có cái trang thai n hoi dư :))), thế nào là false, khi nao xảy ra truờng họp false......Bữa t nói nó set mặc định F hết rùi nào chấm công thì set lại là True
     // k cân nha :)) ở đây mỗi ngay m chấm công 1 lần, nen m có cái ngày với cái idnv là đc r. tại vài m chỉ tạo ra cái châm công khi nhân viên đó chấm công thôi, la k cần cái trạng thái nưa,
     //môi ngay mới NV nó chấm công thì tạo ra 1 cái mơi rồi, thừa column đó
     //H
}
// t nêu ý tương tự lam nha
// action Get Index return cái view đi kèm model đúng k, truyền cái  User đang đang nhập lên view
// trên cái view ngay chỗ nút chấm công á, viết if else, Idnv laf id của  user
// foreach( var chamCong in listChamCong)
//{
//    //tại vì idnv với ngày đã tôn tại rồi nên là => hôm nay cc rồi
//    if (Idnv == chamCong.idnv && chamCong.Ngay == DateTime.Now)
//    {
//        hidden button
//    } 
//    else
//    {
//        show btn
//    }
//}
//choox nayf ok k

// hieee???? sao ddanhs k ddc
// ok v h tự làm nha :v xong r á
// Bik cách xắp sếp cái bảng chấm công mà Ngày nó nằm ngang k. là sao :v
//       Giống gị nek
//   Tên nV         1/6     2/6     3/6     4/6
//      Long         X       x      x
//kiểu dị á.
// trong cái bảng chấm công nó sẽ có nhiều dòng trùng tên NV nhưng mõi dòng đó sẽ khác ngày
// t thử group by IDNV thì nó giải quyết đc cái đoạn tên trùng
// nhưng cái ngày thì k đc. thui chịu, cai nào foreach lồng nhau rôi còn if else 1 nùi nữa mới ra chưa kể có th ngay hôm đó không chấm nữa :)) rối 
// Um .có ngày k chấm công thì nó sẽ k lưu DB nên bảng chấm công sẽ k có ngày đó
// Nên khi lm cái Index cho bảng chấm công nó sẽ k hiện đc cái ngày off, như v là bị hông lỗ lỗ á :)) thui cái này chịu, rối lăm :v tìm huớng khác i
// show 
//:v cung k biết thiết kê UI ntn luôn
    //thế mới khó nek.t ngồi từ qua, vẫn chưa ghĩ ra nên thiết kế cái view thế nào
    // chỉ có hiển thị giống cái bảng trong SQL à, hết cách lun :v thua , hồi h cái view thưởng n sẽ giogns giông với cái db, h cũng k biết thiêt kế ntn, mà xử lý phânf trên kia xong đi r tinh tiếp
    // thui t tắt nha 
    //UH