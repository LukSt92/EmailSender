using EmailSender.Models.Domains;
using EmailSender.Models.Repositories;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace EmailSender.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {

        private MessageRepository _messageRepository = new MessageRepository();
        public ActionResult Index()
        {

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Message message, HttpPostedFileBase fileUploader)
        {
            var userId = User.Identity.GetUserId();
            message.UserId = userId;

            try
            {
                _messageRepository.Add(message);

                var senderEmail = new MailAddress("lukst92reportservice@gmail.com", message.Sender);
                var receiverEmail = new MailAddress(message.Receiver, "Receiver");
                var password = "#";
                var sub = message.Title;
                var body = message.MessageContent;
                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(senderEmail.Address, password)
                };
                using (var mess = new MailMessage(senderEmail, receiverEmail))
                {
                    mess.Subject = sub;
                    mess.Body = body;
                    {
                        string fileName = Path.GetFileName(fileUploader.FileName);
                        mess.Attachments.Add(new Attachment(fileUploader.InputStream, fileName));
                    }
                    smtp.Send(mess);
                }

                return RedirectToAction("Sent");
            }
            catch (Exception)
            {
                ViewBag.Error = "Some Error";
            }
            return View();
        }

        public ActionResult Sent()
        {
            return View();
        }

        
        public ActionResult Archive()
        {
            var userId = User.Identity.GetUserId();
            var messages = _messageRepository.GetMessages(userId);

            return View(messages);
        }

        [AllowAnonymous]
        public ActionResult Contact()
        {

            return View();
        }

        public ActionResult SendEmail()
        {
            return View();
        }
    }
}