using DBBL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.Security.Cryptography;
using System.Text;

namespace DBBL.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class NhanVienController : Controller
    {

        private readonly DbdlContext _db;

        public NhanVienController(DbdlContext db)
        {
            _db = db;
        }
        public IActionResult ThemNV()
        {
            string? idct = HttpContext.Session.GetString("id");
            var sp = _db.NhanViens.Where(x => x.Trangthai == true && x.IdCt.Equals(idct)).ToList();            
            string tencty = _db.CongTies.FirstOrDefault(x => x.IdCt.Trim().Equals(idct.Trim())).TenCt;
            ViewBag.ID = "NV" + idct +(sp.Count + 1).ToString("00");
            ViewBag.CTY = tencty;
            return View();
           
        }
        [HttpPost]
        public IActionResult ThemNV([FromForm]string xacnhanmk, NhanVien nv)
        {
            string? idct = HttpContext.Session.GetString("id");
            if (!nv.Mk.Trim().Equals(xacnhanmk.Trim()))
            {
                ModelState.AddModelError("Mk", "Mật Khẩu không khớp");
            }
            if (ModelState.IsValid)
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(xacnhanmk);
                using (SHA256 sha256 = SHA256.Create())
                {
                    byte[] hashedBytes = sha256.ComputeHash(inputBytes);

                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < hashedBytes.Length; i++)
                    {
                        sb.Append(hashedBytes[i].ToString("x2"));
                    }

                    nv.Mk = sb.ToString();
                }
                nv.IdCt = idct;
                _db.NhanViens.Add(nv);
                _db.SaveChanges();
                TempData["success"] = "Thêm Nhân Viên Thành Công";
                return RedirectToAction("NhanVien", "Home");
            }
            else
            {
                string tencty = _db.CongTies.FirstOrDefault(x => x.IdCt.Trim().Equals(idct.Trim())).TenCt;
                ViewBag.ID = nv.IdNv;
                ViewBag.CTY = tencty;
            }
            return View(nv);
        }
        public IActionResult Details(string id)
        {
            string? idct = HttpContext.Session.GetString("id");
            var nv = _db.NhanViens.Where(x => x.Trangthai == true).FirstOrDefault(x => x.IdNv.Trim().Equals(id.Trim()));
            string tencty = _db.CongTies.FirstOrDefault(x => x.IdCt.Trim().Equals(idct.Trim())).TenCt;
            ViewBag.CTY = tencty;          
            return View(nv);
        }
        public IActionResult Xoa(string id)
        {
            string? idct = HttpContext.Session.GetString("id");
            var nv = _db.NhanViens.Where(x => x.Trangthai == true).FirstOrDefault(x => x.IdNv.Trim().Equals(id.Trim()));
            string tencty = _db.CongTies.FirstOrDefault(x => x.IdCt.Trim().Equals(idct.Trim())).TenCt;
            ViewBag.CTY = tencty;
            return View(nv);
        }
        [HttpPost]
        [ActionName("Xoa")]
        public IActionResult XoaNV(string IdNv)
        {
            var nv = _db.NhanViens.Where(x => x.Trangthai == true).FirstOrDefault(x => x.IdNv.Trim().Equals(IdNv.Trim()));
            nv.Trangthai = false;
            _db.NhanViens.Update(nv);
            _db.SaveChanges();
            TempData["success"] = "Xóa Nhân Viên Thành Công";
            return RedirectToAction("NhanVien", "Home");
        }
    }
}
