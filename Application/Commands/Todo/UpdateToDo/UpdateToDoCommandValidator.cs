using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.Commands.Todo.UpdateToDo
{
    public class UpdateToDoCommandValidator : AbstractValidator<UpdateToDoCommandRequest>
    {
        public UpdateToDoCommandValidator()
        {
            RuleFor(req => req.Description).NotEmpty().NotNull();
        }
    }
}