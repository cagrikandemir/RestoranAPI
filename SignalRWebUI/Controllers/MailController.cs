using Microsoft.AspNetCore.Mvc;
using MimeKit;
using SignalRWebUI.Dtos.MailDtos;
using MailKit.Net.Smtp;

namespace SignalRWebUI.Controllers
{
    public class MailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(CreateMailDto createMailDto)
        {
            MimeMessage mimeMessage = new();

            MailboxAddress mailboxAddress = new("SignalR Rezervasyon", "cagrikandemir.dev@gmail.com");
            mimeMessage.From.Add(mailboxAddress);

            MailboxAddress mailboxAdressTo=new("User", createMailDto.ReceiverMail);
            mimeMessage.To.Add(mailboxAdressTo);

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = createMailDto.Body;
            mimeMessage.Body= bodyBuilder.ToMessageBody();
            mimeMessage.Subject = createMailDto.Subject;

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Connect("smtp.gmail.com", 587, false);
            smtpClient.Authenticate("cagrikandemir.dev@gmail.com","slovatcjywukdmdv");

            smtpClient.Send(mimeMessage);
            smtpClient.Disconnect(true);
            return RedirectToAction("Index","Category");
        }
    }
}
