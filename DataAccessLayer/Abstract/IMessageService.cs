using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IMessageService
    {
        bool Add(Message model);
        List<Message> GetAll();
        bool Delete(Message model);
        Message GetByUserId(int id);
        bool Update(Message model);
    }
}
