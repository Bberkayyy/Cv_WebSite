using Dtos.UserDtos;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;

[Authorize(Roles = "Admin")]
public class AdminUsersController : Controller
{
    private readonly UserManager<VisitorUser> _userManager;
    private readonly RoleManager<VisitorRole> _roleManager;

    public AdminUsersController(UserManager<VisitorUser> userManager, RoleManager<VisitorRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public IActionResult Index()
    {
        ViewBag.v1 = "Kullanıcılar";
        ViewBag.v2 = "Kullanıcı Listesi";
        var users = _userManager.Users.ToList();
        var userList = users.Select(x => new ResultUsersDto
        {
            Id = x.Id,
            Name = x.Name,
            Surname = x.Surname,
            UserName = x.UserName,
            Email = x.Email,
            ImageUrl = x.ImageUrl
        }).ToList();
        return View(userList);
    }
    public async Task<IActionResult> RemoveUser(int id)
    {
        var user = await _userManager.FindByIdAsync(Convert.ToString(id));
        _userManager.DeleteAsync(user);
        return RedirectToAction("Index");
    }
    [HttpGet]
    public IActionResult CreateUser()
    {
        ViewBag.v1 = "Kullanıcılar";
        ViewBag.v2 = "Kullanıcı Ekleme Sayfası";
        return View(new CreateUserDto());
    }
    [HttpPost]
    public async Task<IActionResult> CreateUser(CreateUserDto createDto)
    {

        VisitorUser createUser = new VisitorUser()
        {
            Name = createDto.Name,
            Surname = createDto.Surname,
            Email = createDto.Mail,
            UserName = createDto.UserName,
        };
        if (createDto.Password == createDto.ConfirmPassword)
        {
            var result = await _userManager.CreateAsync(createUser, createDto.Password);
            if (result.Succeeded)
            {
                var role = await _userManager.AddToRoleAsync(createUser, "Visitor");
                if (role.Succeeded)
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
        }
        else
        {
            ViewBag.Error = " Girilen şifreler aynı olmalıdır.";
        }
        return View(createDto);
    }
    [HttpGet]
    public async Task<IActionResult> UpdateRole([FromRoute(Name = "id")] int id)
    {
        ViewBag.v1 = "Kullanıcılar";
        ViewBag.v2 = "Rol Atama Sayfası";
        var user = await _userManager.FindByIdAsync(Convert.ToString(id));
        UpdateUserDto userDto = new UpdateUserDto()
        {
            Mail = user.Email,
            UserName = user.UserName,
            Roles = new HashSet<string>(_roleManager.Roles.Select(x => x.Name).ToList()),
            UserRoles = new HashSet<string>(await _userManager.GetRolesAsync(user))
        };
        return View(userDto);
    }
    [HttpPost]
    public async Task<IActionResult> UpdateRole(UpdateUserDto updateDto)
    {
        var user = await _userManager.FindByIdAsync(Convert.ToString(updateDto.Id));
        await _userManager.UpdateAsync(user);
        if (updateDto.Roles.Count > 0)
        {
            var userRoles = await _userManager.GetRolesAsync(user);
            await _userManager.RemoveFromRolesAsync(user, userRoles);
            await _userManager.AddToRolesAsync(user, updateDto.Roles);
            return RedirectToAction("Index");
        }
        await _userManager.RemoveFromRolesAsync(user, await _userManager.GetRolesAsync(user));
        await _userManager.AddToRoleAsync(user, "Visitor");
        return RedirectToAction("Index");
    }
}
