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
    public class WriterService : IWriterService
    {
        public  DatabaseContext ctx;
        public WriterService(DatabaseContext ctx)
        {
            this.ctx = ctx;
        }

        public bool Add(Writer model)
        {
            try
            {
                ctx.Writer.Add(model);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool AddWriterUser(WritersAndUsersRelationship model)
        {
            try
            {
                ctx.WritersAndUsers.Add(model);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(Writer model)
        {
            try
            {
                ctx.Writer.Remove(model);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                
            }
        }

        public List<Writer> GetAll()
        {
           return ctx.Writer.ToList();

        }

        public Writer GetById(int id)
        {
            return ctx.Writer.FirstOrDefault(x=>x.WriterId== id);
        }

        public Writer GetByUsername(string username)
        {
           return ctx.Writer.Where(p=>p.WriterUsername== username).FirstOrDefault();
        }

        public bool Update(Writer model)
        {
            try
            {
                ctx.Writer.Update(model);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                
            }
        }
    }
}
