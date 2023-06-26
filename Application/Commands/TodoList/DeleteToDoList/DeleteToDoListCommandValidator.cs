using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.Commands.Todo.DeleteToDoList
{
    public class DeleteToDoListCommandValidator : AbstractValidator<DeleteToDoListCommandRequest>
    {
        public DeleteToDoListCommandValidator()
        {
            RuleFor(req => req.Id).NotEmpty().NotNull();
        }
    }
}