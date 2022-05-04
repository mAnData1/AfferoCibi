using Data.ViewModels;
using Microsoft.Win32;
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
using View.Views.Components;

namespace View.Views
{
    /// <summary>
    /// Interaction logic for AdminCorections.xaml
    /// </summary>
    public partial class AdminCorections : UserControl
    {
        public AdminCorections()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                Image.Source = new BitmapImage(new Uri(op.FileName));
            }

        }

        private void Image_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {
            ((Image)sender).Source = new BitmapImage(new Uri("Resources/no-image.png", UriKind.Relative));
        }

        private void PopulateWithItems()
        {
            foreach (var meal in MealList.Items)
            {
                MealCardAdmin mealCard = new MealCardAdmin();
                mealCard.DataContext = meal;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            PopulateWithItems();
        }
    }
}
