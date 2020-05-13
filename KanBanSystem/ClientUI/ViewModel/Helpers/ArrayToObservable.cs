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
        public static ObservableCollection<BoardDTO> ArrayToObseve(BoardDTO [] boards)
        {
            ObservableCollection<BoardDTO> observBoards = new ObservableCollection<BoardDTO>();
            foreach (var item in boards)
            {
                observBoards.Add(item);
            }

            return observBoards;
        }
    }
}
