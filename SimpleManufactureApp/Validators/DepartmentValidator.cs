using System;
using System.Linq;
using FluentValidation;
using SimpleManufactureApp.Models;

namespace SimpleManufactureApp.Validators
{
    internal class DepartmentValidator : AbstractValidator<DepartmentModel>
    {
        public DepartmentValidator()
        {
            RuleFor(x => x.DepartmentName).Must(c => c.All(char.IsLetter)).WithMessage("Department Name must contain only letters!");
        }
    }
}
