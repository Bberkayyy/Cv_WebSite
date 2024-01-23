using Dtos.UserDtos;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Drawing.Text;

namespace WebUI.ViewComponents.AdminDashboardUsersViewComponents;

public class _AdminDashboardUsersComponentPartial : ViewComponent
{
    private readonly UserManager<VisitorUser> _userManager;

    public _AdminDashboardUsersComponentPartial(UserManager<VisitorUser> userManager)
    {
        _userManager = userManager;
    }

    public IViewComponentResult Invoke()
    {
        ViewBag.userCount = _userManager.Users.Count();
        var orderList = _userManager.Users.OrderByDescending(x => x.Id).Take(5).ToList();
        var userList = orderList.Select(x => new ResultLast5UserDto
        {
            Name = x.Name,
            Surname = x.Surname,
            UserName = x.UserName,
            Email = x.Email
        }).ToList();
        return View(userList);
    }
}
