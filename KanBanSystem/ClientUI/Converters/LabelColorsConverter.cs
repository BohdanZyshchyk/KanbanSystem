using ClientUI.KrabServices;
using ClientUI.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;

namespace ClientUI.Converters
{
    public class LabelColorsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var labelColors = value as IEnumerable<LabelColorDTO>;
            var colors = ArrayToObservable.ArrayToObserve<LabelColorDTO>(labelColors);
            return colors;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
