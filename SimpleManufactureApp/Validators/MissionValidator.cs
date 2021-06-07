using System;
using System.Linq;
using FluentValidation;
using SimpleManufactureApp.Models;

namespace SimpleManufactureApp.Validators
{
    class MissionValidator : AbstractValidator<MissionModel>
    {
        public MissionValidator()
        {
            RuleFor(m => m.MissionName).Must(c => c.All(char.IsLetter))
                .WithMessage("Mission Name must contain only letters!");
            RuleFor(m => m.Description).NotEmpty().WithMessage("Description cannot be empty");
            RuleFor(m => m.StartDate).NotEmpty().WithMessage("Start date cannot be empty");
            RuleFor(m => m.EndDate).NotEmpty().WithMessage("Start date cannot be empty");
        }
    }
}
