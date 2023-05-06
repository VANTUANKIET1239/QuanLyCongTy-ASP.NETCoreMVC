using DBBL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DBBL.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DbdlContext _db;
        public HomeController(ILogger<HomeController> logger, DbdlContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
           return View();
        }
        public IActionResult HienSanPham()
        {
            string? idct = HttpContext.Session.GetString("idct");
            if (string.IsNullOrEmpty(idct))
            {
                return NotFound();
            }
            var sp = _db.SanPhams.Where(x => x.IdCt.Trim().Equals(idct.Trim()) && x.Trangthai == true).ToList();
            return View(sp);
        }
       

    public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Roles()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}