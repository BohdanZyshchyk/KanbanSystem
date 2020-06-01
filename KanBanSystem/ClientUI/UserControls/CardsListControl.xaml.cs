using ClientUI.KrabServices;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

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


        public IEnumerable<CardDTO> ListCards
        {
            get { return (IEnumerable<CardDTO>)GetValue(ListCardsProperty); }
            set { SetValue(ListCardsProperty, value); }
        }

        public static readonly DependencyProperty ListCardsProperty =
            DependencyProperty.Register("ListCards", typeof(IEnumerable<CardDTO>), typeof(CardsListControl), new PropertyMetadata(null));


        public CardsListControl()
        {
            InitializeComponent();
            
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            var name = this.CardListName;
            var cards = this.ListCards;
        }
    }
}
