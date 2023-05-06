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
        public IActionResult NhanVien()
        {
            string? idct = HttpContext.Session.GetString("id");
            var nv = _db.NhanViens.Where(x => x.IdCt.Trim().Equals(idct.Trim()) && x.Trangthai == true).ToList();
            return View(nv);
        }
    }
}
