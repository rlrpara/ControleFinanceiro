using System.Globalization;

namespace ControleFinanceiro.Mobile.Library.Convertes;

public class TransacaoNomeConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if(value == null)
            return "";

        var nome = (string)value;

        return nome.ToUpper()[0].ToString();
        throw new NotImplementedException();
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
