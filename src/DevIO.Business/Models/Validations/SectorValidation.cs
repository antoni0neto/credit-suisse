using FluentValidation;

namespace DevIO.Business.Models.Validations
{
    public class SectorValidation : AbstractValidator<Sector>
    {
        public SectorValidation()
        {
            RuleFor(c => c.Description)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");
        }
    }
}