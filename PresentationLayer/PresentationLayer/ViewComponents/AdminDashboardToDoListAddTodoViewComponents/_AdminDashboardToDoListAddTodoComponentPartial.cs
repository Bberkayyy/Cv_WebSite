using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.AdminDashboardToDoListAddTodoViewComponents;

public class _AdminDashboardToDoListAddTodoComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
