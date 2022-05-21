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

namespace View.Views.Components
{
    /// <summary>
    /// Interaction logic for MealCard.xaml
    /// </summary>
    public partial class MealCardAdmin : UserControl
    {
        public MealCardAdmin()
        {
            InitializeComponent();
        }

        private void Image_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {
            ((Image)sender).Source = new BitmapImage(new Uri("Resources/no-image.png", UriKind.Relative));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
