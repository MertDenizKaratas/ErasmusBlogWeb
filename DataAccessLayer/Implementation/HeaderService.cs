using Ardalis.Result;
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
    public class HeaderService : IHeaderService
    {
        public DatabaseContext ctx;
        public HeaderService(DatabaseContext ctx)
        {
            this.ctx = ctx;
        }

        public bool Add(Header model)
        {
            try
            {
                ctx.Add(model);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(Header model)
        {
            try
            {
                ctx.Remove(model);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<Header> GetAll()
        {
           return ctx.Header.ToList();

        }

        public Header GetById(int id)
        {
            return ctx.Header.FirstOrDefault(x=>x.HeaderId== id);
        }

        public bool Update(Header model)
        {
            try
            {
                ctx.Update(model);  
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
