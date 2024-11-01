using ControleFinanceiro.Domain.Entities;

namespace ControleFinanceiro.Domain.Interfaces;

public interface ITransacaoRepository : IBaseRepository
{
    Task<int> Adicionar(Transacao transacao);
    Task<int> Atualizar(Transacao transacao);
    Task<bool> Excluir(int codigo);
    IEnumerable<Transacao> ObterTodos();
}
