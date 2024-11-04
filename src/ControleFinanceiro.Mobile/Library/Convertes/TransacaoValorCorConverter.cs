using ControleFinanceiro.Domain.Entities;
using ControleFinanceiro.Domain.Enum;
using System.Globalization;

namespace ControleFinanceiro.Mobile.Library.Convertes;

public class TransacaoValorCorConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        Transacao transacao = (Transacao)value;
        if (transacao == null)
            return Colors.Black;

        if ((ETipoTransacao)transacao.Tipo == ETipoTransacao.Entrada)
        {
            return Color.FromArgb("#FF939E5A");
        }
        else
        {
            return Colors.Red;
        }
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
