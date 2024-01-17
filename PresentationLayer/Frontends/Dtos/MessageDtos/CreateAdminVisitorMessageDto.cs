using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.MessageDtos;

public class CreateAdminVisitorMessageDto
{
    public string SenderMail { get; set; }
    public string ReceiverMail { get; set; }
    public string SenderName { get; set; }
    public string ReceiverName { get; set; }
    public string Subject { get; set; }
    public string MessageContent { get; set; }
    public DateTime SendDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
}
