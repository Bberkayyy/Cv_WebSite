namespace WebUI.Models;

public class CreateTestimonialViewModel
{
    public string ClientName { get; set; }
    public string Company { get; set; }
    public string Comment { get; set; }
    public string ImageUrl { get; set; }
    public string Title { get; set; }
    public IFormFile Picture { get; set; }
}
