using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.AdminSidebarProfileViewComponents;

public class _AdminSidebarProfileComponentPartial : ViewComponent
{
    private readonly UserManager<VisitorUser> _userManager;

    public _AdminSidebarProfileComponentPartial(UserManager<VisitorUser> userManager)
    {
        _userManager = userManager;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var user = await _userManager.FindByNameAsync(User.Identity.Name);
        ViewBag.Name = user.Name + " " + user.Surname;
        ViewBag.Image = user.ImageUrl;
        return View();
    }
}
