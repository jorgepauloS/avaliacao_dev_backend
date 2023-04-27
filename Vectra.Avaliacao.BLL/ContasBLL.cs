using Vectra.Avaliacao.BLL.Interfaces;
using Vectra.Avaliacao.Commons.Entities;
using Vectra.Avaliacao.Commons.Exceptions;
using Vectra.Avaliacao.DAL.Repositories.Interfaces;

namespace Vectra.Avaliacao.BLL
{
    public class ContasBLL : IContasBLL
    {
        private readonly IContasRepository _repository;
        public ContasBLL(IContasRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Create(Conta entity, CancellationToken cancellationToken)
        {
            return await _repository.Create(entity, cancellationToken);
        }

        public async Task<int> Delete(int id, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetById(id, cancellationToken) ?? throw new BusinessRuleException("Id de conta inválido");
            return await _repository.Delete(entity, cancellationToken);
        }

        public async Task<IEnumerable<Conta>> GetAll(CancellationToken cancellationToken)
        {
            return await _repository.GetAll(cancellationToken);
        }

        public async Task<IEnumerable<Conta>> GetByFunction(Func<Conta, bool> function)
        {
            return await _repository.GetByFunction(function);
        }

        public async Task<Conta> GetById(int id, CancellationToken cancellationToken)
        {
            return await _repository.GetById(id, cancellationToken) ?? throw new BusinessRuleException("Id de conta inválido");
        }

        public async Task<int> Update(int id, Conta entity, CancellationToken cancellationToken)
        {
            var conta = await _repository.GetById(id, cancellationToken) ?? throw new BusinessRuleException("Id de conta inválido");
            
            conta.Agencia = entity.Agencia;
            conta.Numero = entity.Numero;
            conta.Cliente = entity.Cliente;
            conta.Saldo = entity.Saldo;
            conta.UpdatedAt = entity.UpdatedAt;
            conta.IsActive = entity.IsActive;

            return await _repository.Update(conta, cancellationToken);
        }
    }
}
