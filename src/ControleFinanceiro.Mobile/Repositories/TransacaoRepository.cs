using ControleFinanceiro.Mobile.Interfaces;
using ControleFinanceiro.Mobile.Models;
using LiteDB;

namespace ControleFinanceiro.Mobile.Repositories;

public class TransacaoRepository : ITransacaoRepository
{
    #region [Private Properties]
    private readonly LiteDatabase _database;
    private readonly string CollectionName = "transactions";
    #endregion

    #region [Constructor]
    public TransacaoRepository() => _database = new LiteDatabase("Filename=");
    #endregion

    #region [Public Methods]
    public List<Transacao> ObterTodos() => _database.GetCollection<Transacao>(CollectionName).Query().OrderByDescending(x => x.Data).ToList();
    public void Adicionar(Transacao transacao) => _database.GetCollection<Transacao>(CollectionName).Insert(transacao);
    public void Atualizacao(Transacao transacao) => _database.GetCollection<Transacao>(CollectionName).Update(transacao);
    public void Deletar(int id) => _database.GetCollection<Transacao>(CollectionName).Delete(id);
    #endregion
}
