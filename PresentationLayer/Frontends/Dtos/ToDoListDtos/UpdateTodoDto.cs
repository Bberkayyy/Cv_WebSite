using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.ToDoListDtos;

public class UpdateTodoDto
{
    public int Id { get; set; }
    public string Content { get; set; }
    public bool Status { get; set; }
}
