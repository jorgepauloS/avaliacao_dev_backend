using Vectra.Avaliacao.Commons.Entities;

namespace Vectra.Avaliacao.DAL.Repositories.Interfaces
{
    public interface IBaseRepository<T, K> where T : BaseEntity<K>
    {
        public Task<int> Create(T entity, CancellationToken cancellationToken);
        public Task<IEnumerable<T>> GetAll(CancellationToken cancellationToken);
        public Task<T> GetById(K id, CancellationToken cancellationToken);
        public Task<IEnumerable<T>> GetByFunction(Func<T, bool> function);
        public Task<int> Update(T entity, CancellationToken cancellationToken);
        public Task<int> Delete(T entity, CancellationToken cancellationToken);
    }
}
