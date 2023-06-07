using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.Commands.CreateToDoList
{
    public class CreateToDoListCommandValidator : AbstractValidator<CreateToDoListCommandRequest>
    {
        public CreateToDoListCommandValidator()
        {
            RuleFor(req => req.Title).NotEmpty().NotNull();
        }
    }
}