using ClientUI.Callbacks;
using ClientUI.KrabServices;
using System;
using System.Windows;
using System.Windows.Threading;

namespace ClientUI.View
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public UserDTO LoginUser
        {
            get { return (UserDTO)GetValue(LoginUserProperty); }
            set { SetValue(LoginUserProperty, value); }
        }

        public static readonly DependencyProperty LoginUserProperty =
            DependencyProperty.Register("LoginUser", typeof(UserDTO), typeof(UserRegistrationWindow), new PropertyMetadata(new UserDTO()));

        private KanbanSystemServiceClient proxy;
        public UserCallback UserCallback { get; private set; }
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var reg = new UserRegistrationWindow(ref this.proxy);
                reg.Owner = this;
                reg.RegistrationUser = this.LoginUser;
                reg.ShowDialog();
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
                UserCallback = new UserCallback();
                var instanceContext = new System.ServiceModel.InstanceContext(UserCallback);
                proxy = new KanbanSystemServiceClient(instanceContext);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void Login_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await this.Dispatcher.BeginInvoke(new Action(async() =>
                {
                    LoginUser.Password = Pswd.Password;
                    LoginUser = await proxy.LoginAsync(LoginUser);
                    var main = new MainWindow(ref this.proxy);
                    main.Owner = this;
                    main.Show();
                    this.Hide();
                    //MessageBox.Show("OK");
                }));

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
