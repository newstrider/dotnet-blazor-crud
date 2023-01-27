using FluentValidation;

namespace Blazorcrud.Shared.Models
{
    public class SkillValidator : AbstractValidator<Skill>
    {
        public SkillValidator()
        {
            CascadeMode = CascadeMode.Stop;

            RuleFor(skill => skill.Name).NotEmpty().WithMessage("Skill name is a required field.");
        }
    }
}