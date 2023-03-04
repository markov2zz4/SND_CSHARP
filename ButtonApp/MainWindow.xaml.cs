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

namespace ButtonApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            foreach (UIElement el in MainGrid.Children)
            {
                if (el is Button)
                {
                    ((Button) el).Click += Button_Click;
                    
                }
            }

        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();

            int r = rnd.Next(0, 257);
            int g = rnd.Next(0, 257);
            int b = rnd.Next(0, 257);

            

            foreach (UIElement el in MainGrid.Children)
            {
                if (el is Button)
                {
                    ((Button)el).Background = new SolidColorBrush(Color.FromRgb((byte)r, (byte)g, (byte)b));

                }
            }

            //btn_0.Background = new SolidColorBrush(Color.FromRgb((byte)r, (byte)g, (byte)b));
        }
    }
}
