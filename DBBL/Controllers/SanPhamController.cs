using DBBL.Models;
using Microsoft.AspNetCore.Mvc;
using Twilio;
using Twilio.Clients;
using Twilio.Rest.Api.V2010.Account;


namespace DBBL.Controllers
{
    public class SanPhamController : Controller
    {
        private readonly DbdlContext _db;

        public SanPhamController(DbdlContext db)
        {
            _db = db;
        }
        [SessionFilter]
        public IActionResult SuDung(string id)
        {
            var spdc = _db.SanPhams.FirstOrDefault(x => x.IdSp.Trim().Equals(id.Trim()));
            return View(spdc);
        }
       
        [HttpPost]
        [SessionFilter]
        public IActionResult SuDung([FromForm] int slsd, string IdSp)
        {
            var sp = _db.SanPhams.FirstOrDefault(x => x.IdSp.Trim().Equals(IdSp.Trim()));
            sp.SlHt = (Convert.ToInt32(sp.SlHt) - slsd).ToString();
            if (Convert.ToInt32(sp.SlHt) <= Convert.ToInt32(sp.GioiHan))
            {
                string tn = $"Số lượng hiện tại của {sp.TenSp} đã dưới mức giới hạn, cần phải được thêm";
                var ad = _db.CongTies.FirstOrDefault(x => x.IdCt.Equals(HttpContext.Session.GetString("idct").Trim()));
                string sdtadmin = "+84" + ad.SđtNql.Substring(1);
                string mail = ad.EmailNql;
                Sms.SendSmsAdmin(tn, sdtadmin);
                Sms.SendEmail(mail, "Thông báo Sản Phẩm", $"Số lượng hiện tại của {sp.TenSp} đã dưới mức giới hạn, cần phải được thêm");
            }
            _db.SanPhams.Update(sp);
            _db.SaveChanges();
            
          
            TempData["success"] = "Xác Nhận Sử Dụng Thành Công";

            return RedirectToAction("HienSanPham", "Home");


        }
        
        
    }
}
