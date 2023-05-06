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
            HttpContext.Session.SetString("slht", sp.SlHt);
            HttpContext.Session.SetString("gioihan", sp.GioiHan);
            _db.SanPhams.Update(sp);
            _db.SaveChanges();
            SentSms();
           // TempData["success"] = "Xác Nhận Sử Dụng Thành Công";
           
            return RedirectToAction("HienSanPham", "Home");


        }

        [NonAction]
        public void SentSms()
        {
            var accountSid = "ACe28d2a6273ec626f6eccfcd1e43e41df";
            var authToken = "cc51b943e3fbafcf10d78efd0bc7b8db";
            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                from: new Twilio.Types.PhoneNumber("+13204082422"),
                to: new Twilio.Types.PhoneNumber("+84906889483"),
                body: "Đây là tôi Kiệt"
            );
            ViewData["success"] = message.Sid;

        }
    }
}
