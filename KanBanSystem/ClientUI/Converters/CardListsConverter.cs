using ClientUI.KrabServices;
using ClientUI.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;

namespace ClientUI.Converters
{
    public class CardListsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var cardLists = value as IEnumerable<CardListDTO>;
            var lists = ArrayToObservable.ArrayToObseve<CardListDTO>(cardLists);
            return lists;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
