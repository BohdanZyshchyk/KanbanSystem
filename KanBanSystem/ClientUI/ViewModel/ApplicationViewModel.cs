using ClientUI.KrabServices;
using ClientUI.View;
using ClientUI.ViewModel.Commands;
using ClientUI.ViewModel.Helpers;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;

namespace ClientUI.ViewModel
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {

        private ObservableCollection<BoardDTO> myBoards;
        public RelayCommand AddCardListCommand { get; private set; }
        public UserInfo User { get; set; }

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
            set
            {
                selectedBoard = value;
                OnPropertyChange();
            }
        }
        public ApplicationViewModel()
        {
            try
            {
                AddCardListCommand = new RelayCommand(AddCardList);
                var loginWindow = Application.Current.Windows.OfType<LoginWindow>().FirstOrDefault();
                this.User = loginWindow.UserInfo;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            SetBoards();
        }

        private void AddCardList()
        {
            try
            {
                Application.Current.Dispatcher.Invoke(async () =>
                {
                    var window = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
                    var listToAdd = new CardListDTO() { Name = "test", Board = SelectedBoard, Creator = User.User };
                    await window.Proxy.AddCardListToBoardAsync(SelectedBoard, listToAdd, User.Token);
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SetBoards()
        {
            try
            {
                Application.Current.Dispatcher.Invoke(async () =>
                {
                    var window = Application.Current.Windows.OfType<LoginWindow>().FirstOrDefault();
                    var fromDB = await window.Proxy.GetBoardsAsync();
                    var boards = ArrayToObservable.ArrayToObseve(fromDB);
                    MyBoards = boards;
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChange([CallerMemberName]string propertyName = "")
        {
            try
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
