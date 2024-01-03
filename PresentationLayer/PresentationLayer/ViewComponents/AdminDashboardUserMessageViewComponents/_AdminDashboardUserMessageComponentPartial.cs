using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.AdminDashboardUserMessageViewComponents;

public class _AdminDashboardUserMessageComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
