using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ClientUI.KrabServices;

namespace ClientUI.ViewModel
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {

        private ObservableCollection<BoardDTO> myBoards;

        public ObservableCollection<BoardDTO> MyBoards
        {
            get
            {
                return myBoards;
            }
            set
            {
                if (myBoards == value)
                    return;
                myBoards = value;
                OnPropertyChange();
            }
        }

        private BoardDTO selectedBoard;

        public BoardDTO SelectedBoard
        {
            get { return selectedBoard; }
            set { selectedBoard = value; }
        }

        public ApplicationViewModel(ObservableCollection<BoardDTO> board)
        {
            MyBoards = board;
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChange([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
