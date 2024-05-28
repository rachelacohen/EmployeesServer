using manageServer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace manageServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SendEmailController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> SendEmailAsync([FromBody] EmailPostModel model)
        {
            // הגדרות חיבור SMTP
            using (var client = new SmtpClient("smtp.gmail.com"))
            {
                client.Port = 587;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("neshikot.me@gmail.com", "vxmu lldi focy ilrn");
                client.EnableSsl = true;

                // יצירת הודעת האימייל
                using (var message = new MailMessage())
                {
                    message.From = new MailAddress("neshikot.me@gmail.com");
                    message.To.Add(model.To);
                    message.Subject = model.Subject;
                    message.Body = model.Body;

                    // שליחת ההודעה
                    try
                    {
                        await client.SendMailAsync(message);
                        return Ok("המייל נשלח בהצלחה.");
                    }
                    catch (System.Exception ex)
                    {
                        return StatusCode(500, "שגיאה בשליחת המייל: " + ex.Message);
                    }
                }
            }
        }
    }

   
}
