using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Implementation
{
    public class MessageService : IMessageService
    {
        public DatabaseContext ctx;
        public MessageService(DatabaseContext ctx)
        {
            this.ctx = ctx;
        }

        public bool Add(Message model)
        {
            try
            {
                ctx.Add(model);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(Message model)
        {
            try
            {
                ctx.Remove(model);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Message> GetAll()
        {
           return ctx.Message.ToList();
        }

        public Message GetByUserId(int id)
        {
            throw new NotImplementedException();

        }

        public bool Update(Message model)
        {
            try
            {
                ctx.Update(model);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
