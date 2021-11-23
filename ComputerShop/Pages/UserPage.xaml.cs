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
    /// Логика взаимодействия для UserPage.xaml
    /// </summary>
    public partial class UserPage : Page
    {
        public UserPage()
        {
            InitializeComponent();

            nameUserTB.Text = MainWindow.user.Employee.Name;
            surnameUserTB.Text = MainWindow.user.Employee.Surname;
            middlenameUserTB.Text = MainWindow.user.Employee.MiddleName;
            phoneUserTB.Text = MainWindow.user.Employee.Phone.ToString();
        }

        private void GoBackChangeBtn_Click(object sender, RoutedEventArgs e)
        {
            //code
        }
    }
}
