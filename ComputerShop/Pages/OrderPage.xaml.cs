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
using ComputerShop.db;
using ComputerShop.Pages.WindowsForPages;

namespace ComputerShop.Pages
{
    /// <summary>
    /// Логика взаимодействия для OrderPage.xaml
    /// </summary>
    public partial class OrderPage : Page
    {

        public OrderPage()
        {
            InitializeComponent();

            TestGrid.ItemsSource = MainWindow.db.Order.ToList();

        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            OrderWindow orderWindow = new OrderWindow();
            orderWindow.ShowDialog();
        }

        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            var order = (TestGrid.SelectedItem as Order);

            if(order != null)
            {
                try
                {
                    MainWindow.db.Order.Remove(order);
                    TestGrid.SelectedItems.Clear();
                    MainWindow.db.SaveChanges();
                    TestGrid.ItemsSource = MainWindow.db.Order.ToList();
                }
                catch
                {
                    MessageBox.Show("Что-то пошло не так!");
                }
            }
            else
            {
                MessageBox.Show("Выберете элимент для удаления!");
            }
        }
    }
}
