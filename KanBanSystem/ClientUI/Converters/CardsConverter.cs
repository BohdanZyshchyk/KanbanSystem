using ClientUI.KrabServices;
using ClientUI.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;

namespace ClientUI.Converters
{
    public class CardsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var cards = value as IEnumerable<CardDTO>;
            var lists = ArrayToObservable.ArrayToObseve<CardDTO>(cards);
            return lists;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
