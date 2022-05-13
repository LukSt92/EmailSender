using EmailSender.Models.Domains;
using EmailSender.Models.Repositories;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace EmailSender.Controllers
{
    public class HomeController : Controller
    {

        private MessageRepository _messageRepository = new MessageRepository();
        public ActionResult Index()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Message message)
        {
            var userId = User.Identity.GetUserId();
            message.UserId = userId;

            try
            {
                if (ModelState.IsValid)
                {
                    _messageRepository.Add(message);
                }
                var senderEmail = new MailAddress("lukst92reportservice@gmail.com", message.Sender);
                var receiverEmail = new MailAddress(message.Receiver, "Receiver");
                var password = "";
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
                using (var mess = new MailMessage(senderEmail, receiverEmail)
                {
                    Subject = sub,
                    Body = body
                })
                {
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

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult SendEmail()
        {
            return View();
        }
    }
}