using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.Commands.TodoList.UpdateToDoList
{
    public class UpdateToDoListCommandValidator : AbstractValidator<UpdateToDoListCommandRequest>
    {
        public UpdateToDoListCommandValidator()
        {
            RuleFor(req => req.Title)
            .NotEmpty()
            .NotNull();
        }
    }
}