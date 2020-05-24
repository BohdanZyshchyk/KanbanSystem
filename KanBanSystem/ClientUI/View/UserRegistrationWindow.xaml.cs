using ClientUI.KrabServices;
using System;
using System.Windows;

namespace ClientUI.View
{
    /// <summary>
    /// Interaction logic for UserRegistrationWindow.xaml
    /// </summary>
    public partial class UserRegistrationWindow : Window
    {
        public UserInfo UserInfo
        {
            get { return (UserInfo)GetValue(UserInfoProperty); }
            set { SetValue(UserInfoProperty, value); }
        }

        public static readonly DependencyProperty UserInfoProperty =
            DependencyProperty.Register("UserInfoRegister", typeof(UserInfo), typeof(UserRegistrationWindow), new PropertyMetadata(new UserInfo { User = new UserDTO() }));

        public KanbanSystemServiceClient Proxy { get; set; }

        public UserRegistrationWindow(ref KanbanSystemServiceClient proxy)
        {
            InitializeComponent();
            Proxy = proxy;
        }

        private async void Register_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                UserInfo.User.Password = Pswd.Password;
                var result = await Proxy.RegisterAsync(UserInfo.User);
                if (result)
                {
                    var msg = (this.Owner as LoginWindow).UserCallback.Message;
                    MessageBox.Show(msg, "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    RedirectToLoginWindow();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void RedirectToLoginWindow()
        {
            try
            {
                this.Owner.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
