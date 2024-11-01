using ControleFinanceiro.Domain.ValueObjects;
using System.Data;

namespace ControleFinanceiro.Infra.Data.Context;

public class ConnectionConfiguration
{
    #region [Métodos Privados]
    private static IDbConnection? Inicia(IDbConnection? conexao)
    {
        try
        {
            if (conexao != null)
            {
                if (conexao.State == ConnectionState.Open) conexao.Close();
                if (conexao.State == ConnectionState.Closed) conexao.Open();
            }
            return conexao;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    #endregion

    #region Métodos Públicos
    public static IDbConnection? AbrirConexao(ParametrosConexao parametrosConexao) => Inicia(new DeafultSqlConnectionFactory(parametrosConexao).Conexao());
    #endregion
}
