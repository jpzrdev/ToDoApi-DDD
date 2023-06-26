using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.Commands.Todo.DeleteToDo
{
    public class DeleteToDoCommandValidator : AbstractValidator<DeleteToDoCommandRequest>
    {
        public DeleteToDoCommandValidator()
        {
            RuleFor(req => req.Id).NotEmpty().NotNull();
        }
    }
}