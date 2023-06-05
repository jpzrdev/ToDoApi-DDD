using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.Commands.CreateToDo
{
    public class CreateToDoCommandValidator : AbstractValidator<CreateToDoCommandRequest>
    {
        public CreateToDoCommandValidator()
        {
            RuleFor(req => req.Description).NotEmpty().NotNull();
        }
    }
}