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

namespace ClientUI.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> colors = new List<string>();
        public KanbanSystemServiceClient Proxy { get; set; }
        public MainWindow(ref KanbanSystemServiceClient proxy)
        {
            InitializeComponent();
            Proxy = proxy;
        }

        private void LoadedWind(object sender, RoutedEventArgs e)
        {
            colors = new List<string> { "1", "2" };
            this.DataContext = colors;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Owner.Show();
            this.Owner.Close();
        }
    }
}
