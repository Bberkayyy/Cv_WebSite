using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace WebUI.TagHelpers;

[HtmlTargetElement("td", Attributes = "user-role")]
public class UserRolesTagHelper : TagHelper
{
    private readonly UserManager<VisitorUser> _userManager;
    private readonly RoleManager<VisitorRole> _roleManager;

    [HtmlAttributeName("user-name")]
    public string UserName { get; set; }

    public UserRolesTagHelper(UserManager<VisitorUser> userManager, RoleManager<VisitorRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }
    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        var user = await _userManager.FindByNameAsync(UserName);
        TagBuilder ul = new TagBuilder("ul");

        var roles = _roleManager.Roles.ToList().Select(x => x.Name);
        foreach (var role in roles)
        {
            TagBuilder li = new TagBuilder("li");
            li.InnerHtml.Append($"{role} : {await _userManager.IsInRoleAsync(user, role)}");
            ul.InnerHtml.AppendHtml(li);
        }
        output.Content.AppendHtml(ul);
    }
}
