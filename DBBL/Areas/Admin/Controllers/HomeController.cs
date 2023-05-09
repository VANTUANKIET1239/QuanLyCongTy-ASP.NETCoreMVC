using DBBL.Models;
using Microsoft.AspNetCore.Mvc;

namespace DBBL.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly DbdlContext _db;

        public HomeController(DbdlContext db)
        {
            _db = db;
        }
        [SessionFilter]
        public IActionResult Index()
        {
            string? idct = HttpContext.Session.GetString("id");
            if(string.IsNullOrEmpty(idct))
            {
                return NotFound();
            }
            var sp = _db.SanPhams.Where(x => x.IdCt.Trim().Equals(idct.Trim()) && x.Trangthai == true).ToList();
            return View(sp);
        }
        [SessionFilter]
        public IActionResult NhanVien()
        {
            string? idct = HttpContext.Session.GetString("id");
            if(idct == null)
            {
                TempData["error"] = "Phiên Đăng Nhập Hết Hạn, Cần Đăng Nhập Lại";
                return RedirectToAction("Login", "User");
            }
            var nv = _db.NhanViens.Where(x => x.IdCt.Trim().Equals(idct.Trim()) && x.Trangthai == true).ToList();
            return View(nv);
        }
    }
}
