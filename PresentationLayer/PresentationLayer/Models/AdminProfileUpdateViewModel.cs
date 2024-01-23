namespace WebUI.Models;

public class AdminProfileUpdateViewModel
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Password { get; set; }
    public string PaswordConfirm { get; set; }
    public string PictureUrl { get; set; }
    public IFormFile Picture { get; set; }
}
