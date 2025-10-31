using FluentValidation;
using MotoRentManager.Application.Common.Interfaces;
using MotoRentManager.Domain.Entities;

namespace MotoRentManager.Application.Motos.Commands;

public record CadastrarMotoCommand(string Identificador, string Modelo, int Ano, string Placa);

public class CadastrarMotoCommnandHandler(IMotoRepository repository, IUnitOfWork unitOfWork, IValidator<CadastrarMotoCommand> validator) : ICommandHandler<CadastrarMotoCommand>
{
    public async Task ExecuteAsync(CadastrarMotoCommand command, CancellationToken cancellationToken = default)
    {
        await validator.ValidateAndThrowAsync(command, cancellationToken: cancellationToken);

        var moto = Moto.Criar(command.Identificador, command.Ano, command.Modelo, command.Placa);
        await repository.CadastrarAsync(moto, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}