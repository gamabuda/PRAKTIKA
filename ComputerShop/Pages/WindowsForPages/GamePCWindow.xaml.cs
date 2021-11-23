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
    /// Логика взаимодействия для GamePCWindow.xaml
    /// </summary>
    public partial class GamePCWindow : Window
    {
        private PC editPC;

        public GamePCWindow()
        {
            InitializeComponent();

            motherPC.ItemsSource = MainWindow.db.Motherboard.ToList();
            motherPC.DisplayMemberPath = "ID";

            procPC.ItemsSource = MainWindow.db.Processor.ToList();
            procPC.DisplayMemberPath = "ID";

            ramPC.ItemsSource = MainWindow.db.RAM.ToList();
            ramPC.DisplayMemberPath = "ID";

            videocardPC.ItemsSource = MainWindow.db.VideoCard.ToList();
            videocardPC.DisplayMemberPath = "ID";

            powerPC.ItemsSource = MainWindow.db.PowerModule.ToList();
            powerPC.DisplayMemberPath = "ID";

            coolerPC.ItemsSource = MainWindow.db.Cooler.ToList();
            coolerPC.DisplayMemberPath = "ID";

            corpusPC.ItemsSource = MainWindow.db.Corpus.ToList();
            corpusPC.DisplayMemberPath = "ID";
        }

        public GamePCWindow(PC editPC)
        {
            InitializeComponent();

            this.editPC = editPC;

            motherPC.ItemsSource = MainWindow.db.Motherboard.ToList();
            motherPC.DisplayMemberPath = "ID";

            procPC.ItemsSource = MainWindow.db.Processor.ToList();
            procPC.DisplayMemberPath = "ID";

            ramPC.ItemsSource = MainWindow.db.RAM.ToList();
            ramPC.DisplayMemberPath = "ID";

            videocardPC.ItemsSource = MainWindow.db.VideoCard.ToList();
            videocardPC.DisplayMemberPath = "ID";

            powerPC.ItemsSource = MainWindow.db.PowerModule.ToList();
            powerPC.DisplayMemberPath = "ID";

            coolerPC.ItemsSource = MainWindow.db.Cooler.ToList();
            coolerPC.DisplayMemberPath = "ID";

            corpusPC.ItemsSource = MainWindow.db.Corpus.ToList();
            corpusPC.DisplayMemberPath = "ID";
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (editPC == null)
                {

                    PC pc = new PC();
                    pc.Name = namePC.Text;
                    pc.Model = modelPC.Text;
                    pc.SerialNumber = serialPC.Text;

                    var mPC = motherPC.SelectedItem as Motherboard;
                    pc.MotherboardID = mPC.ID;

                    var prPC = procPC.SelectedItem as Processor;
                    pc.ProcessorID = prPC.ID;

                    var rPC = ramPC.SelectedItem as RAM;
                    pc.RAM_ID = rPC.ID;

                    var vcPC = videocardPC.SelectedItem as VideoCard;
                    pc.VideocardID = vcPC.ID;

                    var pwPC = powerPC.SelectedItem as PowerModule;
                    pc.PowerModuleID = pwPC.ID;

                    var clPC = coolerPC.SelectedItem as Cooler;
                    pc.CoolerID = clPC.ID;

                    var crPC = corpusPC.SelectedItem as Corpus;
                    pc.СorpusID = crPC.ID;

                    MainWindow.db.PC.Add(pc);
                    MainWindow.db.SaveChanges();
                    MainWindow.pcMainPage.TestGrid.ItemsSource = MainWindow.db.PC.ToList();

                    this.Close();
                }
                else
                {
                    PC pc = new PC();
                    pc.Name = namePC.Text;
                    pc.Model = modelPC.Text;
                    pc.SerialNumber = serialPC.Text;

                    var mPC = motherPC.SelectedItem as Motherboard;
                    pc.MotherboardID = mPC.ID;

                    var prPC = procPC.SelectedItem as Processor;
                    pc.ProcessorID = prPC.ID;

                    var rPC = ramPC.SelectedItem as RAM;
                    pc.RAM_ID = rPC.ID;

                    var vcPC = videocardPC.SelectedItem as VideoCard;
                    pc.VideocardID = vcPC.ID;

                    var pwPC = powerPC.SelectedItem as PowerModule;
                    pc.PowerModuleID = pwPC.ID;

                    var clPC = coolerPC.SelectedItem as Cooler;
                    pc.CoolerID = clPC.ID;

                    var crPC = corpusPC.SelectedItem as Corpus;
                    pc.СorpusID = crPC.ID;

                    try
                    {
                        MainWindow.db.PC.Remove(editPC);
                        MainWindow.pcMainPage.TestGrid.SelectedItems.Clear();
                    }
                    catch
                    {
                        MessageBox.Show("Что-то пошло не так!");
                    }

                    MainWindow.db.PC.Add(pc);
                    MainWindow.db.SaveChanges();
                    MainWindow.pcMainPage.TestGrid.ItemsSource = MainWindow.db.PC.ToList();

                    this.Close();
                }
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так!");
            }
        }
    }
}
