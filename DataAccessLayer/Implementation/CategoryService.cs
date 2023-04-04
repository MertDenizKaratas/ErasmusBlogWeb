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
    public class CategoryService : ICategoryService
    {
        public DatabaseContext ctx;

        public CategoryService(DatabaseContext ctx)
        {
            this.ctx = ctx;
        }

        public bool Add(Category model)
        {
            try
            {
                ctx.Category.Add(model);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
   
        }

        public bool Delete(Category model)
        {
            try
            {
                ctx.Category.Remove(model);
                ctx.SaveChanges(); return true;
            }
            catch (Exception ex)
            {

                return false; 
            }
        
        }

        public List<Category> GetAll()
        {
            return ctx.Category.ToList();
        }

        public Category GetById(int id)
        {
           return ctx.Category.FirstOrDefault(x=>x.CategoryId==id);
            
        }

        public bool Update(Category model)
        {
            try
            {
                ctx.Category.Update(model);
                ctx.SaveChanges(); return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }
    }
}
