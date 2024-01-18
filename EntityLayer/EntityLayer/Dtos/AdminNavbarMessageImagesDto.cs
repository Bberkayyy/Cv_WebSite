using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Dtos;

public class AdminNavbarMessageImagesDto
{
    public int Id { get; set; }
    public string Subject { get; set; }
    public string SenderName { get; set; }
    public string ImageUrl { get; set; }
    public DateTime SendDate { get; set; }
}
