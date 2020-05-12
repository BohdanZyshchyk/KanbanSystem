using System;
using System.Windows;
using ClientUI.Callbacks;
using ClientUI.KrabServicesUserManager;

namespace ClientUI.View
{
    /// <summary>
    /// Interaction logic for UserRegistrationWindow.xaml
    /// </summary>
    public partial class UserRegistrationWindow : Window
    {
        public UserDTO User
        {
            get { return (UserDTO)GetValue(UserProperty); }
            set { SetValue(UserProperty, value); }
        }

        public static readonly DependencyProperty UserProperty =
            DependencyProperty.Register("User", typeof(UserDTO), typeof(UserRegistrationWindow), new PropertyMetadata(new UserDTO() { LoginData = new LoginDataDTO() }));

        UserManagerServiceClient proxy;
        public UserRegistrationWindow()
        {
            InitializeComponent();
        }
        public void InformAboutRegistration(string message)
        {
            try
            {
                MessageBox.Show(message, "Success!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                proxy = new UserManagerServiceClient(new System.ServiceModel.InstanceContext(new UserCallback(this)));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void Register_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                User.LoginData.Password = Pswd.Password;
                await proxy.RegisterAsync(User);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public void RedirectToLoginWindow()
        {
            try
            {
                var loginWindow = new LoginWindow();
                loginWindow.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                proxy.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
