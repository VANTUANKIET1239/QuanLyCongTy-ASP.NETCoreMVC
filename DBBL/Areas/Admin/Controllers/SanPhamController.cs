using DBBL.Models;
using Microsoft.AspNetCore.Mvc;
using Twilio.Rest.Api.V2010.Account;

namespace DBBL.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SanPhamController : Controller
    {
        private readonly DbdlContext _db;

        public SanPhamController(DbdlContext db)
        {
            _db = db;
        }
        public IActionResult SuDung(string id)
        {
            var spdc = _db.SanPhams.FirstOrDefault(x => x.IdSp.Trim().Equals(id.Trim()));
            return View(spdc);
        }
        [HttpPost]
        public IActionResult SuDung([FromForm] int slsd, string IdSp)
        {
            var sp = _db.SanPhams.FirstOrDefault(x => x.IdSp.Trim().Equals(IdSp.Trim()));
            sp.SlHt = (Convert.ToInt32(sp.SlHt) - slsd).ToString();
            _db.SanPhams.Update(sp);
            _db.SaveChanges();
            TempData["success"] = "Xác Nhận Sử Dụng Thành Công";
            return RedirectToAction("Index", "Home");


        }
        public IActionResult ChinhSua(string id)
        {
            var spdc = _db.SanPhams.FirstOrDefault(x => x.IdSp.Trim().Equals(id.Trim()));
            return View(spdc);
        }

        [HttpPost]
        public IActionResult ChinhSua([FromForm] int slt, [FromForm] int gh, string IdSp)
        {
            var spdc = _db.SanPhams.FirstOrDefault(x => x.IdSp.Trim().Equals(IdSp.Trim()));
            spdc.SlHt = (Convert.ToInt32(spdc.SlHt) + slt).ToString();           
            spdc.GioiHan = gh.ToString();
            if (Convert.ToUInt32(spdc.SlHt) > Convert.ToInt32(spdc.GioiHan)){
                List<NhanVien> kiet = _db.NhanViens.Where(x => x.Trangthai == true && x.IdCt.Equals(HttpContext.Session.GetString("id"))).ToList();
                for(int i = 0; i< kiet.Count; i++)
                {
                    string tn = $"Sản phẩm {spdc.TenSp} đã được thêm vào với số lượng {slt}";
                    string subject = "THÔNG BÁO THÊM SẢN PHẨM";
                    Sms.SendEmail(kiet[i].EmailNv, subject, tn);
                }
            }
            _db.SanPhams.Update(spdc);
            _db.SaveChanges();
            TempData["success"] = "Chỉnh Sửa Thành Công";
            return RedirectToAction("Index", "Home");
        }
       
        public IActionResult Xoa(string id)
        {
            var spdc = _db.SanPhams.FirstOrDefault(x => x.IdSp.Trim().Equals(id.Trim()));
            return View(spdc);
        }

        [HttpPost]
        [ActionName("Xoa")]
        public IActionResult XoaSP(string IdSp)
        {
            var spdc = _db.SanPhams.FirstOrDefault(x => x.IdSp.Trim().Equals(IdSp.Trim()));
            spdc.Trangthai = false;
            _db.SanPhams.Update(spdc);
            _db.SaveChanges();
            TempData["success"] = "Xóa Thành Công";
            return RedirectToAction("Index", "Home");
        }

        public IActionResult ThemSP()
        {
            string? idct = HttpContext.Session.GetString("id");
            var sp = _db.SanPhams.Where(x => x.Trangthai == true && x.IdCt.Equals(idct)).ToList();          
            string tencty = _db.CongTies.FirstOrDefault(x => x.IdCt.Trim().Equals(idct.Trim())).TenCt;
            ViewBag.ID = "SP" + idct + (sp.Count + 1).ToString("00");
            ViewBag.CTY = tencty;
            return View();
        }

        [HttpPost]
        public IActionResult ThemSP(SanPham sp)
        {
            
           
            if (ModelState.IsValid)
            {
                string? idct = HttpContext.Session.GetString("id");
                sp.IdCt = idct;
                _db.SanPhams.Add(sp);
                _db.SaveChanges();
                TempData["success"] = "Thêm Sản Phẩm Thành Công";
                return RedirectToAction("Index", "Home");
            }
            return View(sp);
        }
            
    }
}