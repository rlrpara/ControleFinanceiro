using ControleFinanceiro.Domain.Entities;
using ControleFinanceiro.Domain.Interfaces;
using System.Text;

namespace ControleFinanceiro.Infra.Data.Repositories;

public class TransacaoRepository : BaseRepository, ITransacaoRepository
{
    #region [Private Properties]
    private readonly IBaseRepository _baseRepository;
    #endregion

    #region [Private Methods]

    #endregion

    #region [Constructor]
    public TransacaoRepository(IBaseRepository baseRepository) => _baseRepository = baseRepository;
    #endregion

    #region [Public Methods]
    public async Task<IEnumerable<Transacao>> ObterTodos()
    {
        var sqlPesuisa = new StringBuilder();

        sqlPesuisa.AppendLine($"  SELECT TRANSACAO.ID AS Codigo, ");
        sqlPesuisa.AppendLine($"         TRANSACAO.TIPO AS Tipo, ");
        sqlPesuisa.AppendLine($"         TRANSACAO.NOME AS Nome, ");
        sqlPesuisa.AppendLine($"         TRANSACAO.DATA_LANCAMENTO AS DataLancamento, ");
        sqlPesuisa.AppendLine($"         TRANSACAO.VALOR AS Valor, ");
        sqlPesuisa.AppendLine($"         TRANSACAO.DATA_CADASTRO AS DataCadastro, ");
        sqlPesuisa.AppendLine($"         TRANSACAO.DATA_ATUALIZACAO AS DataAtualizacao, ");
        sqlPesuisa.AppendLine($"         TRANSACAO.ATIVO AS Ativo");
        sqlPesuisa.AppendLine($"    FROM TRANSACAO");
        sqlPesuisa.AppendLine($"ORDER BY TRANSACAO.TIPO, TRANSACAO.NOME");

        return await _baseRepository.BuscarTodosPorQueryAsync<Transacao>(sqlPesuisa.ToString());
    }
    public async Task<int> Adicionar(Transacao transacao) => await _baseRepository.AdicionarAsync(transacao);
    public async Task<int> Atualizar(Transacao transacao) => await _baseRepository.AtualizarAsync(transacao.Codigo, transacao);
    public async Task<bool> Excluir(int codigo) => await _baseRepository.ExcluirAsync<Transacao>(codigo) > 0;


    #endregion
}
