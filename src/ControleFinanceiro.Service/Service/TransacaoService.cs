using ControleFinanceiro.Domain.Entities;
using ControleFinanceiro.Domain.Interfaces;
using ControleFinanceiro.Infra.Data.Repositories;
using ControleFinanceiro.Service.Interface;

namespace ControleFinanceiro.Service.Service;

public class TransacaoService : BaseService, ITransacaoService
{
    #region [Private Properties]
    private readonly ITransacaoRepository _transacaoRepository;
    #endregion

    #region [Private Methods]

    #endregion

    #region [Constructor]

    public TransacaoService(IBaseRepository baseRepository) : base(baseRepository)
    {
        _transacaoRepository = new TransacaoRepository(baseRepository);
    }
    #endregion

    #region [Public Methods]
    public IEnumerable<Transacao> ObterTodos() => _transacaoRepository.ObterTodos().Result;
    public int Adicionar(Transacao transacao) => _transacaoRepository.Adicionar(transacao).Result;
    public int Atualizar(Transacao transacao) => _transacaoRepository.Atualizar(transacao).Result;
    public bool Excluir<Transacao>(int Codigo) => _transacaoRepository.Excluir(Codigo).Result;
    #endregion
}
