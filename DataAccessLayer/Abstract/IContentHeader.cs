using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IContentHeader
    {
        bool Add(Content model);
        bool Delete(Content model);
        Content GetById(int id);
        bool Update(Content model);
        List<Content> GetAll();
        List<Content> GetContentById(int id);
    }
}
