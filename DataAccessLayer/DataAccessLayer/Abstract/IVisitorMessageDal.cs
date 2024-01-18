using EntityLayer.Concrete;
using EntityLayer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract;

public interface IVisitorMessageDal : IGenericDal<VisitorMessage>
{
    int GetReceiverMessageCount(string mail);
    int GetSenderMessageCount(string mail);
    List<AdminNavbarMessageImagesDto> GetLast3ReceiverMessage(string mail);
}
