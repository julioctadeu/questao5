using System.Globalization;
using System.Text.RegularExpressions;
using FluentValidation;
using Questao5.Application.Commands;

namespace Questao5.Application.Validators
{
    public class CreateMovimentoCommandValidation : AbstractValidator<CreateMovimentoCommand>
    {

        public CreateMovimentoCommandValidation()
        {
            var typeAccount = new List<string>{ "D", "C" }; 

            RuleFor(p => p.DataMovimento)
                .NotNull()
                .WithMessage("Deve preencher a data.")
                .Must(validateDate)
                .WithMessage("Deve preencher corretamente a data.");

            RuleFor(p => p.IdContacorrente)
                .NotNull()
                .WithMessage("Deve preencher o IdContaCorrente.")
                .MaximumLength(37)
                .WithMessage("O tamanho maximo do IdContaCorrente é 37")
                .NotEmpty()
                .WithMessage("Deve preencher corretamente o IdContaCorrente.");

            RuleFor(p => p.TipoMovimento)
                .NotNull()
                .WithMessage("Deve preencher o tipo de movimento.")
                .Must(typeAccount.Contains)
                .WithMessage("Deve preencher corretamente o tipo de movimento.");

            RuleFor(p => p.Valor)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Deve preencher corretamente o valor.");
        }

        public bool validateDate(string data)
        {
            Regex ok = new Regex(@"(\d{2}\/\d{2}\/\d{4})");
            return ok.Match(data).Success;
        }

        public bool isValid(CreateMovimentoCommand command)
        {
            return Validate(command).IsValid;
        }

        internal void ShouldNotHaveValidationErrorFor(Func<object, object> value)
        {
            throw new NotImplementedException();
        }
    }
}