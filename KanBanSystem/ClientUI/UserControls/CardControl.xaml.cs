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
        public CardsListControl Owner
        {
            get { return (CardsListControl)GetValue(OwnerProperty); }
            set { SetValue(OwnerProperty, value); }
        }


        public ICollection<UserDTO> AssignedUsers
        {
            get { return (ICollection<UserDTO>)GetValue(UsersProperty); }
            set { SetValue(UsersProperty, value); }
        }

        public static readonly DependencyProperty UsersProperty =
            DependencyProperty.Register("AssignedUsers", typeof(ICollection<UserDTO>), typeof(CardControl), new PropertyMetadata(null));


        public static readonly DependencyProperty OwnerProperty =
            DependencyProperty.Register("Owner", typeof(CardsListControl), typeof(CardControl), new PropertyMetadata(null));

        public string NameOfCard
        {
            get { return (string)GetValue(CardNameProperty); }
            set { SetValue(CardNameProperty, value); }
        }

        public static readonly DependencyProperty CardNameProperty =
            DependencyProperty.Register("NameOfCard", typeof(string), typeof(CardControl), new PropertyMetadata(""));


        public ICollection<LabelColorDTO> ColorsOfLabels
        {
            get { return (ICollection<LabelColorDTO>)GetValue(LabelColorsProperty); }
            set { SetValue(LabelColorsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LabelColors.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LabelColorsProperty =
            DependencyProperty.Register("ColorsOfLabels", typeof(ICollection<LabelColorDTO>), typeof(CardControl), new PropertyMetadata(null));

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
    }
}
