using DBBL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace DBBL.Controllers
{
    public class NhanVienController : Controller
    {
        private readonly DbdlContext _db;

        public NhanVienController(DbdlContext db)
        {
            _db = db;
        }
        public IActionResult Login()
        {
            byte[] value = null;
            if (HttpContext.Session.TryGetValue("username", out value))
            {
                return RedirectToAction("Index", "Home");
            }
            return View();

        }
        [HttpPost]
        public IActionResult Login(string EmailNv, string Mk)
        {
            var nhanvien = _db.NhanViens.Where(x => x.Trangthai == true).FirstOrDefault(x => x.EmailNv.Trim() == EmailNv.Trim());
            if (nhanvien == null)
            {
                ModelState.AddModelError("EmailNv", "Email không đúng");
            }
            byte[] inputBytes = Encoding.UTF8.GetBytes(Mk);
            string hashedString = "";

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashedBytes.Length; i++)
                {
                    sb.Append(hashedBytes[i].ToString("x2"));
                }

                hashedString = sb.ToString();
            }
            if (ModelState.IsValid)
            {

                if (nhanvien.Mk.Trim().Equals(hashedString.Trim()))
                {
                    HttpContext.Session.SetString("username", nhanvien.TenNv);
                    HttpContext.Session.SetString("id", nhanvien.IdNv);
                    HttpContext.Session.SetString("idct", nhanvien.IdCt);
                    TempData["success"] = "Đăng Nhập Thành Công";
                    return RedirectToAction("HienSanPham", "Home");
                }
                else
                {
                    ModelState.AddModelError("Mk", "Sai Mật Khẩu");
                }
            }
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("username");
            HttpContext.Session.Remove("id");
            HttpContext.Session.Remove("idct");
            return RedirectToAction("Login", "NhanVien");
        }
        public IActionResult Details()
        {
            string id = HttpContext.Session.GetString("id");
            string idct = HttpContext.Session.GetString("idct");
            var us = _db.NhanViens.Where(x => x.Trangthai == true).FirstOrDefault(x => x.IdNv.Equals(id));
            string? cty = _db.CongTies.FirstOrDefault(x => x.IdCt.Equals(idct)).TenCt;
            ViewBag.CTY = cty;
            return View(us);
        }
    }
}
