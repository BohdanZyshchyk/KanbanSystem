using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ClientUI.KrabServices;
using ClientUI.View;
using ClientUI.ViewModel.Commands;
using ClientUI.ViewModel.Helpers;

namespace ClientUI.ViewModel
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {

        private ObservableCollection<BoardDTO> myBoards;
        public RelayCommand AddCardListCommand { get; private set; }

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
            AddCardListCommand = new RelayCommand(AddCardList);
        }

        private void AddCardList()
        {
            MessageBox.Show("Hello");

            //Application.Current.Dispatcher.Invoke(async () =>
            //{
            //    var window = Application.Current.Windows.OfType<LoginWindow>().FirstOrDefault();
            //    var listToAdd = new CardListDTO() { Name = "test", Board = SelectedBoard };
            //    await window.Proxy.AddCardListToBoardAsync(SelectedBoard, listToAdd, "t@gmail.com");
            //});
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
