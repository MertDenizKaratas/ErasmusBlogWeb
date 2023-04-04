using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IWriterService
    {
        bool Add(Writer model);
        bool Delete(Writer model);
        Writer GetById(int id);
        bool Update(Writer model);
        List<Writer> GetAll();
        bool AddWriterUser(WritersAndUsersRelationship model);
        Writer GetByUsername(string username);
    }
}
