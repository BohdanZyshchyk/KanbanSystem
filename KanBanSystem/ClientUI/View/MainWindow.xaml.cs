using ClientUI.KrabServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ClientUI.ViewModel;
using ClientUI.ViewModel.Helpers;


namespace ClientUI.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public KanbanSystemServiceClient Proxy { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            this.Proxy = (this.Owner as LoginWindow).Proxy;
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Owner.Show();
            this.Owner.Close();
        }
    }
}
