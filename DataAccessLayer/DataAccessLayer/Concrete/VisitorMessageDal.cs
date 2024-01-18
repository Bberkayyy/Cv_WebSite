using DataAccessLayer.Abstract;
using DataAccessLayer.BaseContext;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using EntityLayer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete;

public class VisitorMessageDal : GenericRepository<BaseDbContext, VisitorMessage>, IVisitorMessageDal
{
    public VisitorMessageDal(BaseDbContext context) : base(context)
    {
    }

    public List<AdminNavbarMessageImagesDto> GetLast3ReceiverMessage(string mail)
    {
        return Context.VisitorMessages.Join(
             Context.Users,
             vm => vm.SenderMail,
             u => u.Email,
             (visitorMessage, User) => new AdminNavbarMessageImagesDto
             {
                 Id = visitorMessage.Id,
                 ImageUrl = User.ImageUrl,
                 SendDate = visitorMessage.SendDate,
                 SenderName = visitorMessage.SenderName,
                 Subject = visitorMessage.Subject
             }).OrderByDescending(a => a.Id).Take(3).ToList();

    }

    public int GetReceiverMessageCount(string mail)
    {
        return Context.VisitorMessages.Where(x => x.ReceiverMail == mail).Count();
    }
    public int GetSenderMessageCount(string mail)
    {
        return Context.VisitorMessages.Where(x => x.SenderMail == mail).Count();
    }
}
