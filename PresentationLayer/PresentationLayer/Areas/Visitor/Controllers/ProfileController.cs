using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebUI.Areas.Visitor.Models;

namespace WebUI.Areas.Visitor.Controllers;

[Area("Visitor")]
[Route("Visitor/[controller]")]
[Authorize]
public class ProfileController : Controller
{
    private readonly UserManager<VisitorUser> _userManager;

    public ProfileController(UserManager<VisitorUser> userManager)
    {
        _userManager = userManager;
    }

    [Route("Index")]
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var value = await _userManager.FindByNameAsync(User.Identity.Name);
        VisitorUserUpdateViewModel viewModel = new VisitorUserUpdateViewModel();
        viewModel.Name = value.Name;
        viewModel.Surname = value.Surname;
        viewModel.PictureUrl = value.ImageUrl;
        return View(viewModel);
    }
    [HttpPost]
    [Route("Index")]
    public async Task<IActionResult> Index(VisitorUserUpdateViewModel updateViewModel)
    {
        var value = await _userManager.FindByNameAsync(User.Identity.Name);
        if (updateViewModel.Picture is not null)
        {
            var resource = Directory.GetCurrentDirectory();
            var extension = Path.GetExtension(updateViewModel.Picture.FileName);
            var imageName = Guid.NewGuid() + extension;
            var saveLocation = resource + "/wwwroot/images/" + imageName;
            var stream = new FileStream(saveLocation, FileMode.Create);
            await updateViewModel.Picture.CopyToAsync(stream);
            value.ImageUrl = imageName;
        }
        value.Name = updateViewModel.Name;
        value.Surname = updateViewModel.Surname;
        var result = await _userManager.UpdateAsync(value);
        if (result.Succeeded)
        {
            return RedirectToAction("Index", "Default", new { area = "Visitor" });
        }
        return View(value);
    }
}
