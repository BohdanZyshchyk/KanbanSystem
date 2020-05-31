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
    /// Interaction logic for BoardControl.xaml
    /// </summary>
    public partial class BoardControl : UserControl
    {
        public string BoardName
        {
            get { return (string)GetValue(BoardNameProperty); }
            set { SetValue(BoardNameProperty, value); }
        }

        public static readonly DependencyProperty BoardNameProperty =
            DependencyProperty.Register("BoardName", typeof(string), typeof(BoardControl), new PropertyMetadata(""));


        public BoardControl()
        {
            InitializeComponent();
        }
    }
}
