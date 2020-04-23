using FluentValidation;

namespace DevIO.Business.Models.Validations
{
    public class TradeValidation : AbstractValidator<Trade>
    {
        public TradeValidation()
        {
            RuleFor(c => c.ClientSector)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 150).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.Value)
                .GreaterThan(0).WithMessage("O campo {PropertyName} precisa ser maior que {ComparisonValue}");
        }
    }
}