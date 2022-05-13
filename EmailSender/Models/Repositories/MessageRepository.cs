using EmailSender.Models.Domains;
using System;
using System.Collections.Generic;
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
    }
}