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
        public UserDTO RegistrationUser
        {
            get { return (UserDTO)GetValue(RegistrationUserProperty); }
            set { SetValue(RegistrationUserProperty, value); }
        }
        public static readonly DependencyProperty RegistrationUserProperty =
            DependencyProperty.Register("RegistrationUser", typeof(UserDTO), typeof(UserRegistrationWindow), new PropertyMetadata(new UserDTO()));

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
                RegistrationUser.Password = Pswd.Password;
                var result = await Proxy.RegisterAsync(RegistrationUser);
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
