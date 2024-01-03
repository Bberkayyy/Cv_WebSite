using DataAccessLayer.Abstract;
using DataAccessLayer.BaseContext;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using EntityLayer.Dtos.ResponseDtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete;

public class UserMessageDal : GenericRepository<BaseDbContext, UserMessage>, IUserMessageDal
{
    public UserMessageDal(BaseDbContext context) : base(context)
    {

    }

    public List<UserMessageDetailDto> GetUserMessagesWithUser()
    {
        return Context.UserMessages.Join(
            Context.Users,
            userMessage => userMessage.UserId,
            user => user.Id,
            (userMessage, user) => new UserMessageDetailDto
            {
                Id = userMessage.Id,
                Title = userMessage.Title,
                Content = userMessage.Content,
                Date = userMessage.Date,
                Status = userMessage.Status,
                Name = user.Name,
                Surname = user.Surname,
                UserName = user.UserName,
                Mail = user.Mail
            }).ToList();
    }
}
