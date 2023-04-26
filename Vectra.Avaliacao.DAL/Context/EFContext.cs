using Microsoft.EntityFrameworkCore;
using Vectra.Avaliacao.Commons.Entities;
using Vectra.Avaliacao.DAL.Context.Configurations;
using Vectra.Avaliacao.DAL.Context.Interfaces;

namespace Vectra.Avaliacao.DAL.Context
{
    public class EFContext : DbContext, IEFContext
    {
        public EFContext(DbContextOptions<EFContext> options) : base(options) { }
        public DbSet<Conta> Contas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EFContext).Assembly);
            modelBuilder.ApplyConfiguration(new ContaConfiguration());
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
