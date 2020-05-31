using ClientUI.KrabServices;
using System.Windows;
using System.Windows.Controls;


namespace ClientUI.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public KanbanSystemServiceClient Proxy { get; set; }


        public UserInfo UserInfo
        {
            get { return (UserInfo)GetValue(UserInfoProperty); }
            set { SetValue(UserInfoProperty, value); }
        }

        public static readonly DependencyProperty UserInfoProperty =
            DependencyProperty.Register("UserInfoMain", typeof(UserInfo), typeof(MainWindow), new PropertyMetadata(new UserInfo()));

        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Owner.Show();
            this.Owner.Close();
        }

        private void Card_WindowOpen(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            //TO DO new CardWindow
        }
    }
}
