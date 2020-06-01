using ClientUI.KrabServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientUI.ViewModel.Helpers
{
    public static class ArrayToObservable
    {
        public static ObservableCollection<T> ArrayToObseve<T>(IEnumerable<T> items)
        {
            var observ = new ObservableCollection<T>();
            foreach (var item in items)
            {
                observ.Add(item);
            }

            return observ;
        }
    }
}
