using System.ComponentModel.DataAnnotations;

namespace WebUI.Areas.Visitor.Models;

public class VisitorUserLoginViewModel
{
    [Display(Name = "Kullanıcı Adı")]
    [Required(ErrorMessage = "Kullanıcı adınızı giriniz.")]
    public string Username { get; set; }

    [Display(Name = "Şifre")]
    [Required(ErrorMessage = "Şifrenizi giriniz.")]
    public string Password { get; set; }
}
