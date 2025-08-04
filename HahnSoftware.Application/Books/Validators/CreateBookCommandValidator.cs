using FluentValidation;
using HahnSoftware.Application.Books.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HahnSoftware.Application.Books.Validators
{
    public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
    {
        public CreateBookCommandValidator()
        {
            RuleFor(b => b.Name)
                .NotEmpty().WithMessage("The name is required");

            RuleFor(b => b.Description)
                .NotEmpty().WithMessage("The description is required");

            RuleFor(b => b.Isbn)
                .NotEmpty().WithMessage("The ISBN is required")
                .MinimumLength(5).WithMessage("The ISBN should contains at least 5 characters")
                .MaximumLength(10).WithMessage("The ISBN should contains maximum 10 characters");
        }
    }
}
