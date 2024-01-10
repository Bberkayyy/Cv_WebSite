using System.ComponentModel.DataAnnotations;

namespace WebUI.Areas.Visitor.Models;

public class VisitorUserRegisterViewModel
{
    [Required(ErrorMessage = "Lütfen adınızı giriniz.")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Lütfen soy adınızı giriniz.")]
    public string Surname { get; set; }
    [Required(ErrorMessage = "Lütfen kullanıcı adınızı giriniz.")]
    public string UserName { get; set; }
    [Required(ErrorMessage = "Lütfen şifrenizi giriniz.")]
    public string Password { get; set; }
    [Required(ErrorMessage = "Lütfen şifrenizi tekrar giriniz.")]
    [Compare("Password", ErrorMessage = "Şifreler aynı olmalıdır.")]
    public string ConfirmPassword { get; set; }
    [Required(ErrorMessage = "Lütfen mail adresinizi giriniz.")]
    public string Mail { get; set; }
}