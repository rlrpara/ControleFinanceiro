using ControleFinanceiro.Domain.Enum;

namespace ControleFinanceiro.CrossCutting.Util.StringExtension;

public static class StringExtension
{
    public static string MoedaSaida(this string valor, ETipoTransacao eTipoTransacao)
    {
        var valorSaida = Convert.ToDouble(valor);

        if (eTipoTransacao == ETipoTransacao.Saida)
            return (valorSaida * -1).ToString("C");

        return valorSaida.ToString("C");
    }
}
