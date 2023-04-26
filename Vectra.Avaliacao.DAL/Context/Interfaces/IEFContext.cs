using Microsoft.EntityFrameworkCore;
using Vectra.Avaliacao.Commons.Entities;

namespace Vectra.Avaliacao.DAL.Context.Interfaces
{
    public interface IEFContext
    {
        DbSet<Conta> Contas { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
