using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.ViewComponents.HeaderViewComponents;

public class _HeaderComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
