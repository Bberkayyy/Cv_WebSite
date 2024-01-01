using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.ViewComponents.NavbarViewComponents;

public class _NavbarComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
