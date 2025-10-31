using MotoRentManager.Domain.Entities;

namespace MotoRentManager.Application.Common.Interfaces
{
    public interface IMotoRepository
    {
        Task CadastrarAsync(Moto moto, CancellationToken cancellationToken = default);
        Task<Moto?> ObterParaAtualizacaoAsync(Guid id, CancellationToken cancellationToken = default);
        Task<bool> VerificarExistenciaPorPlacaAsync(string placa, Guid? id = default);
    }
}
