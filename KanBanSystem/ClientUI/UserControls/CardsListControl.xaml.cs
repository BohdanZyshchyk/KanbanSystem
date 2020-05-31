using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for CardsListControl.xaml
    /// </summary>
    public partial class CardsListControl : UserControl
    {
        public string CardListName
        {
            get { return (string)GetValue(CardListNameProperty); }
            set { SetValue(CardListNameProperty, value); }
        }

        public static readonly DependencyProperty CardListNameProperty =
            DependencyProperty.Register("CardListName", typeof(string), typeof(CardsListControl), new PropertyMetadata(""));


        public IEnumerable<CardControl> Cards
        {
            get { return (IEnumerable< CardControl>)GetValue(CardsProperty); }
            set { SetValue(CardsProperty, value); }
        }

        public static readonly DependencyProperty CardsProperty =
            DependencyProperty.Register("Cards", typeof(IEnumerable< CardControl>), typeof(CardsListControl), new PropertyMetadata(new ObservableCollection<CardControl>()));


        public CardsListControl()
        {
            InitializeComponent();
        }
    }
}
