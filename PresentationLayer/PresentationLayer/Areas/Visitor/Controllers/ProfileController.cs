using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using WebUI.Areas.Visitor.Models;

namespace WebUI.Areas.Visitor.Controllers;

[Area("Visitor")]
[Route("Visitor/[controller]")]
[Authorize(Roles = "Visitor")]
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
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Index(VisitorUserUpdateViewModel updateViewModel)
    {
        var value = await _userManager.FindByNameAsync(User.Identity.Name);
        value.Name = updateViewModel.Name;
        value.Surname = updateViewModel.Surname;
        if (updateViewModel.Password == updateViewModel.PaswordConfirm)
        {
            value.PasswordHash = _userManager.PasswordHasher.HashPassword(value, updateViewModel.Password);
            var result = await _userManager.UpdateAsync(value);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Login", new { area = "Visitor" });
            }
        }
        return View(value);
    }
    [HttpPost]
    public async Task<IActionResult> UpdatePicture(IFormFile picture)
    {
        var user = await _userManager.FindByNameAsync(User.Identity.Name);
        if (picture is not null)
        {
            var resource = Directory.GetCurrentDirectory();
            var extension = Path.GetExtension(picture.FileName);
            var imageName = Guid.NewGuid() + extension;
            var saveLocation = resource + "/wwwroot/images/" + imageName;
            var stream = new FileStream(saveLocation, FileMode.Create);
            await picture.CopyToAsync(stream);
            user.ImageUrl = imageName;
        }
        var result = await _userManager.UpdateAsync(user);
        if (result.Succeeded)
        {
            return RedirectToAction("Index", "Profile");
        }
        return View("Index");
    }
}
