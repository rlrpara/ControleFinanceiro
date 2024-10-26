using ControleFinanceiro.Mobile.Models;

namespace ControleFinanceiro.Mobile.Interfaces;

public interface ITransacaoRepository
{
    void Adicionar(Transacao transacao);
    void Atualizacao(Transacao transacao);
    void Deletar(int id);
    List<Transacao> ObterTodos();
}
