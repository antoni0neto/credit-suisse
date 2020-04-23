using FluentValidation;

namespace DevIO.Business.Models.Validations
{
    public class TradeValidation : AbstractValidator<Trade>
    {
        public TradeValidation()
        {
            RuleFor(c => c.Value)
                .GreaterThan(0).WithMessage("O campo {PropertyName} precisa ser maior que {ComparisonValue}");
        }
    }
}