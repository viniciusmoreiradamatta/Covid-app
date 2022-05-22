using CovidService.Domain.Models;
using FluentValidation;

namespace CovidService.Domain.Validations
{
    public class CovidValidations : AbstractValidator<Covid>
    {
        public CovidValidations()
        {
            RuleFor(c => c.Id).NotEmpty().WithMessage("Id não pode estar invalido");
            RuleFor(c => c.Country).NotEmpty().WithMessage("Country deve ser informado");

            RuleFor(c => c.Cases).GreaterThanOrEqualTo(c => c.Deaths)
                .WithMessage("Numero de mortes nao deve ser maior que o numero de casos");
            RuleFor(c => c.Cases).GreaterThanOrEqualTo(c => c.Confirmed)
                .WithMessage("Numero de casos confirmados nao deve ser maior que o numero de casos");
            RuleFor(c => c.Cases).GreaterThanOrEqualTo(c => c.Recovered)
                .WithMessage("Numero de casos recuperados nao deve ser maior que o numero de casos");

            RuleFor(c => c).Must(c => c.Confirmed >= (c.Deaths + c.Recovered))
                .WithMessage("Numero de casos confirmados nao deve ser menor que a soma de mortes e recuperados");
        }
    }
}
