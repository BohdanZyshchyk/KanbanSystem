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
using ClientUI.View;
using ClientUI.ViewModel.Helpers;

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
        public ApplicationViewModel()
        {
            SetBoards();
        }
        private void SetBoards()
        {
            Application.Current.Dispatcher.Invoke(async () =>
            {
                var window = Application.Current.Windows.OfType<LoginWindow>().FirstOrDefault();
                var fromDB = await window.Proxy.GetBoardsAsync();
                var boards = ArrayToObservable.ArrayToObseve(fromDB);
                MyBoards = boards;
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChange([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
