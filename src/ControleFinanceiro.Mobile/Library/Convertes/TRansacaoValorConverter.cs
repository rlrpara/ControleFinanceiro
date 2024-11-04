using ControleFinanceiro.Domain.Entities;
using ControleFinanceiro.Domain.Enum;
using System.Globalization;

namespace ControleFinanceiro.Mobile.Library.Convertes;

public class TRansacaoValorConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        Transacao transacao = (Transacao)value;
        if (transacao == null)
            return "";

        if ((ETipoTransacao)transacao.Tipo == ETipoTransacao.Entrada)
        {
            return double.Parse(transacao.Valor).ToString("C");
        }
        else
        {
            return $"- {double.Parse(transacao.Valor):C}";
        }
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
