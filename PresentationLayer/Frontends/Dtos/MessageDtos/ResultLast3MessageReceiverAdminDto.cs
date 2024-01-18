using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.MessageDtos;

public class ResultLast3MessageReceiverAdminDto
{
    public int Id { get; set; }
    public string Subject { get; set; }
    public string SenderName { get; set; }
    public string ImageUrl { get; set; }
    public DateTime SendDate { get; set; }
}
