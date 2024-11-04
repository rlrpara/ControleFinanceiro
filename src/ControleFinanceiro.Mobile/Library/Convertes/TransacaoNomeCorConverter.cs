﻿using System.Globalization;

namespace ControleFinanceiro.Mobile.Library.Convertes;

public class TransacaoNomeCorConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value == null)
            return Color.FromArgb("#FFFFFF");

        var random = new Random();
        var color = string.Format("#FF{0:X6}", random.Next(0x1000000));
        return Color.FromArgb(color);
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
