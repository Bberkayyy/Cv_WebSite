using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.AnnouncementDtos;

public class ResultAnnouncementDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public DateTime Date { get; set; }
    public string Status { get; set; }
    public string Content { get; set; }
}
