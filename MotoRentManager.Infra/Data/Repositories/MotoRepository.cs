using Microsoft.EntityFrameworkCore;
using MotoRentManager.Application.Common.Interfaces;
using MotoRentManager.Domain.Entities;

namespace MotoRentManager.Infra.Data.Repositories
{
    public class MotoRepository(ApplicationDbContext context) : IMotoRepository
    {
        private DbSet<Moto> Motos => context.Set<Moto>();

        public async Task CadastrarAsync(Moto moto, CancellationToken cancellationToken = default)
        {
            await Motos.AddAsync(moto, cancellationToken);
        }

        public async Task<Moto?> ObterParaAtualizacaoAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await Motos.FindAsync([id], cancellationToken: cancellationToken);
        }

        public async Task<bool> VerificarExistenciaPorPlacaAsync(string placa, Guid? id = default)
        {
            var query =  Motos.Where(m => m.Placa == placa);

            if (id.HasValue)            
                query = query.Where(m => m.Id != id);            

            return await query.AnyAsync();
        }
    }
}
