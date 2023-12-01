using MediatR;
using Questao5.Application.Commands;
using Questao5.Application.Commands.Responses;
using Questao5.Application.Validators;
using Questao5.Infrastructure.Database.CommandStore;
using Questao5.Infrastructure.Database.QueryStore;

namespace Questao5.Application.Handlers
{
    public class CreateMovimentCommandHandler : IRequestHandler<CreateMovimentoCommand, MovimentoResponse>
    {
        private readonly ICommandRepository _commandRepository;
        private readonly IQueryRepository _queryRepository;

        public CreateMovimentCommandHandler(ICommandRepository commandRepository, IQueryRepository queryRepository)
        {
            _commandRepository = commandRepository;
            _queryRepository = queryRepository;
        }

        public async Task<MovimentoResponse> Handle(CreateMovimentoCommand request, CancellationToken cancellationToken)
        {
            
            validationCommand(request);
             
            var validAccount = await _queryRepository.GetContaCorrenteById(request.IdContacorrente);

            if(validAccount.Ativo.Equals("A"))
            {
                var insertResult = await _commandRepository.CreateMovimento(request); 

                var response = new MovimentoResponse(
                                        insertResult, 
                                        request.IdContacorrente,
                                        request.DataMovimento,
                                        request.TipoMovimento,
                                        request.Valor
                                        );
                return response;
            }

            throw new Exception(String.Format("Conta id {0} está inativa.", request.IdContacorrente));
        }
        
        private bool validationCommand(CreateMovimentoCommand command)
        {
            var validateRequest = new CreateMovimentoCommandValidation();
            
            if(validateRequest.Validate(command).IsValid.Equals(false)) 
            { 
                throw new Exception(validateRequest.Validate(command).Errors.ToString());
            }

            return true;
        }
    }
}