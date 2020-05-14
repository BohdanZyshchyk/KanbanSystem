using ClientUI.KrabServices;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;


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
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Owner.Show();
            this.Owner.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void comb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //lvCardsList.Items.Clear();
            var source1 = lvCardsList.ItemsSource;
            var items = new List<CardListDTO>();
            var cards = new List<CardDTO>();
            var colors = new List<LabelColorDTO>();
            foreach (var i in lvCardsList.Items)
            {
                items.Add(i as CardListDTO);
                cards.AddRange((i as CardListDTO).Cards);
            }
            foreach (var c in cards)
            {
                colors.AddRange(c.LabelColors);
            }
            //var color = colors.FirstOrDefault();
        }

        private void lvCardsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //lvCards.Items.Clear();
        }
    }
}
