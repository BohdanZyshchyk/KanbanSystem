using ClientUI.Callbacks;
using ClientUI.KrabServices;
using System;
using System.Windows;

namespace ClientUI.View
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {

        public UserInfo UserInfo
        {
            get { return (UserInfo)GetValue(UserInfoProperty); }
            set { SetValue(UserInfoProperty, value); }
        }

        public static readonly DependencyProperty UserInfoProperty =
            DependencyProperty.Register("UserInfoLogin", typeof(UserInfo), typeof(LoginWindow), new PropertyMetadata(new UserInfo { User = new UserDTO() }));

        private KanbanSystemServiceClient proxy;
        public KanbanSystemServiceClient Proxy { get { return proxy; } }
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
                reg.UserInfo = this.UserInfo;
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
                await this.Dispatcher.BeginInvoke(new Action(async () =>
                {
                    UserInfo.User.Password = Pswd.Password;
                    UserInfo = await proxy.LoginAsync(UserInfo.User);
                    var main = new MainWindow() { Owner = this, Proxy = this.Proxy, UserInfo = this.UserInfo };
                    main.Show();
                    this.Hide();
                }));

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
