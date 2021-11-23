using ComputerShop.db;
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

namespace ComputerShop.Pages.WindowsForPages
{
    /// <summary>
    /// Логика взаимодействия для ClientWindow.xaml
    /// </summary>
    public partial class ClientWindow : Window
    {
        public ClientWindow()
        {
            InitializeComponent();
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Client client = new Client();
                client.Name = nameClientTB.Text;
                client.Surname = surnameClientTB.Text;
                client.MiddleName = middlenameClientTB.Text;
                client.Phone = Convert.ToDecimal(phoneClientTB.Text);
                client.Adress = adressClientTB.Text;

                MainWindow.db.Client.Add(client);
                MainWindow.db.SaveChanges();
                MainWindow.pcMainPage.TestGrid.ItemsSource = MainWindow.db.Client.ToList();
            }
            catch
            {
                MessageBox.Show("Проверьте все ли данные заполнены корректно");
            }
        }
    }
}
