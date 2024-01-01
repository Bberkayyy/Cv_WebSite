using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.MessageDtos;

public class CreateMessageDto
{
    public string Name { get; set; }
    public string Mail { get; set; }
    public string Content { get; set; }
    public DateTime Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
    public bool Status = true;
}
