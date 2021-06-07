using System;
using System.Linq;
using FluentValidation;
using SimpleManufactureApp.Models;

namespace SimpleManufactureApp.Validators
{
    class EmployeeValidator:AbstractValidator<EmployeeModel>
    {
        public EmployeeValidator()
        {
            RuleFor(e => e.FirstName).Must(c => c.All(char.IsLetter))
                .WithMessage("First Name must contain only letters!");
            RuleFor(e => e.MiddleName).Must(c => c.All(char.IsLetter))
                .WithMessage("Middle Name must contain only letters!");
            RuleFor(e => e.LastName).Must(c => c.All(char.IsLetter))
                .WithMessage("Last Name must contain only letters!");
            RuleFor(e => e.Position).Must(c => c.All(char.IsLetter))
                .WithMessage("Position must contain only letters!");
            RuleFor(e => e.BirthDate).NotEmpty().WithMessage("Birth date cannot be empty");
            RuleFor(e => e.DepartmentId).NotEmpty().WithMessage("Department id cannot be empty");
            RuleForEach(e => e.Missions).SetValidator(new MissionValidator());
        }
    }
}
