using DBBL.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Cryptography;
using System.Text;

namespace DBBL.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly DbdlContext _db;

        public UserController(DbdlContext db)
        {
            _db = db;
        }
        public IActionResult Login()
        {
            byte[] value = null;
            if (HttpContext.Session.TryGetValue("username",out value))
            {
                TempData["success"] = "Login Succesfully";
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpPost]
        public IActionResult Login( string EmailNql, string Mk)
        {
            var ctyus = _db.CongTies.FirstOrDefault(x => x.EmailNql.Trim() == EmailNql.Trim());
            if(ctyus == null) 
            {
                ModelState.AddModelError("EmailNql", "Email không đúng");
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

                if (ctyus.Mk.Trim().Equals(hashedString.Trim()))
                {
                    HttpContext.Session.SetString("username", ctyus.TenNql);
                    HttpContext.Session.SetString("id", ctyus.IdCt);
                    TempData["success"] = "Đăng Nhập Thành Công";
                    return RedirectToAction("Index", "Home");
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
            return RedirectToAction("Login", "User");
        }
        public IActionResult Details()
        {
            string idct = HttpContext.Session.GetString("id");
            var us = _db.CongTies.FirstOrDefault(x => x.IdCt.Equals(idct));
            return View(us);
        }
    }
}
