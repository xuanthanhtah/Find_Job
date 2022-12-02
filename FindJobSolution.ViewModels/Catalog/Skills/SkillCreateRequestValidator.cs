using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindJobSolution.ViewModels.Catalog.Skills
{
    public class SkillCreateRequestValidator : AbstractValidator<SkillCreateRequest>
    {
        public SkillCreateRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
        }
    }
}
