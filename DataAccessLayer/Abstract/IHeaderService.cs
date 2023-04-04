using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IHeaderService
    {
        bool Add(Header model);
        bool Delete(Header model);
        Header GetById(int id);
        bool Update(Header model);
        List<Header> GetAll();
    }
}
