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

namespace ComputerShop.Pages
{
    /// <summary>
    /// Логика взаимодействия для VideocardPage.xaml
    /// </summary>
    public partial class VideocardPage : Page
    {
        public VideocardPage()
        {
            InitializeComponent();
            TestGrid.ItemsSource = MainWindow.db.VideoCard.ToList();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddBtn_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
