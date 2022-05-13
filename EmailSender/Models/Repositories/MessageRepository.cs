using EmailSender.Models.Domains;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EmailSender.Models.Repositories
{
    public class MessageRepository
    {

        public void Add(Message message)
        {
            using (var context = new ApplicationDbContext())
            {
                context.Messages.Add(message);
                context.SaveChanges();
            }
        }

        public List<Message> GetMessages(string userId)
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Messages
                    .Where(x => x.UserId == userId)
                    .ToList();
            }
        }
    }
}