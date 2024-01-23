using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.AdminNavbarProfileViewComponents;

public class _AdminNavbarProfileComponentPartial : ViewComponent
{
    private readonly UserManager<VisitorUser> _userManager;

    public _AdminNavbarProfileComponentPartial(UserManager<VisitorUser> userManager)
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
