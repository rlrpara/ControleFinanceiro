using ControleFinanceiro.Domain.Interfaces;

namespace ControleFinanceiro.Infra.Database.Interface;

public interface IDatabaseConfiguration
{
    IBaseRepository GerenciarBanco();
}
