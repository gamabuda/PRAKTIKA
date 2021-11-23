using ComputerShop.View;
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
using ComputerShop.Pages;
using ComputerShop.db;

namespace ComputerShop
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static ComputerShopEntities db = new ComputerShopEntities();
        public static Authentication user;

        public static GridPage pcMainPage;
        public static UserPage userPage;
        public static VideocardPage videocardPage;
        public static ProcessorPage processorPage;
        public static RAMPage ramPage;
        public static CoolerPage coolerPage;
        public static CorpusPage corpusPage;
        public static PowerModulePage powerModulePage;
        public static EmployeePage employeePage;
        public static OrderPage orderPage;
        public static ClientPage clientPage;

        public MainWindow()
        {
            InitializeComponent();

            pcMainPage = new GridPage();
            userPage = new UserPage();
            videocardPage = new VideocardPage();
            processorPage = new ProcessorPage();
            ramPage = new RAMPage();
            coolerPage = new CoolerPage();
            corpusPage = new CorpusPage();
            powerModulePage = new PowerModulePage();
            employeePage = new EmployeePage();
            orderPage = new OrderPage();
            clientPage = new ClientPage();
        }

        public MainWindow(Authentication newUser)
        {
            InitializeComponent();

            user = newUser;

            pcMainPage = new GridPage();
            userPage = new UserPage();
            videocardPage = new VideocardPage();
            processorPage = new ProcessorPage();
            ramPage = new RAMPage();
            coolerPage = new CoolerPage();
            corpusPage = new CorpusPage();
            powerModulePage = new PowerModulePage();
            employeePage = new EmployeePage();
            orderPage = new OrderPage();
            clientPage = new ClientPage();

            CheckUser(user);
        }

        private void CheckUser(Authentication user)
        {
            if(user.RoleID == 2)
            {
                EmployeeBtn.Visibility = Visibility.Collapsed;
                ClientBtn.Visibility = Visibility.Collapsed;

                videocardPage.AddBtn.Visibility = Visibility.Collapsed;
                videocardPage.DelBtn.Visibility = Visibility.Collapsed;
                videocardPage.RedBtn.Visibility = Visibility.Collapsed;

                processorPage.AddBtn.Visibility = Visibility.Collapsed;
                processorPage.DelBtn.Visibility = Visibility.Collapsed;
                processorPage.RedBtn.Visibility = Visibility.Collapsed;

                ramPage.AddBtn.Visibility = Visibility.Collapsed;
                ramPage.DelBtn.Visibility = Visibility.Collapsed;
                ramPage.RedBtn.Visibility = Visibility.Collapsed;

                coolerPage.AddBtn.Visibility = Visibility.Collapsed;
                coolerPage.DelBtn.Visibility = Visibility.Collapsed;
                coolerPage.RedBtn.Visibility = Visibility.Collapsed;

                corpusPage.AddBtn.Visibility = Visibility.Collapsed;
                corpusPage.DelBtn.Visibility = Visibility.Collapsed;
                corpusPage.RedBtn.Visibility = Visibility.Collapsed;

                employeePage.AddBtn.Visibility = Visibility.Collapsed;
                employeePage.DelBtn.Visibility = Visibility.Collapsed;
                employeePage.RedBtn.Visibility = Visibility.Collapsed;

                powerModulePage.AddBtn.Visibility = Visibility.Collapsed;
                powerModulePage.DelBtn.Visibility = Visibility.Collapsed;
                powerModulePage.RedBtn.Visibility = Visibility.Collapsed;
            }
            else if(user.RoleID == 1)
            {
                //admin
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //code
        }

        private void FrameNav_Loaded(object sender, RoutedEventArgs e)
        {
            //code
        }

        private void AboutUsBtn_Click(object sender, RoutedEventArgs e)
        {
            //PageFrame.Navigate(new GridPage());
        }

        private void OpenPCPage_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Navigate(pcMainPage);
        }

        private void OpenUserPage_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Navigate(userPage);
        }

        private void OpenVideocardPage_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Navigate(videocardPage);
        }

        private void OpenProcessorPage_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Navigate(processorPage);
        }

        private void OpenRAMPage_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Navigate(ramPage);
        }

        private void OpenCoolerPage_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Navigate(coolerPage);
        }

        private void OpenCorpusPage_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Navigate(corpusPage);
        }

        private void OpenPowerModulePage_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Navigate(powerModulePage);
        }

        private void OpenEmployeePage_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Navigate(employeePage);
        }

        private void OpenClientPage_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Navigate(clientPage);
        }

        private void MainMenuBtn_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Navigate(orderPage);
        }
    }
}
