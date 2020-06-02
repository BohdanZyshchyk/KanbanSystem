using ClientUI.KrabServices;
using ClientUI.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ClientUI.Converters
{
    public class UsersConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var userDTOs = value as IEnumerable<UserDTO>;
            var users = ArrayToObservable.ArrayToObserve<UserDTO>(userDTOs);
            return users;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
