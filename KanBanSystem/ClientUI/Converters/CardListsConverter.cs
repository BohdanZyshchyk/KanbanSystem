using ClientUI.KrabServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ClientUI.Converters
{
    public class CardListsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var cardLists = value as ICollection<CardListDTO>;
            var lists = new ObservableCollection<CardListDTO>();
            foreach (var cl in cardLists)
            {
                lists.Add(cl);
            }
            return lists;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
