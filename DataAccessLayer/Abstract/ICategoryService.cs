using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface ICategoryService
    {
        bool Add(Category model);
        List<Category> GetAll();
        bool Delete(Category model);    
        Category GetById(int id);
        bool Update(Category model);
        
    }
}
