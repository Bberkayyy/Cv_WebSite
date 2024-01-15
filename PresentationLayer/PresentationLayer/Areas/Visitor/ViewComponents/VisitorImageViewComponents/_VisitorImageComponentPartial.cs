using Dtos.AnnouncementDtos;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace WebUI.Areas.Visitor.ViewComponents.VisitorImageViewComponents;

public class _VisitorImageComponentPartial : ViewComponent
{
    private readonly UserManager<VisitorUser> _userManager;

    public _VisitorImageComponentPartial(UserManager<VisitorUser> userManager)
    {
        _userManager = userManager;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var visitor = await _userManager.FindByNameAsync(User.Identity.Name);
        ViewBag.VisitorImage = visitor.ImageUrl;
        return View();
    }
}
