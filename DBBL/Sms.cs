using System.Net.Mail;
using System.Net;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace DBBL
{
    public static class Sms
    {
        public static void SendSmsAdmin(string text, string sdtnguoinhan)
        {
            var accountSid = "ACb7afff6b5eda88bb63542079699eb8cf";
            var authToken = "ee5136ffeca2a47b9f07e2ff80478def";
            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                body: text,
                from: new Twilio.Types.PhoneNumber("+13184952666"),
                to: new Twilio.Types.PhoneNumber(sdtnguoinhan)
            );
            Console.WriteLine(message.Sid);
        }
        public static void SendEmail(string to, string subject, string body)
        {
            var smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential("kietvan.31201024409@st.ueh.edu.vn", "0906889483");
            var mailMessage = new MailMessage("kietvan.31201024409@st.ueh.edu.vn", to, subject, body);
            smtpClient.Send(mailMessage);
            int kiet = 0;
        }
     /*   public  void SendEmail(string id,string quyen)
        {
            string? idct = HttpContext.Session.GetString("id");
            if (idct == null)
            {
                TempData["error"] = "Phiên Đăng Nhập Hết Hạn, Cần Đăng Nhập Lại";
                return RedirectToAction("Login", quyen);
            }
        }*/
    }
   

}
