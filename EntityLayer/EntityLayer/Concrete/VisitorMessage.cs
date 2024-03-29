﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete;

public class VisitorMessage
{
    public int Id { get; set; }
    public string SenderMail { get; set; }
    public string ReceiverMail { get; set; }
    public string SenderName { get; set; }
    public string ReceiverName { get; set; }
    public string Subject { get; set; }
    public string MessageContent { get; set; }
    public DateTime SendDate { get; set; }
    public bool Status { get; set; }
}
