using ClientUI.KrabServices;
using ClientUI.View;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ClientUI.UserControls
{
    /// <summary>
    /// Interaction logic for CardControl.xaml
    /// </summary>
    public partial class CardControl : UserControl
    {
        public string NameOfCard { get; set; }
        public List<Color> LabelsColors { get; set; }
        private KanbanSystemServiceClient proxy;
        public KanbanSystemServiceClient Proxy { get { return proxy; } }

        public CardControl()
        {
            InitializeComponent();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            var main = new CardWindow() { Owner = this, Proxy = this.Proxy, UserInfo = this.UserInfo };
            main.Show();
            this.Hide();
        }
    }
}
