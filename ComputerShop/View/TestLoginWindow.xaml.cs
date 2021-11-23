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
using System.Windows.Threading;

namespace ComputerShop.View
{
    /// <summary>
    /// Логика взаимодействия для TestLoginWindow.xaml
    /// </summary>
    public partial class TestLoginWindow : Window
    {
        public static ComputerShopEntities db = new ComputerShopEntities();

        public TestLoginWindow()
        {
            InitializeComponent();
        }

        private void SubmitBtn_Click(object sender, RoutedEventArgs e)
        {
            if (LoginTxtBlck.Text == "" || PasswordTxtBlck.Password == "")
            {
                MessageBox.Show("Проверти все ли данные заполнены");
            }
            else
            {
                try
                {
                    foreach(var user in db.Authentication)
                    {
                        if(user.Login == LoginTxtBlck.Text.Trim())
                        {
                            if(user.Password == PasswordTxtBlck.Password.Trim())
                            {
                                MainWindow mainWindow = new MainWindow(user);
                                mainWindow.Show();
                                this.Owner = mainWindow;
                                this.Close();
                            }
                        }
                    }              
                }
                catch
                {
                    MessageBox.Show("Что-то пошло не так!");
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoginBtn.Focus();
        }

        private void RegBtn_Click(object sender, RoutedEventArgs e)
        {
            NameStackPanel.Visibility = Visibility.Visible;
            SubmitBtn.Visibility = Visibility.Collapsed;
            SignUpBtn.Visibility = Visibility.Visible;
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            NameStackPanel.Visibility = Visibility.Collapsed;
            SubmitBtn.Visibility = Visibility.Visible;
            SignUpBtn.Visibility = Visibility.Collapsed;
        }

        private void SignUpBtn_Click(object sender, RoutedEventArgs e)
        {
            if(NameTxtBlck.Text == "" || LoginTxtBlck.Text == "" || PasswordTxtBlck.Password == "")
            {
                MessageBox.Show("Проверти все ли данные заполнены");
            }
            else
            {
               try
                {
                    if(LoginCheck())
                    {
                        Employee employee = new Employee();
                        employee.Name = NameTxtBlck.Text;

                        Authentication user = new Authentication();
                        user.Login = LoginTxtBlck.Text;
                        user.Password = PasswordTxtBlck.Password;
                        user.RoleID = 2;
                        user.EmployeeID = employee.ID;

                        db.Employee.Add(employee);
                        db.Authentication.Add(user);
                        db.SaveChanges();


                        MainWindow mainWindow = new MainWindow(user);
                        mainWindow.Show();
                        this.Owner = mainWindow;
                        this.Close();
                    }
                }
                catch
                {
                    MessageBox.Show("Что-то пошло не так!");
                }
            }
        }

        private bool LoginCheck()
        {
            foreach (var userLogin in db.Authentication)
            {
                if (userLogin.Login == LoginTxtBlck.Text)
                {
                    MessageBox.Show("Такое имя пользователя уже занято!");
                    return false;
                }            
            }
            return true;
        }
    }
}
