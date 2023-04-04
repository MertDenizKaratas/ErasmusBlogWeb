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
    public class ContentService : IContentHeader
    {
        public DatabaseContext ctx;
        public ContentService(DatabaseContext ctx)
        {
            this.ctx = ctx;
        }

        public bool Add(Content model)
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

        public bool Delete(Content model)
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

        public List<Content> GetAll()
        {
            return ctx.Content.ToList();
        }

        public Content GetById(int id)
        {
            return ctx.Content.FirstOrDefault(x => x.ContentId == id);
        }

        public List<Content> GetContentById(int id)
        {
           return ctx.Content.Where(x=>x.HeaderId== id).ToList();
        }

        public bool Update(Content model)
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
