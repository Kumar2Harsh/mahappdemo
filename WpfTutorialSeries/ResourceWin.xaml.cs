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

namespace WpfTutorialSeries
{
    /// <summary>
    /// Interaction logic for ResourceWin.xaml
    /// </summary>
    public partial class ResourceWin : Window
    {
        public ResourceWin()
        {
            InitializeComponent();
            //this.Resources["ButtonBackground"] = new SolidColorBrush(Colors.Green);

        }

        private void ChangeColor(object sender, RoutedEventArgs e)
        {
            //SolidColorBrush buttonColor = (SolidColorBrush)FindResource("ButtonBackground");
            //buttonColor.Color = Colors.Red;
            Resources["ButtonBackground"] = new SolidColorBrush(Colors.Red);
        }

        private void GreenColor(object sender, RoutedEventArgs e)
        {
            //SolidColorBrush buttonColor = (SolidColorBrush)FindResource("ButtonBackground");
            //buttonColor.Color = Colors.Green;
            Resources["ButtonBackground"] = new SolidColorBrush(Colors.Green);
        }

        private void BlueColor(object sender, RoutedEventArgs e)
        {
            //SolidColorBrush buttonColor = (SolidColorBrush)FindResource("ButtonBackground");
            //buttonColor.Color = Colors.Blue;
            Resources["ButtonBackground"] = new SolidColorBrush(Colors.Blue);
        }
    }
}
