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
using ComputerShop.db;

namespace ComputerShop.Pages.WindowsForPages
{
    /// <summary>
    /// Логика взаимодействия для OrderWindow.xaml
    /// </summary>
    public partial class OrderWindow : Window
    {
        public OrderWindow()
        {
            InitializeComponent();

            orderEmployeeIdCB.ItemsSource = MainWindow.db.Employee.ToList();
            orderEmployeeIdCB.DisplayMemberPath = "ID";

            orderPC_IdCB.ItemsSource = MainWindow.db.PC.ToList();
            orderPC_IdCB.DisplayMemberPath = "ID";

            orderClientIdCB.ItemsSource = MainWindow.db.Client.ToList();
            orderClientIdCB.DisplayMemberPath = "ID";
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddClientBtn_Click(object sender, RoutedEventArgs e)
        {
            ClientWindow clientWindow = new ClientWindow();
            clientWindow.ShowDialog();
            this.Close();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            if(deliveryDateCN != null)
            {
                try
                {
                    Order order = new Order();
                    order.Price = Convert.ToDecimal(orderPriceTB.Text);
                    order.Approximate_delivery_date = (DateTime)deliveryDateCN.SelectedDate;

                    var prID = orderPC_IdCB.SelectedItem as PC;
                    order.PC_ID = prID.ID;

                    var clID = orderClientIdCB.SelectedItem as Client;
                    order.ClientID = clID.ID;

                    var empID = orderEmployeeIdCB.SelectedItem as Employee;
                    order.EmployeeID = empID.ID;

                    MainWindow.db.Order.Add(order);
                    MainWindow.db.SaveChanges();
                    MainWindow.orderPage.TestGrid.ItemsSource = MainWindow.db.Order.ToList();

                    this.Close();
                }
                catch
                {
                    MessageBox.Show("Проверьте все ли данные заполнены!");
                }
            }
            else
            {
                MessageBox.Show("Заполните дату доставки!");
            }
        }

        private void orderPC_IdCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var pc = (orderPC_IdCB.SelectedItem as PC);

            var totalPrice = pc.Motherboard.Price + pc.VideoCard.Price + pc.Processor.Price + pc.Cooler.Price + pc.Corpus.Price + pc.PowerModule.Price + pc.RAM.Price;
            totalPrice = totalPrice + totalPrice / 10;

            orderPriceTB.Text = totalPrice.ToString();
        }
    }
}
