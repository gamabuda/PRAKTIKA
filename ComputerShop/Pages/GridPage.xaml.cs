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
using ComputerShop.Pages.WindowsForPages;
using ComputerShop.db;

namespace ComputerShop.Pages
{
    /// <summary>
    /// Логика взаимодействия для GridPage.xaml
    /// </summary>
    public partial class GridPage : Page
    {
        public GridPage()
        {
            InitializeComponent();
            TestGrid.ItemsSource = MainWindow.db.PC.ToList();
        }

        private void TestGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //code
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            GamePCWindow gamePCWindow = new GamePCWindow();
            gamePCWindow.ShowDialog();
        }

        private void TestGrid_Loaded(object sender, RoutedEventArgs e)
        {
            //code
        }

        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var pc = (TestGrid.SelectedItem as PC);
                   
                MainWindow.db.PC.Remove(pc);
                TestGrid.SelectedItems.Clear();
                MainWindow.db.SaveChanges();
                TestGrid.ItemsSource = MainWindow.db.PC.ToList();
            }
            catch
            {
                MessageBox.Show("Выберите элемент для удаления!");
            }
        }

        private void RedBtn_Click(object sender, RoutedEventArgs e)
        {
            var pc = (TestGrid.SelectedItem as PC);

            if(pc != null)
            {
                GamePCWindow gamePCWindow = new GamePCWindow(pc);

                gamePCWindow.namePC.Text = pc.Name;
                gamePCWindow.modelPC.Text = pc.Model;
                gamePCWindow.serialPC.Text = pc.SerialNumber;

                gamePCWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Выберите элемент для редактирования!");
            }
        }
    }
}
