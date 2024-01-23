using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebUI.Models;

namespace WebUI.Controllers;

public class AdminProfileController : Controller
{
    private readonly UserManager<VisitorUser> _userManager;
    private readonly SignInManager<VisitorUser> _signInManager;

    public AdminProfileController(UserManager<VisitorUser> userManager, SignInManager<VisitorUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        ViewBag.v1 = "Profil Ayarları";
        ViewBag.v2 = "Profil Güncelleme Alanı";
        var value = await _userManager.FindByNameAsync(User.Identity.Name);
        AdminProfileUpdateViewModel viewModel = new AdminProfileUpdateViewModel();
        viewModel.Name = value.Name;
        viewModel.Surname = value.Surname;
        viewModel.PictureUrl = value.ImageUrl;
        return View(viewModel);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Index(AdminProfileUpdateViewModel updateViewModel)
    {
        var value = await _userManager.FindByNameAsync(User.Identity.Name);
        value.Name = updateViewModel.Name;
        value.Surname = updateViewModel.Surname;
        value.PasswordHash = _userManager.PasswordHasher.HashPassword(value, updateViewModel.Password);
        var result = await _userManager.UpdateAsync(value);
        if (result.Succeeded)
        {
            return RedirectToAction("Index", "Login", new { area = "Visitor" });
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
            return RedirectToAction("Index", "AdminProfile");
        }
        return View("Index");
    }
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Login", new { area = "Visitor" });
    }
}
