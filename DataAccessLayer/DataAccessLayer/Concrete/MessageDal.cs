using DataAccessLayer.Abstract;
using DataAccessLayer.BaseContext;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete;

public class MessageDal : GenericRepository<BaseDbContext, Message>, IMessageDal
{
    public MessageDal(BaseDbContext context) : base(context)
    {
    }

    public List<Message> GetLast5Messages()
    {
        return Context.Messages.OrderByDescending(x => x.Id).Take(5).ToList();
    }
}
