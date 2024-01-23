using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.ToDoListDtos;

public class CreateTodoDto
{
    public string Content { get; set; }
    public bool Status = false;
}
