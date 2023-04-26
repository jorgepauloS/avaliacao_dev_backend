using Microsoft.EntityFrameworkCore;
using Vectra.Avaliacao.Commons.Entities;
using Vectra.Avaliacao.DAL.Context.Interfaces;
using Vectra.Avaliacao.DAL.Repositories.Interfaces;

namespace Vectra.Avaliacao.DAL.Repositories
{
    public class ContasRepository : IContasRepository
    {
        private readonly IEFContext _context;

        public ContasRepository(IEFContext context)
        {
            _context = context;
        }

        public async Task<int> Create(Conta entity, CancellationToken cancellationToken)
        {
            await _context.Contas.AddAsync(entity: entity, cancellationToken: cancellationToken);
            return await _context.SaveChangesAsync(cancellationToken: cancellationToken);
        }

        public async Task<IEnumerable<Conta>> GetAll(CancellationToken cancellationToken)
        {
            return await _context.Contas.ToListAsync(cancellationToken: cancellationToken);
        }

        public async Task<Conta> GetById(int id, CancellationToken cancellationToken)
        {
            object[] key = { id };
            return await _context.Contas.FindAsync(keyValues: key, cancellationToken: cancellationToken);
        }

        public async Task<IEnumerable<Conta>> GetByFunction(Func<Conta, bool> function)
        {
            return await Task.FromResult(_context.Contas.Where(function));
        }

        public async Task<int> Update(Conta entity, CancellationToken cancellationToken)
        {
            _context.Contas.Update(entity: entity);
            return await _context.SaveChangesAsync(cancellationToken: cancellationToken);
        }

        public async Task<int> Delete(Conta entity, CancellationToken cancellationToken)
        {
            _context.Contas.Remove(entity: entity);
            return await _context.SaveChangesAsync(cancellationToken: cancellationToken);
        }
    }
}
