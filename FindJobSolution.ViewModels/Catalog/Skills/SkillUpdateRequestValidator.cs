using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindJobSolution.ViewModels.Catalog.Skills
{
    public class SkillUpdateRequestValidator : AbstractValidator<SkillUpdateRequest>
    {
        public SkillUpdateRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required!");
            RuleFor(x => x.SkillId).NotEmpty().WithMessage("Name is required!");
            RuleFor(x => x.Experience).NotEmpty().WithMessage("Name is required!");
        }
    }
}
