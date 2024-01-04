using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Visitor.Controllers;
[Area("Visitor")]
public class VisitorLayoutController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
    public PartialViewResult VisitorSidebarPartial()
    {
        return PartialView();
    }
    public PartialViewResult VisitorNavbarPartial()
    {
        return PartialView();
    }
    public PartialViewResult VisitorHeaderPartial()
    {
        return PartialView();
    }
    public PartialViewResult VisitorFooterPartial()
    {
        return PartialView();
    }
    public PartialViewResult VisitorScriptsPartial()
    {
        return PartialView();
    }
}
