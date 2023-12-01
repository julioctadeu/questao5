using Questao5.Application.Validators;
using FluentValidation.TestHelper;
using Xunit;
using Questao5.Application.Commands;

namespace Questao5.Tests.Application
{
    public class CreateMovimentoCommandValidationTests
    {

        public CreateMovimentoCommandValidationTests()
        {
        }


        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("12345678901212345678912345678912345678912345678123456789012345678")]
        public void idConta_Invalida(string idConta)
        {
            
            var validation = new CreateMovimentoCommandValidation();

            var command = new CreateMovimentoCommand(idConta, "05/05/2015", "C", 127);

            TestValidationResult<CreateMovimentoCommand> result = validation.TestValidate(command);

            result.ShouldHaveValidationErrorFor(x => x.IdContacorrente);
        }

        [Fact]
        public void idConta_valida()
        {
            var guidWord = Guid.NewGuid().ToString();
            
            var validation = new CreateMovimentoCommandValidation();

            var command = new CreateMovimentoCommand(guidWord, "05/05/2015", "C", 127);

            TestValidationResult<CreateMovimentoCommand> result = validation.TestValidate(command);

            result.ShouldNotHaveValidationErrorFor(x => x.IdContacorrente);
        }

        [Theory]
        [InlineData("")]
        [InlineData("fasfdasdmfla")]
        [InlineData("0987654345678")]
        public void prop_invalida(string data)
        {
            var guidWord = Guid.NewGuid().ToString();
            
            var validation = new CreateMovimentoCommandValidation();

            var command = new CreateMovimentoCommand(guidWord, data, "C", 127);

            TestValidationResult<CreateMovimentoCommand> result = validation.TestValidate(command);

            result.ShouldHaveValidationErrorFor(x => x.DataMovimento);
        }

        [Fact]
        public void data_valida()
        {
            var guidWord = Guid.NewGuid().ToString();
            
            var validation = new CreateMovimentoCommandValidation();

            var command = new CreateMovimentoCommand(guidWord, "05/05/2015", "C", 127);

            TestValidationResult<CreateMovimentoCommand> result = validation.TestValidate(command);

            result.ShouldNotHaveValidationErrorFor(x => x.DataMovimento);
        }

        [Theory]
        [InlineData("k")]
        [InlineData(null)]
        [InlineData("")]
        public void tipo_invalido(string tipo)
        {
            var guidWord = Guid.NewGuid().ToString();
            
            var validation = new CreateMovimentoCommandValidation();

            var command = new CreateMovimentoCommand(guidWord, "05/05/2015", tipo, 127);

            TestValidationResult<CreateMovimentoCommand> result = validation.TestValidate(command);

            result.ShouldHaveValidationErrorFor(x => x.TipoMovimento);
        }

        [Theory]
        [InlineData("C")]
        [InlineData("D")]
        public void tipo_valido(string tipo)
        {
            var guidWord = Guid.NewGuid().ToString();
            
            var validation = new CreateMovimentoCommandValidation();

            var command = new CreateMovimentoCommand(guidWord, "05/05/2015", tipo, 127);

            TestValidationResult<CreateMovimentoCommand> result = validation.TestValidate(command);

            result.ShouldNotHaveValidationErrorFor(x => x.TipoMovimento);
        }

        [Theory]
        [InlineData(-1234)]
        public void valor_invalido(int valor)
        {
            var guidWord = Guid.NewGuid().ToString();
            
            var validation = new CreateMovimentoCommandValidation();

            var command = new CreateMovimentoCommand(guidWord, "05/05/2015", "D", valor);

            TestValidationResult<CreateMovimentoCommand> result = validation.TestValidate(command);

            result.ShouldHaveValidationErrorFor(x => x.Valor);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(10)]
        public void valor_valido(int valor)
        {
            var guidWord = Guid.NewGuid().ToString();
            
            var validation = new CreateMovimentoCommandValidation();

            var command = new CreateMovimentoCommand(guidWord, "05/05/2015", "D", valor);

            TestValidationResult<CreateMovimentoCommand> result = validation.TestValidate(command);

            result.ShouldNotHaveValidationErrorFor(x => x.Valor);
        }
        
    }
}