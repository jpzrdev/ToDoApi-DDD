using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.Commands.Todo.ChangeDone
{
    public class ChangeDoneCommandValidator : AbstractValidator<ChangeDoneCommandRequest>
    {
        public ChangeDoneCommandValidator()
        {
            RuleFor(req => req.Id).NotEmpty().NotNull();
        }
    }
}