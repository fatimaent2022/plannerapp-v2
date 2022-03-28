using FluentValidation;
using PlanerApp.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanerApp.Shared.Validators
{
    public class RegisterRequestValidator:AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidator()
        {
            RuleFor(p => p.Email)
                    .NotEmpty()
                    .WithMessage("Email is required")
                    .EmailAddress().
                    WithMessage("Your address is not valid");

            RuleFor(p => p.FirstName)
                  .NotEmpty()
                  .WithMessage("First Name is required")
                  .MaximumLength(25).
                  WithMessage("First Name must be less than 25 characters.");

            RuleFor(p => p.LastName)
                 .NotEmpty()
                 .WithMessage("Last Name is required")
                 .MaximumLength(25).
                 WithMessage("Last Name must be less than 25 characters.");

            RuleFor(p => p.Password)
                 .NotEmpty()
                 .WithMessage("Password is required")
                 .MinimumLength(6).
                 WithMessage("Password must be minimum 6 characters.");

            RuleFor(p => p.ConfirmPassword)
                .Equal(p => p.Password)
               .WithMessage("Confirm Password doesn't match the password.");
               

        }
    }
}
