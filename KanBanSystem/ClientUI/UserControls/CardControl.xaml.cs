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
        public IEnumerable<UserDTO> AssignedUsers
        {
            get { return (IEnumerable<UserDTO>)GetValue(AssignedUsersProperty); }
            set { SetValue(AssignedUsersProperty, value); }
        }

        public static readonly DependencyProperty AssignedUsersProperty =
            DependencyProperty.Register("AssignedUsers", typeof(IEnumerable<UserDTO>), typeof(CardControl), new PropertyMetadata(null));

        public string NameOfCard
        {
            get { return (string)GetValue(NameOfCardProperty); }
            set { SetValue(NameOfCardProperty, value); }
        }

        public static readonly DependencyProperty NameOfCardProperty =
            DependencyProperty.Register("NameOfCard", typeof(string), typeof(CardControl), new PropertyMetadata(""));


        public IEnumerable<LabelColorDTO> ColorsOfLabels
        {
            get { return (IEnumerable<LabelColorDTO>)GetValue(ColorsOfLabelsProperty); }
            set { SetValue(ColorsOfLabelsProperty, value); }
        }

        public static readonly DependencyProperty ColorsOfLabelsProperty =
            DependencyProperty.Register("ColorsOfLabels", typeof(IEnumerable<LabelColorDTO>), typeof(CardControl), new PropertyMetadata(null));

        private KanbanSystemServiceClient proxy;
        public KanbanSystemServiceClient Proxy { get { return proxy; } }

        public CardControl()
        {
            InitializeComponent();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            //MainWindow parentWindow = MainWindow.GetWindow();
            //var main = new MainWindow() { Owner = this, Proxy = this.Proxy, UserInfo = this.UserInfo };
            //main.Show();
            //this.Hide();
            
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            var name = this.NameOfCard;
        }
    }
}
