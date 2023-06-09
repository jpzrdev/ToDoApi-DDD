using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;

namespace Application.Commands.CreateToDoList
{
    public class CreateToDoListCommandResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
    }
}